import { Component, OnInit, OnDestroy, ViewChild } from '@angular/core';
import { IgxTreeGridComponent, IRowSelectionEventArgs } from 'igniteui-angular';
import { FormGroup, FormBuilder, Validators } from '@angular/forms';
import { DisplayValue } from 'src/app/core/models/display-value.model';
import { AdapterOperationsService } from 'src/app/core/services/rest/adapter-operations.service';
import { AdaptersService } from 'src/app/core/services/rest/adapters.service';
import { RegistryService } from 'src/app/core/services/rest/registry.service';
import { ActivatedRoute } from '@angular/router';
import { Location } from '@angular/common';
import { BackService } from '@tl/tl-common';
import { CertificateElementAccessInModel } from 'src/app/core/models/dto/in/certificate-element-access.in.model';
import { CertificateElementAccessService } from 'src/app/core/services/rest/certificate-element-access.service';
import { ToastService } from '@tl/tl-common';
import { AdapterOperationModel } from 'src/app/core/models/dto/adapter-operation.model';
import { map } from 'rxjs/operators';
import { AdapterModel } from 'src/app/core/models/dto/adapters.model';
import { RegistryModel } from 'src/app/core/models/dto/registy.model';
import { HttpParams } from '@angular/common/http';
import { RegisterObjectElementsService } from 'src/app/core/services/rest/register-object-elements.service';
import { RegisterObjectElementModel } from 'src/app/core/models/dto/register-object-element.model';
import { NGXLogger } from 'ngx-logger';
import { ROUTES } from 'src/app/admin/routes/static-routes';
import { ConsumerCertificatesService } from 'src/app/core/services/rest/consumer-certificates.service';


export function findAllAncestors(operationElements: any[], children: any[], ancestors: any[]) {
  const found = operationElements
    .filter(
      (oe) =>
        children.filter(
          (child) => child === oe.primaryKey && oe.foreignKey !== -1
        ).length > 0
    )
    .map((oe) => oe.foreignKey);
  ancestors.push(...found);
  if (found.length > 0) {
    findAllAncestors(operationElements, found, ancestors);
  }
}

export function findAllDescendants(operationElements: any[], elements: any[], descendants: any[]) {
  const found = operationElements
    .filter(
      (oe) => elements.filter((parent) => parent === oe.foreignKey).length > 0
    )
    .map((oe) => oe.id);
  descendants.push(...found);
  if (found.length > 0) {
    findAllDescendants(operationElements, found, descendants);
  }
}

export function onTreeRowClickChange(operationElements: any[], event: IRowSelectionEventArgs, treeGrid: IgxTreeGridComponent) {
  event.cancel = true;
  if (event.added.length > 0) {
    const otherToAdd = [];
    findAllDescendants(operationElements, event.added, otherToAdd);
    findAllAncestors(operationElements, event.added, otherToAdd);
    treeGrid.selectRows(event.added.concat(otherToAdd));
  }
  if (event.removed.length > 0) {
    const otherToRemove = [];
    findAllDescendants(operationElements, event.removed, otherToRemove);
    treeGrid.deselectRows(event.removed.concat(otherToRemove));
  }
}

@Component({
  selector: 'app-access-edit-form',
  templateUrl: './access-edit-form.component.html',
  styleUrls: ['./access-edit-form.component.scss'],
})
export class AccessEditFormComponent implements OnInit, OnDestroy {
  routes = ROUTES;
  certOperationAccessRoute = ROUTES.CERTIFICATE_OPERATION_ACCESS_EDIT;

  @ViewChild('treeGrid', { static: true })
  treeGrid: IgxTreeGridComponent;

  pageTitle = 'Редактиране на достъпа';
  subtitle: string;
  consumer: string;

  loadingElements = false;

  formGroup: FormGroup = null;

  administration: DisplayValue;
  register: DisplayValue;
  adapter: DisplayValue;
  operation: DisplayValue;

  operationElements: any[] = [];
  selectedElements: number[] = [];

  adapterOperationId: number;

  errorMessage: string = null;

  certificateId: number = null;

  registerObjectId: number = null;
  registerAdapterId: number = null;
  registerId: number = null;
  administrationId: number = null;

