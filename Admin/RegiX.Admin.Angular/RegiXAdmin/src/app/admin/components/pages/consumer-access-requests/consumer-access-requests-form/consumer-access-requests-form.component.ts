import { Component, ViewChild, Injector, ChangeDetectorRef } from '@angular/core';
import { FormComponent } from '@tl/tl-common';
import { ConsumerAccessRequestsModel } from 'src/app/core/models/dto/consumer-access-requests.model';
import { ConsumerAccessRequestsService } from 'src/app/core/services/rest/consumer-access-requests.service';
import { IgxTreeGridComponent, IRowSelectionEventArgs } from 'igniteui-angular';
import { DisplayValue } from 'src/app/core/models/display-value.model';
import { FormGroup, FormBuilder, Validators } from '@angular/forms';
import { RegisterObjectElementsService } from 'src/app/core/services/rest/register-object-elements.service';
import { ConsumerRequestElementsService } from 'src/app/core/services/rest/consumer-request-elements.service';
import { ApprovedRequestElementsService } from 'src/app/core/services/rest/approved-request-elements.service';
import { ConsumerRequestOperationsDbService } from 'src/app/core/services/rest/consumer-request-operation-db.service';
import { OidcSecurityService } from 'angular-auth-oidc-client';
import { HierarchyModel } from 'src/app/core/models/hierarchy.model';
import { HttpParams } from '@angular/common/http';
import { map } from 'rxjs/operators';
import { ConsumerRequestElementsModel } from 'src/app/core/models/dto/consumer-request-elements.model';
import { ApprovedRequestElementsModel } from 'src/app/core/models/dto/approved-request-elements.model';
import { onTreeRowClickChange } from '../../certificates/access-edit-form/access-edit-form.component';
import { ROUTES } from 'src/app/admin/routes/static-routes';
import { RegisterObjectElementModel } from 'src/app/core/models/dto/register-object-element.model';
import { ConsumerAccessRequestsModelInModel } from 'src/app/core/models/dto/in/consumer-access-requests.in.model';
import { ConsumerAccessRequestsStatus } from 'src/app/admin/enums/consumer-access-requests-status.enum';

@Component({
  selector: 'app-consumer-access-requests-form',
  templateUrl: './consumer-access-requests-form.component.html',
  styleUrls: ['./consumer-access-requests-form.component.scss'],
})
export class ConsumerAccessRequestsFormComponent extends FormComponent<
  ConsumerAccessRequestsModel,
  ConsumerAccessRequestsService
