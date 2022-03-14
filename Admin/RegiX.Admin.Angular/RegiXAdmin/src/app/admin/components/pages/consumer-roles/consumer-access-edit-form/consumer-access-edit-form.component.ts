import { Component, OnInit, OnDestroy, ViewChild } from "@angular/core";
import { IgxTreeGridComponent } from "igniteui-angular";
import { FormGroup, FormBuilder, Validators } from "@angular/forms";
import { DisplayValue } from "src/app/core/models/display-value.model";
import { AdapterOperationsService } from "src/app/core/services/rest/adapter-operations.service";
import { AdaptersService } from "src/app/core/services/rest/adapters.service";
import { RegistryService } from "src/app/core/services/rest/registry.service";
import { ActivatedRoute } from "@angular/router";
import { Location } from "@angular/common";
import { BackService } from '@tl/tl-common';
import { ToastService } from '@tl/tl-common';
import { AdapterOperationModel } from "src/app/core/models/dto/adapter-operation.model";
import { map } from "rxjs/operators";
import { AdapterModel } from "src/app/core/models/dto/adapters.model";
import { RegistryModel } from "src/app/core/models/dto/registy.model";
import { HttpParams } from "@angular/common/http";
import { RegisterObjectElementsService } from "src/app/core/services/rest/register-object-elements.service";
import { RegisterObjectElementModel } from "src/app/core/models/dto/register-object-element.model";
import { ConsumerRoleElementAccessService } from 'src/app/core/services/rest/consumer-role-element-access.service';
import { ConsumerRoleElementAccessInModel } from 'src/app/core/models/dto/in/consumer-role-element-access.in.model';
import { NGXLogger } from 'ngx-logger';
import { onTreeRowClickChange } from '../../certificates/access-edit-form/access-edit-form.component';
import { ROUTES } from 'src/app/admin/routes/static-routes';
import { ConsumerRoleService } from 'src/app/core/services/rest/consumer-role.service';

@Component({
  selector: "app-consumer-access-edit-form",
  templateUrl: "./consumer-access-edit-form.component.html",
  styleUrls: ["./consumer-access-edit-form.component.scss"]
})
export class ConsumerAccessEditFormComponent implements OnInit, OnDestroy {
  roleEditAccess = ROUTES.CONSUMER_ROLE_ACCESS_ID_ROLEID;
  subtitle: string;
  isLoading = false;

  @ViewChild("treeGrid", { static: true })
  treeGrid: IgxTreeGridComponent;

  pageTitle = "Редактиране на достъпа";

  formGroup: FormGroup = null;

  administration: DisplayValue;
  register: DisplayValue;
  adapter: DisplayValue;
  operation: DisplayValue;

  operationElements: any[] = [];
  selectedElements: number[] = [];

  adapterOperationId: number;

  errorMessage: string = null;

  registerObjectId: number = null;
  registerAdapterId: number = null;
  registerId: number = null;
  administrationId: number = null;
  consumerRoleId: number = null;

