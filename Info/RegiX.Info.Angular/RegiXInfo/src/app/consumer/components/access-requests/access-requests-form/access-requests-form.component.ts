import { DisplayValue } from './../../../models/display-value.model';
import { CertificateElementAccessService } from './../../../services/certificate-element-access.service';
import { ConsumerSystemCertificatesModel } from './../../../models/consumer-system-certificates.model';
import { ConsumerSystemCertificatesService } from './../../../services/consumer-system-certificates.service';
import { Component, ViewChild, Injector } from '@angular/core';
import { FormComponent } from '@tl/tl-common';
import { ConsumerAccessRequestsModel } from 'src/app/consumer/models/consumer-access-requests.model';
import { ConsumerAccessRequestsService } from 'src/app/consumer/services/consumer-access-requests.service';
import {
  IgxTreeGridComponent,
  IgxDialogComponent,
  IRowSelectionEventArgs,
} from 'igniteui-angular';
import { CONSUMER_ROUTES } from 'src/app/consumer/routes/consumer-static-routes';
import { FormGroup, FormBuilder, Validators } from '@angular/forms';
import { RegisterObjectElementsService } from 'src/app/consumer/services/register-object-elements.service';
import { HttpParams } from '@angular/common/http';
import { RegisterObjectElementModel } from 'src/app/consumer/models/register-object-element.model';
import { OperationFilterComponent } from '../../filters/operation-filter/operation-filter.component';
import { ConsumerSystemCertificatesFilterComponent } from '../../filters/consumer-system-certificates-filter/consumer-system-certificates-filter.component';
import { map } from 'rxjs/operators';
import { CertificateElementAccessModel } from 'src/app/consumer/models/certificate-element-access.model';
import { ConsumerAccessRequestsInModel } from 'src/app/consumer/models/in/consumer-access-requests.in.model';
import { ConsumerRequestElementsService } from 'src/app/consumer/services/consumer-request-elements.service';
import { ConsumerRequestElementsModel } from 'src/app/consumer/models/consumer-request-elements.model';
import { ConsumerRequestOperationsDbService } from 'src/app/consumer/services/consumer-request-operations-db.service';
import { HierarchyModel } from 'src/app/consumer/models/hierarchy.model';

