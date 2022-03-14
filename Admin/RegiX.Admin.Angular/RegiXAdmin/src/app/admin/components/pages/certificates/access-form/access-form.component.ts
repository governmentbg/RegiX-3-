import { Component, OnInit, OnDestroy, ViewChild } from '@angular/core';
import { IgxSelectComponent, IgxTreeGridComponent, IgxDialogComponent } from 'igniteui-angular';
import { FormGroup, FormBuilder, Validators } from '@angular/forms';
import { DisplayValue } from 'src/app/core/models/display-value.model';
import { AdapterOperationsService } from 'src/app/core/services/rest/adapter-operations.service';
import { AdaptersService } from 'src/app/core/services/rest/adapters.service';
import { RegistryService } from 'src/app/core/services/rest/registry.service';
import { AdministrationsService } from 'src/app/core/services/rest/administration.service';
import { AdapterOperationModel } from 'src/app/core/models/dto/adapter-operation.model';
import { HttpParams } from '@angular/common/http';
import { ConsumerCertificatesService } from 'src/app/core/services/rest/consumer-certificates.service';
import { ActivatedRoute } from '@angular/router';
import { Location } from '@angular/common';
import { BackService } from '@tl/tl-common';
import { RegisterObjectElementsService } from 'src/app/core/services/rest/register-object-elements.service';
import { RegisterObjectElementModel } from 'src/app/core/models/dto/register-object-element.model';
import { CertificateElementAccessInModel } from 'src/app/core/models/dto/in/certificate-element-access.in.model';
import { CertificateElementAccessService } from 'src/app/core/services/rest/certificate-element-access.service';
import { ToastService } from '@tl/tl-common';
import { NGXLogger } from 'ngx-logger';
import { ROUTES } from 'src/app/admin/routes/static-routes';
import { onTreeRowClickChange } from '../access-edit-form/access-edit-form.component';
import { OperationFilterComponent } from '../../filters/operation-filter/operation-filter.component';

@Component({
  selector: 'app-access-form',
  templateUrl: './access-form.component.html',
  styleUrls: ['./access-form.component.scss'],
})
export class AccessFormComponent implements OnInit, OnDestroy {
  routes = ROUTES;
  certOperationAccess = ROUTES.CERTIFICATE_OPERATION_ACCESS;
  subtitle: string;
  consumer: string;

  @ViewChild('operationDialog', { static: true })
  operationDialog: IgxDialogComponent;

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

  pageTitle = 'Редактиране на достъпа';

  formGroup: FormGroup = null;

  registerAdministrations: DisplayValue[] = [];
  registers: DisplayValue[] = [];
  adapters: DisplayValue[] = [];
  operations: AdapterOperationModel[] = [];

  operationElements: any[] = [];
  selectedElements: number[] = [];

  certificateId: number;

  errorMessage: string = null;

  constructor(
    private formBuilder: FormBuilder,
    private certificateService: ConsumerCertificatesService,
    private activatedRoute: ActivatedRoute,
    private location: Location,
    private objectElementsService: RegisterObjectElementsService,
    private certificateElementAccessService: CertificateElementAccessService,
    private backService: BackService,
    private toastService: ToastService,
    private logger: NGXLogger
  ) {
    this.formGroup = this.buildForm();

    this.activatedRoute.params.subscribe((params) => {
      this.certificateId = params['ID'];
      if (!this.certificateId) {
        this.location.back();
      } else {
        this.certificateService.find(this.certificateId).subscribe((data) => {
          this.pageTitle =
            'Редактиране на достъп на сертификат "' + data.name + '"';
          this.subtitle = data.name;
          this.consumer = data.apiServiceConsumer.displayName;
        });
      }
    });
  }

  showOperationChoice() {
    this.operationDialog.open();
    this.operationFilter.loadFirstSection();
  }

  operationSelected(selectedItems: { id: number; name: string; data: any }[]){
    this.operationDialog.close();
    this.formGroup.controls['administration'].setValue(selectedItems[0].name);
    this.formGroup.controls['register'].setValue(selectedItems[1].name);
    this.formGroup.controls['adapter'].setValue(selectedItems[2].name);
    this.formGroup.controls['operation'].setValue(selectedItems[3].name);
    this.formGroup.controls['operationId'].setValue(selectedItems[3].id);
    this.changeOperation(selectedItems[3].data);
  }

  buildForm(): FormGroup {
    return this.formBuilder.group({
      administration: [{ value: null, disabled: true }],
      register: [{ value: null, disabled: true }],
      adapter: [{ value: null, disabled: true }],
      operation: [{ value: null, disabled: true }, [Validators.required]],
      operationId: [{ value: null, disabled: true }, [Validators.required]],
      comments: [{ value: null, disabled: false }, [Validators.required]],
    });
  }

  ngOnInit() {
    this.backService.isBackVisible(true);
  }

  ngOnDestroy() {}

  private changeOperation(value: any) {
    let httpParameters = new HttpParams();
    const operation = new AdapterOperationModel(value);
    if (operation) {
      const filteringParam = 'registerObject.id eq ' + operation.registerObject.id;
      httpParameters = httpParameters.append('$filter', filteringParam);
      this.objectElementsService
        .getAllNoWrap(httpParameters)
        .subscribe((data) => {
          this.buildOperationsTree(data);
        });
      this.treeGrid.clearCellSelection();
      this.treeGrid.clearFilter();
      this.treeGrid.clearSearch();
      this.treeGrid.clearSort();
      this.treeGrid.deselectAllRows();
      this.objectElementsService
        .getSelectedElements({
          certificate: this.certificateId,
          operation: operation.registerObject.id,
        })
        .subscribe((data) => {
          this.treeGrid.selectRows(data, true);
        });
    }
  }

  private buildOperationsTree(
    data: RegisterObjectElementModel[]  ) {
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
      this.setToNull(this.selectOperation, 'adapterOperation');
      this.operations = [];
    }
  }

  hasValue(formControlName: string) {
    return this.formGroup.controls[formControlName].value !== null;
  }

  onRowClickChange(event) {
    onTreeRowClickChange(this.operationElements, event, this.treeGrid);
  }

  onCancel() {
    this.location.back();
  }

  onSaveChanged() {
    if (this.isFormValid()) {
      const value = this.formGroup.getRawValue();
      const rows = this.treeGrid.selectedRows();
      const inModel: any = new CertificateElementAccessInModel({
        hasAccess: true,
        consumerCertificateId: this.certificateId,
        registerObjectElementIds: rows,
        adapterOperationId: value.operationId,
        editAccessComment: value.comments,
        // TODO use actional user identifier when login is done
        // get currently logged in user
        userId: 2,
      });
      this.certificateElementAccessService.save(inModel).subscribe(
        (data) => {
          // this.createRowInUI(data);
          this.logger.debug('object inserted, refresh form or redirect', data);
          this.formGroup.markAsPristine();
          this.formGroup.markAsUntouched();
          this.errorMessage = null;
          this.toastService.showMessage('Достъпът до елементи е актуализиран!');
          this.location.back();
        },
        (error) => {
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
    return (
      this.formGroup.dirty &&
      this.formGroup.valid &&
      this.treeGrid.selectedRows().length > 0
    );
  }

  public isFormDirty() {
    return this.formGroup.dirty;
  }

  resetForm() {
    this.operationElements = [];
    this.formGroup.markAsPristine();
    this.formGroup.markAsUntouched();
    this.formGroup.reset();
    this.errorMessage = null;
  }
}
