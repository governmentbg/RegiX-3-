import { OidcSecurityService } from 'angular-auth-oidc-client';
import {
  Component,
  ChangeDetectorRef,
  Injector,
  Input,
  SimpleChanges, OnChanges
} from '@angular/core';
import { RoleModel } from 'src/app/core/models/dto/role.model';
import { RolesService } from 'src/app/core/services/rest/roles.service';
import { UsersToRoleService } from 'src/app/core/services/rest/users-to-role.service';
import { HttpParams } from '@angular/common/http';
import { UserToRoleModel } from 'src/app/core/models/dto/user-to-role.model';
import { map } from 'rxjs/operators';
import { FormGroup } from '@angular/forms';
import { ESourceTable } from 'src/app/admin/enums/source.table.enum';
import { ComponentWithForm, DisplayValueFilteringOperand } from '@tl/tl-common';
import { RolesToReportService } from 'src/app/core/services/rest/ropes-to-report.service';
import { RoleToReportModel } from 'src/app/core/models/dto/role-to-report.model';
import { DisplayValueFormatService } from 'src/app/core/services/display-value-format.service';

@Component({
  selector: 'app-roles-select',
  templateUrl: './roles-select.component.html',
  styleUrls: ['./roles-select.component.scss'],
})
export class RolesSelectComponent extends ComponentWithForm<
  RoleModel,
  RolesService
> implements OnChanges {
  public displayValueFilteringOperand = DisplayValueFilteringOperand.instance();

  @Input()
  formGroup: FormGroup;

  @Input()
  sourceTable: ESourceTable;

  @Input()
  authorityId: number;

  @Input()
  title = 'Роли';

  isDataLoading = false;
  isDataLoaded = false;
  role: string;

  objectId: number = null;
  changeDetectorRef: ChangeDetectorRef;

  constructor(
    service: RolesService,
    private userToRolesService: UsersToRoleService,
    private rolesToReportService: RolesToReportService,
    injector: Injector,
    public displayValueService: DisplayValueFormatService,
    private oidcSecurityService: OidcSecurityService
  ) {
    super(service, injector);

    this.changeDetectorRef = this.injector.get<ChangeDetectorRef>(
      ChangeDetectorRef as any
    );
  }

  ngOnChanges(changes: SimpleChanges) {
    this.authorityId = changes.authorityId.currentValue;
    this.readData();
    
  }

  ngOnInitImpl() {
    this.oidcSecurityService.userData$.subscribe((userData) => {
      this.role = userData.role;
    });
    // this.grid.sortingExpressions = [
    //   { fieldName: 'name', dir: SortingDirection.Asc }
    // ];
  }

  public readData(params?: HttpParams) {
    let httpParameters = new HttpParams();
    if (this.authorityId != undefined) {
      const filteringParam = 'authority.id' + ' eq ' + this.authorityId;
      httpParameters = httpParameters.append('$filter', filteringParam);
    }

    this.service.getAllNoWrap(httpParameters).subscribe((data: RoleModel[]) => {
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
      this.afterFilterInitialized();
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
          return items.map((item) => {
            return item.role.id;
          });
        })
      )
      .subscribe((data) => {
        this.selectTableRows(data);
      });
  }

  private readRolesToReport(httpParameters: HttpParams) {
    this.rolesToReportService
      .getAllNoWrap(httpParameters)
      .pipe(
        map((items: RoleToReportModel[]) => {
          return items.map((item) => {
            return item.role.id;
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

  showAuditValues() {}

  onShowMenuSelected() {}

  onRowClickChange(event) {
    console.log('event', event);
    this.formGroup.markAllAsTouched();
    this.formGroup.markAsDirty();
  }
}