export function findAllAncestors(
  operationElements: any[],
  children: any[],
  ancestors: any[]
) {
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

export function findAllDescendants(
  operationElements: any[],
  elements: any[],
  descendants: any[]
) {
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

export function onTreeRowClickChange(
  operationElements: any[],
  event: IRowSelectionEventArgs,
  treeGrid: IgxTreeGridComponent
) {
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
  selector: 'app-access-requests-form',
  templateUrl: './access-requests-form.component.html',
  styleUrls: ['./access-requests-form.component.scss'],
})
export class AccessRequestsFormComponent extends FormComponent<
  ConsumerAccessRequestsModel,
  ConsumerAccessRequestsService
> {
  @ViewChild('treeGrid', { static: false })
  treeGrid: IgxTreeGridComponent;

  routes = CONSUMER_ROUTES;

  consumerSystemCertiicateId: number;
  isCommentDisabled = true;

  operationElements: any[];
  hierarchyFormGroup: FormGroup;
  currentUserRole: string;
  adapterOperationId: number;

  @ViewChild('consumerSystemCertificatesFilterDialog')
  consumerSystemCertificatesFilterDialog: IgxDialogComponent;
  @ViewChild('consumerSystemCertificatesFilter')
  consumerSystemCertificatesFilter: ConsumerSystemCertificatesFilterComponent;

  @ViewChild('operationFilter')
  operationFilter: OperationFilterComponent;

  @ViewChild('primaryAdministrationsFilter', { static: true })
  primaryAdministrationsFilter: IgxDialogComponent;

  formGroupAdministrations: FormGroup = null;
  formGroupAdministrationsKeys = {
    registerAdministration: {
      title: 'Администрация',
      icon: 'account_balance',
    },
    register: {
      title: 'Регистър',
      icon: 'dashboard',
    },
    adapter: {
      title: 'Адаптер',
      icon: 'developer_board',
    },
    adapterOperation: {
      title: 'Операция',
      icon: 'receipt',
    },
  };
  formGroupAdministrationsKeysArray = Object.keys(
    this.formGroupAdministrationsKeys
  );
  isFormGroupAdministrationsActive = true;

  constructor(
    private formBuilder: FormBuilder,
    service: ConsumerAccessRequestsService,
    private registerObjectElementsService: RegisterObjectElementsService,
    private consumerSystemCertificatesService: ConsumerSystemCertificatesService,
    private certificateElementAccessService: CertificateElementAccessService,
    private consumerRequestElementsService: ConsumerRequestElementsService,
    private consumerRequestOperationsDbService: ConsumerRequestOperationsDbService,
    injector: Injector
  ) {
    super(service, injector);
  }

  buildFormImpl(): FormGroup {
    this.formGroupAdministrations = this.buildAdministrationsForm();

    return this.formBuilder.group({
      id: [{ value: '', disabled: true }],
      lawReason: [{ value: '', disabled: this.isShowForm() },[Validators.required]],
      status: [{ value: '', disabled: this.isShowForm() }],
      relatedServices: [{ value: '', disabled: this.isShowForm() },[Validators.required]],
      relatedServicesCode: [{ value: '', disabled: this.isShowForm() }],
      consumerSystemCertificate: this.formBuilder.group({
        displayName: [{ value: '', disabled: true },[Validators.required]],
        id: [{ value: '', disabled: true }],
      }),
      adapterOperation: this.formBuilder.group({
        registerObjectId: [{ value: '', disabled: true }],
        displayName: [{ value: '', disabled: true }],
        id: [{ value: '', disabled: true }],
      }),
      consumerRequest: this.formBuilder.group({
        displayName: [{ value: '', disabled: true }],
        id: [{ value: '', disabled: true }], 
        status: [{ value: '', disabled: true }],
      }),
    });
  }

  createInputObject(object: ConsumerAccessRequestsModel): any {

    let result = new ConsumerAccessRequestsInModel(object);
    result.elementsIds = this.treeGrid.selectedRows();
    result.consumerRequestId = this.activatedRoute.snapshot.params['REQ_ID'];
    return result;
  }

  ngOnInitImplementation() {
    this.isDataLoaded = true;
    this.isDataLoading = false;
  }
  isFormValid(){
    if(this.isCreateForm()){
      return this.formGroup.dirty && this.formGroup.valid && this.formGroupAdministrations.touched;
    }
    return this.formGroup.dirty && this.formGroup.valid
  }
  protected afterObjectReady() {
    if (this.isShowForm()) {
      this.readHierarchy();
      this.getOperationElements(this.formGroup.controls['adapterOperation'].value.registerObjectId);
      this.selectRequestedObjectElements(this.formGroup.controls['id'].value)
    }
  }

  protected onBaseServiceLoaded() {
    // do nothing if in edit or create mode, let the additional operations
    // do their work and set the appropriate flags
    if (this.isShowForm()) {
      super.onBaseServiceLoaded();
    }
  }

  private getOperationElements(registerObjectId: number) {
    let httpParameters = new HttpParams();
    const filteringParam = 'registerObject.id eq ' + registerObjectId;
    httpParameters = httpParameters.append('$filter', filteringParam);

    this.registerObjectElementsService
      .getAllNoWrap(httpParameters)
      .subscribe((data) => {
        this.buildOperationsTree(data);
      });
  }

  private buildOperationsTree(data: RegisterObjectElementModel[]) {
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

  private buildAdministrationsForm(): FormGroup {
    const res = {};
    Object.keys(this.formGroupAdministrationsKeys).forEach(
      (k) => (res[k] = [{ value: '', disabled: true },[Validators.required]])
    );
    return this.formBuilder.group(res);
  }

  openPrimaryAdministraionsForm() {
    if (this.isFormGroupAdministrationsActive) {
      this.toastService.showMessage('Моля изберете сертификат !');
    } else {
      this.primaryAdministrationsFilter.open();
      this.operationFilter.loadFirstSection();
    }
  }

  operationSelected(
    selectedItems: { id: number; name: string; data: any; key: string }[]
  ) {
    this.primaryAdministrationsFilter.close();
    this.formGroupAdministrationsKeysArray.forEach((k) => {
      this.formGroupAdministrations.controls[k].setValue('');
    });
    selectedItems.forEach((element) => {
      this.formGroupAdministrations.controls[element.key].setValue(
        element.name
      );
    });
    this.formGroupAdministrations.markAsDirty();
    this.getOperationElements(selectedItems[3].data);
    this.adapterOperationId = selectedItems[3].id;
    this.getCertificateAccess();//test it

    let currentAdapterOperation = new DisplayValue();
    currentAdapterOperation.id = selectedItems[3].id;
    currentAdapterOperation.displayName = selectedItems[3].name;
    this.formGroup.patchValue({
      adapterOperation: currentAdapterOperation,
    });
    this.formGroupAdministrations.markAsTouched()
   
  }

  showConsumerSystemCertificates() {
    this.consumerSystemCertificatesFilterDialog.open();
    this.consumerSystemCertificatesFilter.loadFirstSection();
  }

  consumerSystemCertificatesSelected(
    selectedItems: { id: number; name: string; data: any; key: string }[]
  ) {
    this.consumerSystemCertificatesFilterDialog.close();
    this.isFormGroupAdministrationsActive = false;
    const admDisplayValue = new DisplayValue({
      id: selectedItems[0].id,
      displayName: selectedItems[0].name,
    });
    this.patchConsumerSystemCertificates(admDisplayValue);
  }

  private patchConsumerSystemCertificates(admDisplayValue: DisplayValue) {
    this.formGroup.patchValue({
      consumerSystemCertificate: admDisplayValue,
    });
    this.formGroup.markAsDirty();
  }

  private getCertificateAccess() {
    let consumerSystemCertificateId = this.formGroup.controls['consumerSystemCertificate'].value.id;

    this.certificateElementAccessService
      .GetCertificateElementAccess(
        this.adapterOperationId,
        consumerSystemCertificateId
      )
      .pipe(
        map((items: CertificateElementAccessModel[]) => {
          return items.map((item) => {
            return item.registerObjectElement.id;
          });
        })
      )
      .subscribe(
        data => {
          this.treeGrid.selectRows(data,true);
        }
      );
  }

  private selectRequestedObjectElements(data: number) {
    const filter = `consumerAccessRequestId eq ${data}`;

    let httpParameters = new HttpParams();
    httpParameters = httpParameters.append('$filter', filter);

    this.consumerRequestElementsService
      .getAllNoWrap(httpParameters)
      .pipe(
        map((items: ConsumerRequestElementsModel[]) => {
          return items.map((item) => {
            return item.registerObjectElement.id; //returns registerObjectElement id
          });
        })
      )
      .subscribe((data: number[]) => {
        this.treeGrid.selectRows(data, true);
      });
  }
  //TODO: Add operation name and disable tree grid 
  private readHierarchy() {
    this.consumerRequestOperationsDbService
      .find(this.formObject.adapterOperation.id)
      .subscribe((data: HierarchyModel) => {
        this.formGroupAdministrations.patchValue({
          registerAdministration: data.administrationName,
          register: data.registerName,
          adapter: data.adapterName,
          adapterOperation: this.formObject.adapterOperation.displayName
        });
      });
  }

  onRowClickChangeEditDisable(e) {
    //Disable the grid
    if (e.event) {
      e.newSelection = e.oldSelection;
    }
  }

  onRowClickChangeEditEnable(event: IRowSelectionEventArgs) {
    onTreeRowClickChange(this.operationElements, event, this.treeGrid);
  }
}
