import {
  Component,
  OnInit,
  Input,
  ChangeDetectorRef,
  Injector,
  SimpleChanges,
} from '@angular/core';
import { ComponentWithForm } from '@tl/tl-common';
import { UsersModel } from 'src/app/core/models/dto/users.model';
import { UsersService } from 'src/app/core/services/rest/users.service';
import { FormGroup } from '@angular/forms';
import { ESourceTable } from 'src/app/admin/enums/source.table.enum';
import { UsersToRoleService } from 'src/app/core/services/rest/users-to-role.service';
import { UsersToReportService } from 'src/app/core/services/rest/users-to-report.service';
import { HttpParams } from '@angular/common/http';
import { map } from 'rxjs/operators';
import { UserToReportModel } from 'src/app/core/models/dto/user-to-report.model';
import { UserToRoleModel } from 'src/app/core/models/dto/user-to-role.model';

@Component({
  selector: 'app-users-select-global-admin',
  templateUrl: './users-select-global-admin.component.html',
  styleUrls: ['./users-select-global-admin.component.scss'],
})
export class UsersSelectGlobalAdminComponent extends ComponentWithForm<
  UsersModel,
  UsersService
> {
  @Input()
  formGroup: FormGroup;

  @Input()
  administrationId: number;

  @Input()
  sourceTable: ESourceTable;

  @Input()
  title = 'Потребители';

  objectId: number = null;
  changeDetectorRef: ChangeDetectorRef;

  isDataLoading = false;
  isDataLoaded = false;

  constructor(
    service: UsersService,
    private userToRolesService: UsersToRoleService,
    private userToReportsService: UsersToReportService,
    injector: Injector
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
    this.readUsersByAdministration(changes);
  }

  private readUsersByAdministration(changes: SimpleChanges) {
    const filteringParam = 'authorityId eq ' + changes.administrationId.currentValue;
    let params = new HttpParams();
    params = params.append('$filter', filteringParam);
    if (this.administrationId !== undefined) {
      this.readData(params);
    }
  }

  public readData(params?: HttpParams) {
    this.service.getAllNoWrap(params).subscribe((data: UsersModel[]) => {
      const obj = Object(data);
      this.dataBehavior.next(obj);
    });
  }

  protected initializeFilter() {
    this.activatedRoute.params.subscribe((params) => {
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
      if (this.sourceTable === ESourceTable.ROLES) {
        idStr = 'RoleId';
      } else if (this.sourceTable === ESourceTable.REPORTS) {
        idStr = 'ReportId';
      } else {
        throw new Error('not implemented');
      }
      const filteringParam = idStr + ' eq ' + this.objectId + ' and user.authorityId eq ' + this.administrationId;
      httpParameters = httpParameters.append('$filter', filteringParam);

      this.isDataLoading = true;
      this.isDataLoaded = false;

      if (this.sourceTable === ESourceTable.ROLES) {
        this.readUsersToRoles(httpParameters);
      } else {
        this.readUsersToReports(httpParameters);
      }
    }
  }

  private readUsersToReports(httpParameters: HttpParams) {
    this.userToReportsService
      .getAllNoWrap(httpParameters)
      .pipe(
        map((items: UserToReportModel[]) => {
          return items.map((item) => {
            return item.user.id;
          });
        })
      )
      .subscribe((data) => {
        this.selectTableRows(data);
      });
  }

  private readUsersToRoles(httpParameters: HttpParams) {
    this.userToRolesService
      .getAllNoWrap(httpParameters)
      .pipe(
        map((items: UserToRoleModel[]) => {
          return items.map((item) => {
            return item.user.id;
          });
        })
      )
      .subscribe((data) => {
        this.selectTableRows(data);
      });
  }

  private selectTableRows(data) {
    this.isDataLoading = false;
    this.isDataLoaded = true;

    this.grid.selectRows(data, true);
    this.changeDetectorRef.detectChanges();
  }

  onShowMenuSelected(event) {}

  onRowClickChange(event) {
    this.formGroup.markAllAsTouched();
    this.formGroup.markAsDirty();
  }
}
