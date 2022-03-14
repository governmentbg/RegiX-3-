import { Component, Injector, ViewChild } from '@angular/core';
import { FormComponent } from '@tl/tl-common';
import { DisplayValue } from 'src/app/core/models/display-value.model';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { ReportModel } from 'src/app/core/models/dto/report.model';
import { ReportsService } from 'src/app/core/services/rest/reports.service';
import { ReportInModel } from 'src/app/core/models/dto/in/report.in.model';
import { ESourceTable } from 'src/app/admin/enums/source.table.enum';
import { RolesSelectComponent } from '../../../ui/tables/roles-select/roles-select.component';
import { UsersSelectComponent } from '../../../ui/tables/users-select/users-select.component';
import { IgxDialogComponent } from 'igniteui-angular';
import { OidcSecurityService } from 'angular-auth-oidc-client';
import { AdministrationsFilterComponent } from 'src/app/shared/components/administrations-filter/administrations-filter.component';
import { OperationsFilterComponent } from '../../filters/operations-filter/operations-filter.component';

@Component({
  selector: 'app-report-form',
  templateUrl: './report-form.component.html',
  styleUrls: ['./report-form.component.scss'],
})
export class ReportFormComponent extends FormComponent<
  ReportModel,
  ReportsService
> {
  @ViewChild('administraionsFilterDialog')
  administraionsFilterDialog: IgxDialogComponent;
  @ViewChild('administrationsFilter')
  administrationsFilter: AdministrationsFilterComponent;

  @ViewChild('operationsFilterDialog')
  operationsFilterDialog: IgxDialogComponent;
  @ViewChild('operationsFilter')
  operationsFilter: OperationsFilterComponent;

  @ViewChild('roles')
  roles: RolesSelectComponent;

  @ViewChild('users')
  users: UsersSelectComponent;

  readonly REPORTS_TABLE = ESourceTable.REPORTS;

  administrations: DisplayValue[] = [];
  operations: DisplayValue[] = [];
  adapterOperation: DisplayValue = new DisplayValue();
  public administrationId: number;
  public role: string;

  constructor(
    private formBuilder: FormBuilder,
    private oidcSecurityService: OidcSecurityService,
    service: ReportsService,
    injector: Injector
  ) {
    super(service, injector);
    this.oidcSecurityService.userData$.subscribe((userData) => {
      this.role = userData.role;
    });
  }

  buildFormImpl(): FormGroup {
    const formGroup = this.formBuilder.group({
      name: [
        { value: '', disabled: this.isShowForm() },
        [Validators.required, Validators.minLength(2)],
      ],
      id: [{ value: '', disabled: true }],
      code: [{ value: '', disabled: this.isShowForm() }, [Validators.required]],
      lawReason: [{ value: '', disabled: this.isShowForm() }],
      modifiedBy: [{ value: '', disabled: true }],
      modifiedOn: [{ value: '', disabled: true }],
      createdBy: [{ value: '', disabled: true }],
      isActive: [{ value: '', disabled: this.isShowForm() }],
      orderNumber: [{ value: '', disabled: this.isShowForm() }],
      adapterOperationName: [{ value: '', disabled: this.isShowForm() }],
      authorityName: [{ value: '', disabled: this.isShowForm() }],
      authority: this.formBuilder.group({
        displayName: [{ value: '', disabled: this.role == "GLOBAL_ADMIN" ? false : true },[Validators.required]],
        id: [{ value: '', disabled:  this.role == "GLOBAL_ADMIN" ? false : true }],
      }),
      adapterOperation: this.formBuilder.group({
        displayName: [{ value: '', disabled: false },[Validators.required]],
        id: [{ value: '', disabled: false }],
      },[Validators.required]),
    });
    return formGroup;
  }

  createInputObject(object: ReportModel): any {
    const report = new ReportInModel(object);
    report.roleIds = this.roles.grid.selectedRows();
    report.userIds = this.users.grid.selectedRows();
    return report;
  }

  ngOnInitImplementation() {
    this.isDataLoaded = true;
    this.isDataLoading = false;
    
  }

  protected prepareForCreate() {
    this.buildForm();
    this.operationName = 'Създаване на';
    this.formGroup.reset();
    this.oidcSecurityService.userData$.subscribe((userData) => {
      this.administrationId = +userData.AdministrationID;
    });
  }

  protected onBaseServiceLoaded() {
    // do nothing if in edit or create mode, let the additional operations
    // do their work and set the appropriate flags
    if (this.isShowForm()) {
      super.onBaseServiceLoaded();
    }
    if (this.isEditForm()) {
      this.administrationId = this.formObject.authority.id;
    }
  }


  showOperations() {
    this.operationsFilterDialog.open();
    this.operationsFilter.loadFirstSection();
  }

  operationSelected(
    selectedItems: { id: number; name: string; data: any; key: string }[]
  ) {
    this.operationsFilterDialog.close();
    const oprDisplayValue = new DisplayValue({
      id: selectedItems[2].id,
      displayName: selectedItems[2].name,
    });
    this.patchOperation(oprDisplayValue);
  }

  private patchOperation(oprDisplayValue: DisplayValue) {
    this.formGroup.patchValue({
      adapterOperation: oprDisplayValue,
    });
    this.formGroup.markAsDirty();
  }

  showAdministraions() {
    this.administraionsFilterDialog.open();
    this.administrationsFilter.loadFirstSection();
  }

  administraionSelected(
    selectedItems: { id: number; name: string; data: any; key: string }[]
  ) {
    this.administrationId = selectedItems[0].id;

    this.administraionsFilterDialog.close();
    const admDisplayValue = new DisplayValue({
      id: selectedItems[0].id,
      displayName: selectedItems[0].name,
    });
    this.patchAdministration(admDisplayValue);
  }

  private patchAdministration(admDisplayValue: DisplayValue) {
    this.formGroup.patchValue({
      authority: admDisplayValue,
    });
    this.formGroup.markAsDirty();
  }
}
