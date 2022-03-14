import { ConsumerAccessRequestsService } from './../../../../../../core/services/rest/consumer-access-requests.service';
import { ConsumerAccessRequestsModel } from 'src/app/core/models/dto/consumer-access-requests.model';
import { HierarchyModel } from './../../../../../../core/models/hierarchy.model';
import { Component, Injector, ViewChild } from '@angular/core';
import { FormComponent } from '@tl/tl-common';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { map } from 'rxjs/operators';
import { ROUTES } from 'src/app/admin/routes/static-routes';
import { HttpParams } from '@angular/common/http';
import { IgxTreeGridComponent, IRowSelectionEventArgs } from 'igniteui-angular';
import { RegisterObjectElementsService } from 'src/app/core/services/rest/register-object-elements.service';
import { RegisterObjectElementModel } from 'src/app/core/models/dto/register-object-element.model';
import { ConsumerRequestElementsService } from 'src/app/core/services/rest/consumer-request-elements.service';
import { ConsumerRequestElementsModel } from 'src/app/core/models/dto/consumer-request-elements.model';
import { onTreeRowClickChange } from '../../../certificates/access-edit-form/access-edit-form.component';
import { ConsumerRequestOperationsDbService } from 'src/app/core/services/rest/consumer-request-operation-db.service';
import { DisplayValue } from 'src/app/core/models/display-value.model';
import { OidcSecurityService } from 'angular-auth-oidc-client';
import { ApprovedRequestElementsService } from 'src/app/core/services/rest/approved-request-elements.service';
import { ApprovedRequestElementsModel } from 'src/app/core/models/dto/approved-request-elements.model';
import { ConsumerRequestOperationsInModel } from 'src/app/core/models/dto/in/consumer-request-operations.in.model';

@Component({
  selector: 'app-consumer-request-operations-form',
  templateUrl: './consumer-request-operations-form.component.html',
  styleUrls: ['./consumer-request-operations-form.component.scss'],
})
export class ConsumerRequestOperationsFormComponent extends FormComponent<
  ConsumerAccessRequestsModel,
  ConsumerAccessRequestsService
> {
  @ViewChild('treeGrid', { static: false })
  treeGrid: IgxTreeGridComponent;
  @ViewChild('treeGridEdit', { static: false })
  treeGridEdit: IgxTreeGridComponent;

  routes = ROUTES;
  statusEnums: DisplayValue[] = [
    { id: 0, displayName: 'Нов' },
    { id: 1, displayName: 'Входиран' },
    { id: 2, displayName: 'Отхвърлен' },
    { id: 3, displayName: 'Съгласувано' },
    { id: 4, displayName: 'Одобрен' },
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
      lawReason: [{ value: '', disabled: this.isShowForm() }],
      relatedServices: [{ value: '', disabled: this.isShowForm() }],
      relatedServicesCode: [{ value: '', disabled: this.isShowForm() }],
      comment: [{ value: '', disabled: this.isShowForm() }, [Validators.required]],
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
   let result = new ConsumerRequestOperationsInModel(object);
   result.comment = object.comment;
   //In consumerAccessRequest object  status prop contains old status value. consumerAccessRequestStatus contains the new value
  result.consumerAccessRequestStatus = object.status;
   // result.approvedRequestElementIds = this.treeGridEdit.selectedRows();
//result.consumerSystemCertiicateId = this.activatedRoute.snapshot.params['CON_SYS_ID'];
    //return result;
  }

  ngOnInitImplementation() {
    this.oidcSecurityService.userData$.subscribe((userData) => {
      if (userData) {
        this.currentUserRole = userData.role;
      }
    });
  }

  protected afterObjectReady() {
    this.isDataLoaded = false;
    this.isDataLoading = true;
    this.isEditable();
    //gets the hierarchy (Administration,Register,Adapter for current operation)
    this.readHierarchy();
    //gets all the elements of the operation
    this.getOperationElements();
    //gets all requested elements
    this.selectRequestedObjectElements(this.formObject.id);
    this.startingStatus = this.formObject.status;
    this.currentStatus = this.formObject.status;
    this.isDataLoaded = true;
    this.isDataLoading = false;
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
    let httpParameters = new HttpParams();
    const filteringParam =
      'registerObject.id eq ' +
      this.formObject.adapterOperation.registerObjectId;
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
      (this.formObject.status == 2 ||
        this.formObject.status == 4)
    ) {
      this.locationService.back();
    }
    if (
      !this.isShowForm() &&
      (this.formObject.status == 3 &&
        this.currentUserRole == "ADMIN") 
    ) {
      this.locationService.back();
    }
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
