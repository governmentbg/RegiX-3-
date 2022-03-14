import { Component, ViewChild, Injector } from '@angular/core';
import { FormComponent } from '@tl/tl-common';
import { UsersModel } from 'src/app/core/models/dto/users.model';
import { UsersService } from 'src/app/core/services/rest/users.service';
import { UserToRolesComponent } from 'src/app/admin/components/ui/tables/readonly/user-to-roles/user-to-roles.component';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { UserInModel } from 'src/app/core/models/dto/in/user.in.model';
import { UserToReportsComponent } from '../../../ui/tables/readonly/user-to-reports/user-to-reports.component';
import { ESourceTable } from 'src/app/admin/enums/source.table.enum';
import { IgxDialogComponent } from 'igniteui-angular';
import { AdministrationsFilterComponent } from 'src/app/shared/components/administrations-filter/administrations-filter.component';
import { DisplayValue } from 'src/app/core/models/display-value.model';

@Component({
  selector: 'app-user-form',
  templateUrl: './user-form.component.html',
  styleUrls: ['./user-form.component.scss'],
})
export class UserFormComponent extends FormComponent<UsersModel, UsersService> {
  readonly USERS_TABLE = ESourceTable.USERS;

  @ViewChild('administrationsFilterDialog')
  administrationsFilterDialog: IgxDialogComponent;
  @ViewChild('administrationsFilter')
  administrationsFilter: AdministrationsFilterComponent;

  @ViewChild('roles')
  roles: UserToRolesComponent;

  @ViewChild('reports')
  reports: UserToReportsComponent;

  public role: string;
  public authorityId: number;
  oidcSecurityService: any;

  constructor(
    private formBuilder: FormBuilder,
    service: UsersService,
    injector: Injector
  ) {
    super(service, injector);
  }

  buildFormImpl(): FormGroup {
    return this.formBuilder.group({
      name: [
        { value: '', disabled: this.isShowForm() },
        [Validators.required, Validators.minLength(5)],
      ],
      id: [{ value: '', disabled: true }],
      authority: this.formBuilder.group({
        displayName: [{ value: '', disabled: false }, [Validators.required]],
        id: [{ value: '', disabled: false }],
      }),
      userName: [
        { value: '', disabled: this.isShowForm() },
        [Validators.required],
      ],
      isActive: [{ value: '', disabled: this.isShowForm() }],
      email: [{ value: '', disabled: this.isShowForm() }],
      position: [{ value: '', disabled: this.isShowForm() }],
      modifiedBy: [{ value: '', disabled: true }],
      userRoles: [{ value: '', disabled: true }],
      modifiedOn: [{ value: '', disabled: true }],
      createdBy: [{ value: '', disabled: true }],
    });
  }

  protected prepareForEdit(object: UsersModel) {
    super.prepareForEdit(object);
    this.authorityId= this.formObject.authority.id;
    this.patchAdministration(object.authority);
    
  }

  createInputObject(object: UsersModel): any {
    const users = new UserInModel(object);
    users.authorityId = object.authority.id;
    users.roleIds = this.roles.grid.selectedRows();
    users.reportIds = this.reports.grid.selectedRows();
    return users;
  }

  ngOnInitImplementation() {}

  onCancel() {
    super.onCancel();
  }

  showAdministraions() {
    this.administrationsFilterDialog.open();
    this.administrationsFilter.loadFirstSection();
  }

  administrationsSelected(
    selectedItems: { id: number; name: string; data: any; key: string }[]
  ) {
    this.authorityId = selectedItems[0].id;
    this.administrationsFilterDialog.close();
    const oprDisplayValue = new DisplayValue({
      id: selectedItems[0].id,
      displayName: selectedItems[0].name,
    });
    this.patchAdministration(oprDisplayValue);
  }

  private patchAdministration(oprDisplayValue: DisplayValue) {
    this.formGroup.patchValue({
      authority: oprDisplayValue,
    });
    this.formGroup.markAsDirty();
  }
}
