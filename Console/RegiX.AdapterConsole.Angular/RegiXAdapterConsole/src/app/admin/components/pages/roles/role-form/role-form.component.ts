import { Component, Injector, ViewChild } from '@angular/core';
import { FormComponent } from '@tl/tl-common';
import { RolesService } from 'src/app/core/services/rest/roles.service';
import { RoleModel } from 'src/app/core/models/dto/role.model';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { RoleInModel } from 'src/app/core/models/dto/in/role.in.model';
import { ReportsSelectComponent } from '../../../ui/tables/reports-select/reports-select.component';

@Component({
  selector: 'app-role-form',
  templateUrl: './role-form.component.html',
  styleUrls: ['./role-form.component.scss']
})
export class RoleFormComponent extends FormComponent<RoleModel, RolesService> {
  @ViewChild('roleReports')
  roleReports: ReportsSelectComponent;

  constructor(
    private formBuilder: FormBuilder,
    service: RolesService,
    injector: Injector
  ) {
    super(service, injector);
  }

  buildFormImpl(): FormGroup {
    return this.formBuilder.group({
      name: [
        { value: '', disabled: this.isShowForm() },
        [Validators.required, Validators.minLength(4)]
      ],
      id: [{ value: '', disabled: true }]
    });
  }

  createInputObject(object: RoleModel): any {
    const roles = new RoleInModel(object);
    roles.reportIds = this.roleReports.grid.selectedRows();
    return roles;
  }

  ngOnInitImplementation() {
    //setting the appropriate flags for create form
    if (!this.isShowForm() && !this.isEditForm()) {
      super.onBaseServiceLoaded();
    }
  }
}
