import {
  Component,
  OnInit,
  Input,
  ChangeDetectorRef,
  Injector
} from '@angular/core';
import { UsersModel } from 'src/app/core/models/dto/users.model';
import { UsersService } from 'src/app/core/services/rest/users.service';
import { FormGroup } from '@angular/forms';
import { RemoteComponentWithForm} from '@tl/tl-common';
import { UsersToRoleService } from 'src/app/core/services/rest/users-to-role.service';
import { GridRemoteFilteringService} from '@tl/tl-common';
import { HttpParams } from '@angular/common/http';
import { UserToRoleModel } from 'src/app/core/models/dto/user-to-role.model';
import { map } from 'rxjs/operators';
import { ESourceTable } from 'src/app/admin/enums/source.table.enum';
import { UsersToReportService } from 'src/app/core/services/rest/users-to-report.service';
import { UserToReportModel } from 'src/app/core/models/dto/user-to-report.model';
import { ComponentWithForm } from '@tl/tl-common';

@Component({
  selector: 'app-users-select',
  templateUrl: './users-select.component.html',
  styleUrls: ['./users-select.component.scss']
})
export class UsersSelectComponent extends ComponentWithForm<
  UsersModel,
  UsersService
> {
  @Input()
  formGroup: FormGroup;

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

  public readData(params?: HttpParams) {
    this.service.getAllNoWrap(params).subscribe((data: UsersModel[]) => {
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
      this.afterFilterInitialized();
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
      const filteringParam = idStr + ' eq ' + this.objectId;
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
          return items.map(item => {
            return item.user.id;
          });
        })
      )
      .subscribe(data => {
        this.selectTableRows(data);
      });
  }

  private readUsersToRoles(httpParameters: HttpParams) {
    this.userToRolesService
      .getAllNoWrap(httpParameters)
      .pipe(
        map((items: UserToRoleModel[]) => {
          return items.map(item => {
            return item.user.id;
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

  prepareForEdit(item: UsersModel, cell?) {}

  showAuditValues(item: UsersModel, cell?) {}

  prepareForCreate() {}

  prepareForShow(item: UsersModel, cell?) {}

  onShowMenuSelected(event) {}

  onRowClickChange(event) {
    this.formGroup.markAllAsTouched();
    this.formGroup.markAsDirty();
  }
}