  constructor(
    private formBuilder: FormBuilder,
    private consumerRolesService: ConsumerRoleService,
    private adapterOperationsService: AdapterOperationsService,
    private adaptersService: AdaptersService,
    private registryService: RegistryService,
    private objectElementsService: RegisterObjectElementsService,
    private activatedRoute: ActivatedRoute,
    private location: Location,
    private consumerRoleElementAccessService: ConsumerRoleElementAccessService,
    private backService: BackService,
    private toastService: ToastService,
    private logger: NGXLogger
  ) {
    this.formGroup = this.buildForm();

    this.activatedRoute.params.subscribe(params => {
      this.adapterOperationId = params["ID"];
      this.consumerRoleId = params["ROLE_ID"];
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

              this.formGroup.patchValue({
                adapter: this.adapter.displayName,
                operation: this.operation.displayName
              });
              this.GetRegister();
            })
          )
          .subscribe();
      }
      if (this.consumerRoleId) {
        this.isLoading = true;
        this.consumerRolesService.find(this.consumerRoleId).subscribe(
          (data) => {
            this.isLoading = false;
            this.subtitle = `Роля "${data.name}"`;
          },
          () => {
            this.isLoading = false;
          }
        );
      }
    });
  }

  buildForm(): FormGroup {
    return this.formBuilder.group({
      administration: [{ value: null, disabled: true }],
      register: [{ value: null, disabled: true }],
      adapter: [{ value: null, disabled: true }],
      operation: [{ value: null, disabled: true }],
      //comments: [{ value: null, disabled: false }, [Validators.required]]
    });
  }

  ngOnInit() {
    this.backService.isBackVisible(true);
  }

  ngOnDestroy() {}

  hasValue(formControlName: string) {
    return this.formGroup.controls[formControlName].value !== null;
  }

  onRowClickChange($event) {
    onTreeRowClickChange(this.operationElements, $event, this.treeGrid);}

  onCancel() {
    this.location.back();
  }

  onSaveChanged() {
    if (this.isFormValid()) {
      const value = this.formGroup.getRawValue();
      const rows = this.treeGrid.selectedRows();
      const inModel: any = new ConsumerRoleElementAccessInModel({
        hasAccess: true,
        registerObjectElementIds: rows,
        consumerRoleId: this.consumerRoleId,
        adapterOperationId: this.adapterOperationId,
        //editAccessComment: value.comments,
      });
      this.consumerRoleElementAccessService.save(inModel).subscribe(
        data => {
          // this.createRowInUI(data);
          this.logger.debug("object inserted, refresh form or redirect", data);
          this.formGroup.markAsPristine();
          this.formGroup.markAsUntouched();
          this.errorMessage = null;
          this.toastService.showMessage("Достъпът до елементи е актуализиран!");
          this.location.back();
        },
        error => {
          this.errorMessage =
            "Грешка при актуализиране на достъп до елементи: " + error.error;
          this.toastService.showMessage(
            "Грешка при актуализиране на достъп до елементи!"
          );
        }
      );
    }
  }

  public isFormValid() {
    return true;
  }

  public isFormDirty() {
    return (
      this.treeGrid.selectedRows().length > 0
    );
  }

  resetForm() {
    this.treeGrid.deselectAllRows();
    this.formGroup.markAsPristine();
    this.formGroup.markAsUntouched();
    //this.formGroup.controls["comments"].setValue(null);
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
            register: this.register.displayName
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
            administration: this.administration.displayName
          });
          this.GetOperationElements();
        })
      )
      .subscribe();
  }

  private GetOperationElements() {
    let httpParameters = new HttpParams();

    const filteringParam = "registerObject.id eq " + this.registerObjectId;
    httpParameters = httpParameters.append("$filter", filteringParam);
    this.objectElementsService.getAllNoWrap(httpParameters).subscribe(data => {
      this.buildOperationsTree(data);
    });
    this.treeGrid.clearCellSelection();
    this.treeGrid.clearFilter();
    this.treeGrid.clearSearch();
    this.treeGrid.clearSort();
    this.treeGrid.deselectAllRows();

    this.objectElementsService
      .getSelectedConsumerRoleElements({
        role: this.consumerRoleId,
        operation: this.registerObjectId
      })
      .subscribe(data => {
        this.treeGrid.selectRows(data, true);
      });
  }

  private buildOperationsTree(
    data: RegisterObjectElementModel[]  ) {
    // let httpParameters = new HttpParams();
    // const filteringParam =
    //       'registerObject.id eq ' + operationId + ' and ';
    // httpParameters = httpParameters.append('$filter', filteringParam);

    const identifiers: any = {};
    data.forEach(element => {
      identifiers[element.pathToRoot] = element.id;
    });
    const objects: any[] = [];
    data.forEach(element => {
      const object = Object(element);
      let fKey = -1;
      object.primaryKey = element.id;
      const arr = element.pathToRoot.split(".");
      if (arr.length > 1) {
        // remove last element and join the array
        arr.splice(arr.length - 1, 1);
        const str = arr.join(".");
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
