import { OidcSecurityService } from 'angular-auth-oidc-client';
import { Component, Injector, ViewChild } from '@angular/core';
import { FormComponent } from '@tl/tl-common';
import { RolesService } from 'src/app/core/services/rest/roles.service';
import { RoleModel } from 'src/app/core/models/dto/role.model';
import { DisplayValue } from 'src/app/core/models/display-value.model';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { ERoleTypes } from 'src/app/admin/enums/role-type.enum';
import { IgxSelectComponent, IgxDialogComponent } from 'igniteui-angular';
import { RoleInModel } from 'src/app/core/models/dto/in/role.in.model';
import { RolesToReportComponent } from '../../../ui/tables/readonly/roles-to-report/roles-to-report.component';
import { UsersSelectComponent } from '../../../ui/tables/users-select/users-select.component';
import { ESourceTable } from 'src/app/admin/enums/source.table.enum';
import { AdministrationsFilterComponent } from 'src/app/shared/components/administrations-filter/administrations-filter.component';
import { ReportsSelectGlobalAdminComponent } from '../../../ui/tables/reports-select-global-admin/reports-select-global-admin.component';

@Component({
  selector: 'app-role-form',
  templateUrl: './role-form.component.html',
  styleUrls: ['./role-form.component.scss']
})
export class RoleFormComponent extends FormComponent<RoleModel, RolesService> {

  readonly ROLES_TABLE = ESourceTable.ROLES;
  @ViewChild('administraionsFilterDialog')
  administraionsFilterDialog: IgxDialogComponent;
  @ViewChild('administrationsFilter')
  administrationsFilter: AdministrationsFilterComponent;

  @ViewChild('roleReports')
  roleReports: RolesToReportComponent;

  @ViewChild('roleOperations')
  roleOperations: ReportsSelectGlobalAdminComponent;

  @ViewChild('roleUsers')
  roleUsers: UsersSelectComponent;

  administrations: DisplayValue[] = [];
  roleTypes: { value: number; name: string }[] = [];

  public administrationId: number;
  public role: string;

  constructor(
    private formBuilder: FormBuilder,
    private oidcSecurityService : OidcSecurityService,
    service: RolesService,
    injector: Injector
  ) {
    super(service, injector);
    this.oidcSecurityService.userData$.subscribe((userData) => {
      this.role = userData.role;
    });

    this.roleTypes.push({ value: ERoleTypes.ADMIN, name: 'Администратор' });
    this.roleTypes.push({ value: ERoleTypes.BASIC, name: 'Нормална' });
    this.roleTypes.push({ value: ERoleTypes.PUBLIC, name: 'Публична' });
  }

  buildFormImpl(): FormGroup {
    return this.formBuilder.group({
      name: [
        { value: '', disabled: this.isShowForm() },
        [Validators.required, Validators.minLength(5)]
      ],
      id: [{ value: '', disabled: true }],
      authority: this.formBuilder.group({
        displayName: [{ value: '', disabled:  this.role === 'GLOBAL_ADMIN' ? false : true }, [Validators.required]],
        id: [{ value: '', disabled:  this.role === 'GLOBAL_ADMIN' ? false : true }],
      }),
      authorityName: [{ value: '', disabled: this.isShowForm() }],
      roleType: [
        { value: '', disabled: this.isShowForm() },
        [Validators.required]
      ],
      modifiedBy: [{ value: '', disabled: true }],
      modifiedOn: [{ value: '', disabled: true }],
      createdBy: [{ value: '', disabled: true }]
    });
  }

  createInputObject(object: RoleModel): any {
    const roles = new RoleInModel(object);
    roles.reportIds = this.roleOperations.grid.selectedRows();
    roles.userIds = this.roleUsers.grid.selectedRows();
    return roles;
  }

  ngOnInitImplementation() {
    this.oidcSecurityService.userData$.subscribe((userData) => {
      if (userData) {
        if (!this.administrationId) {
          this.administrationId = userData.AdministrationID;
        }
      }
    });
    this.isDataLoaded = true;
    this.isDataLoading = false;
  }


  onRowClickChange() {}

  administrationChanged() {
  }

  public setToNull(igxSelect: IgxSelectComponent, formControlName: string) {
    super.setToNull(igxSelect, formControlName);
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

  private patchAdministration(admDisplayValue: DisplayValue) {
    this.formGroup.patchValue({
      authority: admDisplayValue,
    });
    this.formGroup.markAsDirty();
  }
}
