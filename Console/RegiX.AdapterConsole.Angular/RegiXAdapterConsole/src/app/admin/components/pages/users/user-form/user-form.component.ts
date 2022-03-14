import { UserToRolesComponent } from 'src/app/admin/components/ui/tables/readonly/user-to-roles/user-to-roles.component';
import { Component, Injector, ViewChild } from '@angular/core';
import { FormComponent } from '@tl/tl-common';
import { UsersModel } from 'src/app/core/models/dto/users.model';
import { UsersService } from 'src/app/core/services/rest/users.service';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { UserInModel } from 'src/app/core/models/dto/in/user.in.model';

@Component({
  selector: 'app-user-form',
  templateUrl: './user-form.component.html',
  styleUrls: ['./user-form.component.scss']
})
export class UserFormComponent extends FormComponent<UsersModel, UsersService> {

  
  @ViewChild('roles')
  roles: UserToRolesComponent;

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
        [Validators.required, Validators.minLength(5)]
      ],
      id: [{ value: '', disabled: true }],
      userName: [
        { value: '', disabled: this.isShowForm() },
        [Validators.required]
      ],
      isActive: [{ value: '', disabled: this.isShowForm() }]
    });
  }

  createInputObject(object: UsersModel): any {
    const users = new UserInModel(object);
    users.roleIds = this.roles.grid.selectedRows();
    return users;
  }

  ngOnInitImplementation() {
    //setting the appropriate flags for create form
    if (!this.isShowForm() && !this.isEditForm()) {
      super.onBaseServiceLoaded();
    }
  }
}
