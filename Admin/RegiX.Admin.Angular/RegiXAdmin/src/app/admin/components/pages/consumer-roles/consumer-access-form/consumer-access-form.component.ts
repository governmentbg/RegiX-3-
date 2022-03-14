import { Component, OnInit, OnDestroy, ViewChild } from '@angular/core';
import {
  IgxSelectComponent,
  IgxTreeGridComponent,
  IgxDialogComponent,
} from 'igniteui-angular';
import { FormGroup, FormBuilder, Validators } from '@angular/forms';
import { DisplayValue } from 'src/app/core/models/display-value.model';
import { AdapterOperationModel } from 'src/app/core/models/dto/adapter-operation.model';
import { HttpParams } from '@angular/common/http';
import { ActivatedRoute } from '@angular/router';
import { Location } from '@angular/common';
import { BackService } from '@tl/tl-common';
import { RegisterObjectElementsService } from 'src/app/core/services/rest/register-object-elements.service';
import { RegisterObjectElementModel } from 'src/app/core/models/dto/register-object-element.model';
import { ToastService } from '@tl/tl-common';
import { ConsumerRoleElementAccessService } from 'src/app/core/services/rest/consumer-role-element-access.service';
import { ConsumerRoleService } from 'src/app/core/services/rest/consumer-role.service';
import { ConsumerRoleElementAccessInModel } from 'src/app/core/models/dto/in/consumer-role-element-access.in.model';
import { NGXLogger } from 'ngx-logger';
import { ROUTES } from 'src/app/admin/routes/static-routes';
import { onTreeRowClickChange } from '../../certificates/access-edit-form/access-edit-form.component';
import { OperationFilterComponent } from '../../filters/operation-filter/operation-filter.component';

@Component({
  selector: 'app-consumer-access-form',
  templateUrl: './consumer-access-form.component.html',
  styleUrls: ['./consumer-access-form.component.scss'],
})
export class ConsumerAccessFormComponent implements OnInit, OnDestroy {
  routes = ROUTES;
  roleOperationAccess = ROUTES.CONSUMER_ROLE_ACCESS_ROLEID;
  subtitle: string;

  @ViewChild('treeGrid', { static: true })
  treeGrid: IgxTreeGridComponent;
  @ViewChild('operationFilter')
  operationFilter: OperationFilterComponent;

  @ViewChild('selectRegister', { static: true })
  selectRegister: IgxSelectComponent;
  @ViewChild('selectRegisterAdmin', { static: true })
  selectRegisterAdmin: IgxSelectComponent;
  @ViewChild('selectAdapter', { static: true })
  selectAdapter: IgxSelectComponent;
  @ViewChild('selectOperation', { static: true })
  selectOperation: IgxSelectComponent;
  @ViewChild('operationDialog', { static: true })
  operationDialog: IgxDialogComponent;

  isLoading = false;

  pageTitle = 'Редактиране на достъпа';

  formGroup: FormGroup = null;

  registerAdministrations: DisplayValue[] = [];
  registers: DisplayValue[] = [];
  adapters: DisplayValue[] = [];
  operations: AdapterOperationModel[] = [];

  operationElements: any[] = [];
  selectedElements: number[] = [];

  consumerRoleId: number;
  operationId: number;

  errorMessage: string = null;

  constructor(
    private formBuilder: FormBuilder,
    private consumerRolesService: ConsumerRoleService,
    private activatedRoute: ActivatedRoute,
    private location: Location,
    private objectElementsService: RegisterObjectElementsService,
    private consumerRoleElementAccessService: ConsumerRoleElementAccessService,
    private toastService: ToastService,
    private logger: NGXLogger
  ) {
    this.formGroup = this.buildForm();

    this.activatedRoute.params.subscribe((params) => {
      this.consumerRoleId = params['ROLE_ID'];
      if (!this.consumerRoleId) {
        this.location.back();
      } else {
        this.isLoading = true;
        this.consumerRolesService.find(this.consumerRoleId).subscribe(
          (data) => {
            this.isLoading = false;
            this.pageTitle =
              'Редактиране на операция за роля "' + data.name + '"';
            this.subtitle = `Роля "${data.name}"`;
          },
          () => {
            this.isLoading = false;
          }
        );
      }
    });
  }
  showOperationChoice() {
    this.operationDialog.open();
    this.operationFilter.loadFirstSection();
  }

  buildForm(): FormGroup {
    return this.formBuilder.group({
      administration: [{ value: null, disabled: true }],
      register: [{ value: null, disabled: true }],
      adapter: [{ value: null, disabled: true }],
      operation: [{ value: null, disabled: true }, [Validators.required]],
      //comments: [{ value: null, disabled: false }, [Validators.required]]
    });
  }

  ngOnInit() {}

