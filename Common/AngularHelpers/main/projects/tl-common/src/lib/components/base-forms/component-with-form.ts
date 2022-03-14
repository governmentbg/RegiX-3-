import { BehaviorSubject, Subscription } from 'rxjs';
import { HttpParams } from '@angular/common/http';

import { OnInit, Injector, ViewChild, OnDestroy } from '@angular/core';
import { Router, ActivatedRoute, Params } from '@angular/router';
import { IgxDialogComponent, IgxExcelExporterService, IgxExcelExporterOptions } from 'igniteui-angular';
import { EActions } from '../../enums/actions.enum';
import { BackService } from '../../services/back.service';
import { EColumnType } from '../../enums/column.type.enum';
import { TableFilter } from '../../models/table-filter.model';
import { ToastService } from '../../services/toast.service';
import { CrudService } from '../../services/crud.service';
import { NGXLogger } from 'ngx-logger';
import { ITLRouteReference } from '../../routing/route-reference';

export abstract class ComponentWithForm<
  T extends { id: any },
  CS extends CrudService<T, any>
> implements OnInit, OnDestroy {
  actionType: EActions;
  currentAction: EActions;

  @ViewChild('grid', { /*read: IgxGridComponent*/ static: true })
  public grid: any;
  
  public excelExport: ITLRouteReference;
  protected exportService: IgxExcelExporterService;

  @ViewChild('dialog', { read: IgxDialogComponent, static: true })
  public dialog: IgxDialogComponent;

  public dataBehavior: BehaviorSubject<any> = new BehaviorSubject({});

  private dataSubscription: Subscription;

  items$: any;

  protected toastService: ToastService;

  protected router: Router;
  protected activatedRoute: ActivatedRoute;
  protected backService: BackService;

  public filter: TableFilter = null;
  public isIDFilter = false;
  public isFilterFieldFromData = false;
  protected logger: NGXLogger;

  constructor(public service: CS, protected injector: Injector) {
    this.backService = this.injector.get<BackService>(BackService as any);

    this.router = this.injector.get<Router>(Router as any);
    this.toastService = this.injector.get<ToastService>(ToastService as any);
    this.activatedRoute = this.injector.get<ActivatedRoute>(
      ActivatedRoute as any
    );
    this.logger = this.injector.get<NGXLogger>(NGXLogger);
    this.initializeExcelExport();
    this.initializeItems();
  }

  protected initializeExcelExport(): void{
    this.exportService = this.injector.get<IgxExcelExporterService>(IgxExcelExporterService);
    
    let exportOptions = new IgxExcelExporterOptions('ExportedData');
    exportOptions.ignoreColumnsVisibility  = true;
    
    this.excelExport = {
      route: [''],
      title: 'Експорт към Excel',
      icon: 'grid_on',
      permissions: [],
      navigate: (r, a, ac) => {
        this.exportService.export(
          this.grid,
          exportOptions
        );
      },
      staticRoute: (a) => [],
      relativeRoute: (a) => [],
    };
  }

  protected initializeItems() {
    this.dataSubscription = this.dataBehavior.subscribe(data => {
      this.items$ = data;
    });
  }

  ngOnInit(): void {
    this.initializeFilter();
  }
  
  protected afterFilterInitialized() {
    this.ngOnInitImpl();
    const httpParameters = this.getExtendedParameters(null);
    this.readData(httpParameters);
  }

  protected getFilterField(): string {
    return 'FILTER_FIELD';
  }
  protected getIDField(): string {
    return 'ID';
  }

  protected initializeFilter() {
    this.activatedRoute.params.subscribe(params => {
      this.initializeFilterWithParams(params);
      this.afterFilterInitialized();
    });
  }

  protected initializeFilterWithParams(params: Params){
    const filterField = params[this.getFilterField()];
    const idField = params[this.getIDField()];
    if (filterField && filterField !== '-') {
      this.isFilterFieldFromData = false;
      let routeField = this.activatedRoute.snapshot.data.filterField;
      if (!routeField) {
        routeField = this.getFilterColumn();
      } else {
        this.isFilterFieldFromData = true;
      }

      this.isIDFilter = false;
      this.filter = new TableFilter({
        columnName: routeField,
        columnValue: filterField,
        columnType: this.getFilterColumnType()
      });
      this.backService.isBackVisible(true);
    } else if (idField) {
      this.isIDFilter = true;
      this.filter = new TableFilter({
        columnName: this.getIdColumn(),
        columnValue: idField,
        columnType: this.getIdColumnType()
      });
      this.backService.isBackVisible(true);
    } else {
      this.filter = null;
      this.backService.isBackVisible(false);
    }
  }

  ngOnDestroy() {
    if (this.dataSubscription) {
      this.dataSubscription.unsubscribe();
    }
  }

  protected readData(params?: HttpParams) {
    this.logger.debug('READ DATA IN BASIC');
    this.service.getAll(params).subscribe((data: T[]) => {
      const obj = Object(data);
      this.dataBehavior.next(obj);
    });
  }

  ngOnInitImpl(): void {}

  deleteRowInUI(object: T) {}

  deleteObject(object: T) {
    this.service.delete(object.id).subscribe(
      data => {
        this.deleteRowInUI(object);
        this.toastService.showMessage('Обектът е изтрит успешно!');
        if (this.dialog) {
          this.dialog.close();
        }
      },
      error => {
        this.toastService.showMessage('Грешка при изтриване на обект!');
        this.logger.error(error);
        if (this.dialog) {
          this.dialog.close();
        }
      }
    );
  }

  prepareForEdit(object: T) {
    this.currentAction = EActions.EDIT;
  }

  prepareForCreate() {
    this.currentAction = EActions.CREATE;
  }

  prepareForShow(object: T) {
    this.currentAction = EActions.SHOW;
  }

  get actions() {
    return EActions;
  }

  isCreateAction(): boolean {
    return this.currentAction === EActions.CREATE;
  }
  isEditAction(): boolean {
    return this.currentAction === EActions.EDIT;
  }

  isShowAction(): boolean {
    return this.currentAction === EActions.SHOW;
  }

  protected getFilterColumn(): string {
    return null;
  }

  protected getFilterColumnType(): EColumnType {
    return EColumnType.STRING;
  }

  protected getIdColumn(): string {
    return 'id';
  }

  protected getIdColumnType(): EColumnType {
    return EColumnType.DECIMAL;
  }

  pagerChange(event) {
    this.grid.perPage = event.perPage;
    this.grid.page = event.page;
  }

  protected getFilterExpression() {
    if (this.filter && this.filter.columnName) {
      let columnValue = this.filter.columnValue;
      if (this.filter.columnType === EColumnType.STRING) {
        columnValue = "'" + columnValue + "'";
      }
      return this.filter.columnName + ' eq ' + columnValue;
    }
    return null;
  }

  getExtendedParameters(params?: HttpParams) {
    this.logger.debug('READ DATA IN REMOTE');
    const filteringParams = this.getFilterExpression();
    let httpParameters = params;
    if (filteringParams) {
      if (!httpParameters) {
        httpParameters = new HttpParams();
      }
      httpParameters = httpParameters.append('$filter', filteringParams);
    }
    this.logger.debug('httpParameters', httpParameters);
    return httpParameters;
  }
}