> {
  @ViewChild('treeGrid', { static: false })
  treeGrid: IgxTreeGridComponent;
  @ViewChild('treeGridEdit', { static: false })
  treeGridEdit: IgxTreeGridComponent;

  routes = ROUTES;
  statusEnums: DisplayValue[] = [
    { id: 0, displayName: ConsumerAccessRequestsStatus.NEW },
    { id: 1, displayName: ConsumerAccessRequestsStatus.ENTERED },
    { id: 2, displayName: ConsumerAccessRequestsStatus.DECLINED },
    { id: 3, displayName: ConsumerAccessRequestsStatus.ACCEPTED },
    { id: 4, displayName: ConsumerAccessRequestsStatus.APPROVED },
  ];
  //change the status values
  startingStatus: number;
  currentStatus: number;
  consumerSystemCertiicateId: number;
  isCommentDisabled: boolean = true;

  operationElements: any[] = [];
  hierarchyFormGroup: FormGroup;
  currentUserRole: string;

  constructor(
    private formBuilder: FormBuilder,
    service: ConsumerAccessRequestsService,
    private registerObjectElementsService: RegisterObjectElementsService,
    private consumerRequestElementsService: ConsumerRequestElementsService,
    private approvedRequestElementsService: ApprovedRequestElementsService,
    private consumerRequestOperationsDbService: ConsumerRequestOperationsDbService,
    private oidcSecurityService: OidcSecurityService,
    injector: Injector
  ) {
    super(service, injector);
  }

  buildFormImpl(): FormGroup {
    let hierarchyFormBuilder = new FormBuilder();
    this.hierarchyFormGroup = hierarchyFormBuilder.group({
      administration: [{ value: null, disabled: true }],
      register: [{ value: null, disabled: true }],
      adapter: [{ value: null, disabled: true }],
    });

    return this.formBuilder.group({
      id: [{ value: '', disabled: true }],
      status: [{ value: '', disabled: this.isShowForm() }],
      lawReason: [{ value: '', disabled: true }],
      relatedServices: [{ value: '', disabled: true }],
      relatedServicesCode: [{ value: '', disabled: true }],
      comment: [
        { value: '', disabled: this.isShowForm() },
        [Validators.required],
      ],
      consumerRequest: this.formBuilder.group({
        displayName: [{ value: '', disabled: true }],
        id: [{ value: '', disabled: true }],
      }),
      consumerSystemCertificate: this.formBuilder.group({
        displayName: [{ value: '', disabled: true }],
        id: [{ value: '', disabled: true }],
      }),
      adapterOperation: this.formBuilder.group({
        displayName: [{ value: '', disabled: true }],
        id: [{ value: '', disabled: true }],
        registerObjectId: [{ value: '', disabled: true }],
        description: [{ value: '', disabled: true }],
      }),
    });
  }

  createInputObject(object: ConsumerAccessRequestsModel): any {
    let result = new ConsumerAccessRequestsModelInModel(object);
    result.comment = object.comment;
    // add anything ?
    result.approvedRequestElementIds = this.treeGridEdit.selectedRows();
    return result;
  }

  ngOnInitImplementation() {
    this.oidcSecurityService.userData$.subscribe((userData) => {
      if (userData) {
        this.currentUserRole = userData.role;
      }
    });
  }

  protected afterObjectReady() {
    this.isEditable();
    //gets the hierarchy (Administration,Register,Adapter for current operation)
    this.readHierarchy();
    //gets all the elements of the operation
    this.getOperationElements();
    //gets all requested elements
    this.selectRequestedObjectElements(this.formObject.id);
    this.startingStatus = this.formObject.status;
    this.currentStatus = this.formObject.status;
  }

  private readHierarchy() {
    this.consumerRequestOperationsDbService
      .find(this.formObject.adapterOperation.id)
      .subscribe((data: HierarchyModel) => {
        this.hierarchyFormGroup.patchValue({
          administration: data.administrationName,
          register: data.registerName,
          adapter: data.adapterName,
        });
      });
  }

  private getOperationElements() {
    this.isDataLoaded = false;
    this.isDataLoading = true;
    
    let httpParameters = new HttpParams();
    const filteringParam =
      'registerObject.id eq ' +
      this.formObject.adapterOperation.registerObjectId;
    httpParameters = httpParameters.append('$filter', filteringParam);

    this.registerObjectElementsService
      .getAllNoWrap(httpParameters)
      .subscribe((data) => {
        this.buildOperationsTree(data);
        this.isDataLoaded = true;
        this.isDataLoading = false;
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
        this.getApprovedElements(httpParameters);
      });
  }

  private getApprovedElements(httpParameters: HttpParams) {
    this.approvedRequestElementsService
      .getAllNoWrap(httpParameters)
      .pipe(
        map((items: ApprovedRequestElementsModel[]) => {
          return items.map((item) => {
            return item.registerObjectElement.id;
          });
        })
      )
      .subscribe((data: number[]) => {
        this.treeGridEdit.selectRows(data, true);
      });
  }

  private isEditable() {
    if (
      !this.isShowForm() &&
      (this.formObject.status == 2 || this.formObject.status == 4)
    ) {
      this.locationService.back();
    }
    if (
      !this.isShowForm() &&
      this.formObject.status == 3 &&
      this.currentUserRole == 'ADMIN'
    ) {
      this.locationService.back();
    }
  }

  moveAllToApproved(){
    this.treeGridEdit.selectRows(this.treeGrid.selectedRows());
  }

  onRowClickChangeEditDisable(e) {
    //Disable the grid
    if (e.event) {
      e.newSelection = e.oldSelection;
    }
  }

  onRowClickChangeEditEnable(event: IRowSelectionEventArgs) {
    onTreeRowClickChange(this.operationElements, event, this.treeGridEdit);
  }
}
