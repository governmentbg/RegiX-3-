import {
  IFilteringExpressionsTree,
  IgxExcelExporterOptions,
} from 'igniteui-angular';
import { OnInit, AfterViewInit } from '@angular/core';
import { HttpParams } from '@angular/common/http';

import { ComponentWithForm } from './component-with-form';
import { IGridPagerOutputParams } from '../grid-pager/grid-pager.component';
import { CrudService } from '../../services/crud.service';
import { GridRemoteFilteringService } from '../../services/grid-remote-filtering.service';
import { ITLRouteReference } from '../../routing/route-reference';
import { Observable } from 'rxjs';
import { map } from 'rxjs/operators';

export abstract class RemoteComponentWithForm<
    T extends { id: number },
    CS extends CrudService<T, number>
  >
  extends ComponentWithForm<T, CS>
  implements OnInit, AfterViewInit {
  public remoteService: GridRemoteFilteringService<T, CS>;

  public excelExportAll: ITLRouteReference;
  protected objectForDelete: T = null;
  protected defaultRowsPerPage = 15;

  ///////////////////////////

  ngOnInit() {
    this.createRemoteService();
    this.remoteService._extRemoteData = this.dataBehavior;
    this.remoteService.pagerParams.perPage = this.grid.perPage;
    this.configureExcelExport();

    super.ngOnInit();
  }

  protected createRemoteService() {
    this.remoteService = new GridRemoteFilteringService(
      null,
      this.service,
      this.grid,
      this.injector
    );
  }

  protected initializeItems() {
    this.items$ = this.dataBehavior.asObservable();
  }

  ngAfterViewInit() {
    // this.applyExternalFiltering();
  }

  public pagerChange(event: IGridPagerOutputParams) {
    this.remoteService.pagerParams.perPage = event.perPage;
    this.remoteService.pagerParams.page = event.page;
    const httpParameters = this.getExtendedParameters(null);
    this.remoteService.processData(httpParameters);
  }

  public readData(params?: HttpParams) {
    this.remoteService.pagerParams.perPage = this.defaultRowsPerPage;
    const httpParameters = this.getExtendedParameters(params);
    this.remoteService.processData(httpParameters);

    // this.remoteService.pagerParams.perPage = 10;
    // this.remoteService.processData(params);
  }

  deleteRowInUI(object: T) {
    this.logger.debug('deleteRowInUI:', object);
    this.grid.deleteRow(object.id);
  }

  prepareForEdit(item: T, cell?) {
    this.logger.debug('prepareForEdit:', item, cell);
    this.grid.selectRows([cell.row.rowID], true);
    super.prepareForEdit(item);
  }

  prepareForDelete(object: T) {
    this.objectForDelete = object;
    this.dialog.open();
  }

  onDeleteCanceled() {
    this.objectForDelete = null;
    this.dialog.close();
  }

  onDeleteConfirmed() {
    this.deleteObject(this.objectForDelete);
    this.objectForDelete = null;
  }

  public cellSelection(event: any) {
    // const cell = event.cell;
    // this.grid.selectRows([cell.row.rowID], true);
  }

  public filteringDone(event: IFilteringExpressionsTree) {
    this.logger.debug('filteringDone:', event);
    this.remoteService.pagerParams.page = 0;
    const httpParameters = this.getExtendedParameters(null);
    this.remoteService.processData(httpParameters);
  }

  public sortingDone(event: any) {
    // this.grid.columns.forEach(col => {
    //   this.logger.debug('COLUMN', col.field, event.fieldName);
    //   if (col.field !== event.fieldName) {
    //     this.logger.debug('clearing sort', col.field);

    //     this.grid.clearSort(col.field);
    //   }
    // });
    this.remoteService.processData(this.getExtendedParameters(null));
  }

  protected configureExcelExport() {
    this.excelExportAll = {
      route: [''],
      title: 'Експорт към Excel',
      icon: 'grid_on',
      permissions: [],
      navigate: () => {
        this.configureExcelExportService();
      },
      staticRoute: () => [],
      relativeRoute: () => [],
    };
  }

  protected configureExcelExportService() {
    let httpParams = this.excelExportGetHttpParams();
    this.excelExportGetAllNoWrap(httpParams)
      .pipe(
        map((items: T[]) => {
          return items.map((item) => {
            return this.excelExportMapItem(item);
          });
        })
      )
      .subscribe((data) => {
        this.exportService.exportData(
          data,
          new IgxExcelExporterOptions('exportedData')
        );
      });
  }

  protected excelExportGetHttpParams(): HttpParams {
    return this.remoteService.getExcelExportParams();
  }

  protected excelExportMapItem(item: T): any {
    return item;
  }

  protected excelExportGetAllNoWrap(httpParams: HttpParams): Observable<T[]> {
    return this.service.getAllNoWrap(httpParams);
  }
}
