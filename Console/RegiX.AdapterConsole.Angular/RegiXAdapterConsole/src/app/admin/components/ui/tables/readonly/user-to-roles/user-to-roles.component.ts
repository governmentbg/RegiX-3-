import { Component, Input, Injector } from '@angular/core';
import { RemoteComponentWithForm } from '@tl/tl-common';
import { FormGroup } from '@angular/forms';
import { HttpParams } from '@angular/common/http';
import { RoleModel } from 'src/app/core/models/dto/role.model';
import { RolesService } from 'src/app/core/services/rest/roles.service';
import { UsersToRoleService } from 'src/app/core/services/rest/users-to-role.service';
import { UserToRolesGridRemoteFilteringService } from 'src/app/core/services/user-to-roles-grid-remote-filtering.service';

@Component({
  selector: 'app-user-to-roles',
  templateUrl: './user-to-roles.component.html',
  styleUrls: ['./user-to-roles.component.scss'],
})
export class UserToRolesComponent extends RemoteComponentWithForm<
  RoleModel,
  RolesService
> {
  @Input()
  formGroup: FormGroup;

  @Input()
  isShowForm: boolean;
  
  constructor(
    service: RolesService,
    injector: Injector,
    private usersToRoleService: UsersToRoleService
  ) {
    super(service, injector);
  }

  ngOnInitImpl() {}

  protected createRemoteService() {
    this.remoteService = new UserToRolesGridRemoteFilteringService(
      null,
      this.service,
      this.grid,
      this.injector,
      this.usersToRoleService,
      this.activatedRoute
    );
  }

  getExtendedParameters(params?: HttpParams) {
    this.logger.debug('READ DATA IN REMOTE');
    const filteringParams = null; //this.getFilterExpression();
    let httpParameters = params;
    if (filteringParams) {
      if (!httpParameters) {
        httpParameters = new HttpParams();
      }
      httpParameters = httpParameters.append('$filter', filteringParams);
    }
    this.logger.debug('httpParameters', httpParameters);
    return httpParameters;
  }

  onRowClickChange(event) {
    if (this.isShowForm) {
      event.newSelection = event.oldSelection;
    } else {
      console.log(event);
      this.formGroup.markAllAsTouched();
      this.formGroup.markAsDirty();
    }
  }
}
