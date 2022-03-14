import { Component, OnInit, Input, ChangeDetectorRef, Injector, SimpleChanges } from '@angular/core';
import { ComponentWithForm, DisplayValueFilteringOperand } from '@tl/tl-common';
import { RoleModel } from 'src/app/core/models/dto/role.model';
import { RolesService } from 'src/app/core/services/rest/roles.service';
import { FormGroup } from '@angular/forms';
import { ESourceTable } from 'src/app/admin/enums/source.table.enum';
import { UsersToRoleService } from 'src/app/core/services/rest/users-to-role.service';
import { UsersToReportService } from 'src/app/core/services/rest/users-to-report.service';
import { RolesToReportService } from 'src/app/core/services/rest/ropes-to-report.service';
import { DisplayValueFormatService } from 'src/app/core/services/display-value-format.service';
import { HttpParams } from '@angular/common/http';
import { map } from 'rxjs/operators';
import { UserToRoleModel } from 'src/app/core/models/dto/user-to-role.model';
import { RoleToReportModel } from 'src/app/core/models/dto/role-to-report.model';

@Component({
  selector: 'app-roles-select-global-admin',
  templateUrl: './roles-select-global-admin.component.html',
  styleUrls: ['./roles-select-global-admin.component.scss']
})
export class RolesSelectGlobalAdminComponent extends ComponentWithForm<
RoleModel,
RolesService
> {
public displayValueFilteringOperand = DisplayValueFilteringOperand.instance();

@Input()
formGroup: FormGroup;

@Input()
sourceTable: ESourceTable;

@Input()
  administrationId: number;

@Input()
title = 'Роли';

isDataLoading = false;
isDataLoaded = false;

objectId: number = null;
changeDetectorRef: ChangeDetectorRef;

constructor(
  service: RolesService,
  private userToRolesService: UsersToRoleService,
  private userToReportsService: UsersToReportService,
  private rolesToReportService: RolesToReportService,
  injector: Injector,
  public displayValueService: DisplayValueFormatService
) {
  super(service, injector);

  this.changeDetectorRef = this.injector.get<ChangeDetectorRef>(
    ChangeDetectorRef as any
  );
}

ngOnInitImpl() {
  // this.grid.sortingExpressions = [
  //   { fieldName: 'name', dir: SortingDirection.Asc }
  // ];
}

ngOnChanges(changes: SimpleChanges) {
  // You can also use administrationId.previousValue and
  // administrationId.firstChange for comparing old and new values
  this.readRolesByAdministration(changes);
}

private readRolesByAdministration(changes: SimpleChanges) {
  const filteringParam = 'authority.id eq ' + changes.administrationId.currentValue;
  let params = new HttpParams();
  params = params.append('$filter', filteringParam);
  if (this.administrationId !== undefined) {
    this.readData(params);
  }
}

public readData(params?: HttpParams) {
  this.service.getAllNoWrap(params).subscribe((data: RoleModel[]) => {
    const obj = Object(data);
    this.dataBehavior.next(obj);
  });
}

protected initializeFilter() {
  this.activatedRoute.params.subscribe(params => {
    const idField = params['ID'];
    if (idField) {
      this.objectId = idField;
      this.readSelectedRoles();
    }
    //this.afterFilterInitialized();
  });
}

private readSelectedRoles() {
  if (this.objectId) {
    let httpParameters = new HttpParams();
    let idStr = null;
    if (this.sourceTable === ESourceTable.USERS) {
      idStr = 'UserId';
    } else if (this.sourceTable === ESourceTable.REPORTS) {
      idStr = 'ReportId';
    } else {
      throw new Error('not implemented');
    }
    const filteringParam = idStr + ' eq ' + this.objectId;
    httpParameters = httpParameters.append('$filter', filteringParam);

    this.isDataLoading = true;
    this.isDataLoaded = false;

    if (this.sourceTable === ESourceTable.USERS) {
      this.readUsersToRoles(httpParameters);
    } else {
      //this.readUsersToReports(httpParameters);
      this.readRolesToReport(httpParameters);
    }
  }
}


private readUsersToRoles(httpParameters: HttpParams) {
  this.userToRolesService
    .getAllNoWrap(httpParameters)
    .pipe(
      map((items: UserToRoleModel[]) => {
        return items.map(item => {
          return item.role.id;
        });
      })
    )
    .subscribe(data => {
      this.selectTableRows(data);
    });
}

private readRolesToReport(httpParameters: HttpParams) {
  this.rolesToReportService
    .getAllNoWrap(httpParameters)
    .pipe(
      map((items: RoleToReportModel[]) => {
        return items.map(item => {
          return item.role.id;
        });
      })
    )
    .subscribe(data => {
      this.selectTableRows(data);
    });
}

private selectTableRows(data) {

  this.isDataLoading = false;
  this.isDataLoaded = true;

  this.grid.selectRows(data, true);
  this.changeDetectorRef.detectChanges();
}

showAuditValues() {}

onShowMenuSelected() {}

onRowClickChange(event) {
  console.log('event', event);
  this.formGroup.markAllAsTouched();
  this.formGroup.markAsDirty();
}
}