  operationSelected(selectedItems: { id: number; name: string; data: any }[]) {
    this.operationDialog.close();
    this.formGroup.controls['administration'].setValue(selectedItems[0].name);
    this.formGroup.controls['register'].setValue(selectedItems[1].name);
    this.formGroup.controls['adapter'].setValue(selectedItems[2].name);
    this.formGroup.controls['operation'].setValue(selectedItems[3].name);
    this.operationId = selectedItems[3].id;
    this.changeOperation(selectedItems[3].data);
  }

  ngOnDestroy() {}

  private changeOperation(newValue: any) {
    let httpParameters = new HttpParams();
    const operation = new AdapterOperationModel(newValue);
    if (operation) {
      const filteringParam =
        'registerObject.id eq ' + operation.registerObject.id;
      httpParameters = httpParameters.append('$filter', filteringParam);
      this.isLoading = true;
      this.objectElementsService.getAllNoWrap(httpParameters).subscribe(
        (data) => {
          this.isLoading = false;
          this.buildOperationsTree(data);
        },
        () => {
          this.isLoading = false;
        }
      );
      this.treeGrid.clearCellSelection();
      this.treeGrid.clearFilter();
      this.treeGrid.clearSearch();
      this.treeGrid.clearSort();
      this.treeGrid.deselectAllRows();
      this.isLoading = true;
      this.objectElementsService
        .getSelectedElements({
          certificate: this.consumerRoleId,
          operation: operation.registerObject.id,
        })
        .subscribe(
          (data) => {
            this.isLoading = false;
            this.treeGrid.selectRows(data, true);
          },
          () => {
            this.isLoading = false;
          }
        );
    }
  }

  private buildOperationsTree(data: RegisterObjectElementModel[]) {
    // let httpParameters = new HttpParams();
    // const filteringParam =
    //       'registerObject.id eq ' + operationId + ' and ';
    // httpParameters = httpParameters.append('$filter', filteringParam);

    const identifiers: any = {};
    data.forEach((element) => {
      identifiers[element.pathToRoot] = element.id;
    });
    const objects: any[] = [];
    data.forEach((element) => {
      const object = Object(element);
      let fKey = -1;
      object.primaryKey = element.id;
      const arr = element.pathToRoot.split('.');
      if (arr.length > 1) {
        // remove last element and join the array
        arr.splice(arr.length - 1, 1);
        const str = arr.join('.');
        fKey = identifiers[str];
        if (!fKey) {
          fKey = -1;
        }
      } else {
        fKey = -1;
      }
      object.foreignKey = fKey;
      objects.push(object);
    });
    this.operationElements = objects;
  }

  setToNull(igxSelect: IgxSelectComponent, formControlName: string) {
    igxSelect.value = null;
    this.formGroup.controls[formControlName].setValue(null);

    if (igxSelect === this.selectRegisterAdmin) {
      this.setToNull(this.selectRegister, 'register');
      this.registers = [];
    }
    if (igxSelect === this.selectRegister) {
      this.setToNull(this.selectAdapter, 'adapter');
      this.adapters = [];
    }
    if (igxSelect === this.selectAdapter) {
      this.setToNull(this.selectOperation, 'operation');
      this.operations = [];
    }
  }

  hasValue(formControlName: string) {
    return this.formGroup.controls[formControlName].value !== null;
  }

  onRowClickChange($event) {
    onTreeRowClickChange(this.operationElements, $event, this.treeGrid);
  }

  onSaveChanged() {
    this.isLoading = true;
    if (this.isFormValid()) {
      const value = this.formGroup.getRawValue();
      const rows = this.treeGrid.selectedRows();
      const inModel: any = new ConsumerRoleElementAccessInModel({
        hasAccess: true,
        consumerRoleId: this.consumerRoleId,
        registerObjectElementIds: rows,
        adapterOperationId: this.operationId,
        //editAccessComment: value.comments,
      });
      this.consumerRoleElementAccessService.save(inModel).subscribe(
        (data) => {
          this.isLoading = false;
          // this.createRowInUI(data);
          this.logger.debug('object inserted, refresh form or redirect', data);
          this.formGroup.markAsPristine();
          this.formGroup.markAsUntouched();
          this.errorMessage = null;
          this.toastService.showMessage('Достъпът до елементи е актуализиран!');
          this.location.back();
        },
        (error) => {
          this.isLoading = false;
          this.errorMessage =
            'Грешка при актуализиране на достъп до елементи: ' + error.error;
          this.toastService.showMessage(
            'Грешка при актуализиране на достъп до елементи!'
          );
        }
      );
    }
  }

  public isFormValid() {
    return this.operationId && this.treeGrid.selectedRows().length > 0;
  }

  public isFormDirty() {
    return this.operationId;
  }

  resetForm() {
    this.operationElements = [];
    this.formGroup.markAsPristine();
    this.formGroup.markAsUntouched();
    this.formGroup.reset();
    this.errorMessage = null;
  }
}