  constructor(
    private formBuilder: FormBuilder,
    private adapterOperationsService: AdapterOperationsService,
    private adaptersService: AdaptersService,
    private registryService: RegistryService,
    private objectElementsService: RegisterObjectElementsService,
    private activatedRoute: ActivatedRoute,
    private location: Location,
    private certificateService: ConsumerCertificatesService,
    private certificateElementAccessService: CertificateElementAccessService,
    private backService: BackService,
    private toastService: ToastService,
    private logger: NGXLogger
  ) {
    this.formGroup = this.buildForm();

    this.activatedRoute.params.subscribe((params) => {
      this.adapterOperationId = params['ID'];
      this.certificateId = params['CertificeteId'];
      if (!this.adapterOperationId) {
        this.location.back();
      } else {
        //get operation and adapter
        this.adapterOperationsService
          .find(this.adapterOperationId)
          .pipe(
            map((item: AdapterOperationModel) => {
              this.registerAdapterId = item.registerAdapter.id;
              this.adapter = item.registerAdapter;

              this.registerObjectId = item.registerObject.id;
              this.operation = new DisplayValue({id: item.id, displayName: item.description});

              this.pageTitle =
                'Редактиране на достъп на операция "' + item.description + '"';
              this.certificateService.find(this.certificateId).subscribe(data => {
                this.subtitle = data.name;
                this.consumer = data.apiServiceConsumer.displayName;
              });
              this.formGroup.patchValue({
                adapter: this.adapter.displayName,
                operation: this.operation.displayName,
              });
              this.GetRegister();
            })
          )
          .subscribe();
      }
    });
  }

  buildForm(): FormGroup {
    return this.formBuilder.group({
      administration: [{ value: null, disabled: true }],
      register: [{ value: null, disabled: true }],
      adapter: [{ value: null, disabled: true }],
      operation: [{ value: null, disabled: true }],
      comments: [{ value: null, disabled: false }, [Validators.required]],
    });
  }

  ngOnInit() {
    this.backService.isBackVisible(true);
  }

  ngOnDestroy() {}

  hasValue(formControlName: string) {
    return this.formGroup.controls[formControlName].value !== null;
  }

  onRowClickChange(event: IRowSelectionEventArgs) {
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
        adapterOperationId: this.adapterOperationId,
        editAccessComment: value.comments,
        // TODO use actional user identifier when login is done
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
      this.formGroup.valid
    );
  }

  public isFormDirty() {
    return this.formGroup.dirty;
  }

  resetForm() {
    this.treeGrid.deselectAllRows();
    this.formGroup.markAsPristine();
    this.formGroup.markAsUntouched();
    this.formGroup.controls['comments'].setValue(null);
    this.errorMessage = null;
  }

  private GetRegister() {
    this.adaptersService
      .find(this.registerAdapterId)
      .pipe(
        map((item: AdapterModel) => {
          this.registerId = item.register.id;
          this.register = item.register;

          this.formGroup.patchValue({
            register: this.register.displayName,
          });
          this.GetAdministration();
        })
      )
      .subscribe();
  }

  private GetAdministration() {
    this.registryService
      .find(this.registerId)
      .pipe(
        map((item: RegistryModel) => {
          this.administrationId = item.administration.id;
          this.administration = item.administration;

          this.formGroup.patchValue({
            administration: this.administration.displayName,
          });
          this.GetOperationElements();
        })
      )
      .subscribe();
  }

  private GetOperationElements() {
    let httpParameters = new HttpParams();

    const filteringParam = 'registerObject.id eq ' + this.registerObjectId;
    httpParameters = httpParameters.append('$filter', filteringParam);
    this.loadingElements = true;
    this.objectElementsService
      .getAllNoWrap(httpParameters)
      .subscribe((data) => {
        this.loadingElements = false;
        this.buildOperationsTree(data, this.operation.id);
      });
    this.treeGrid.clearCellSelection();
    this.treeGrid.clearFilter();
    this.treeGrid.clearSearch();
    this.treeGrid.clearSort();
    this.treeGrid.deselectAllRows();

    this.objectElementsService
      .getSelectedElements({
        certificate: this.certificateId, //TODO
        operation: this.registerObjectId,
      })
      .subscribe((data) => {
        this.treeGrid.selectRows(data, true);
      });
  }

  private buildOperationsTree(
    data: RegisterObjectElementModel[],
    operationId: number
  ) {
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
}
