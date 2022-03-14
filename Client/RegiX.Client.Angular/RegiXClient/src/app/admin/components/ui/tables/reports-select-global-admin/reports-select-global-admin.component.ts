import { OidcSecurityService } from 'angular-auth-oidc-client';
import {
  Component,
  OnInit,
  Input,
  ChangeDetectorRef,
  Injector,
  SimpleChanges,
} from '@angular/core';
import { ComponentWithForm, DisplayValueFilteringOperand } from '@tl/tl-common';
import { ReportModel } from 'src/app/core/models/dto/report.model';
import { ReportsService } from 'src/app/core/services/rest/reports.service';
import { FormGroup } from '@angular/forms';
import { ESourceTable } from 'src/app/admin/enums/source.table.enum';
import { RolesToReportService } from 'src/app/core/services/rest/ropes-to-report.service';
import { UsersToReportService } from 'src/app/core/services/rest/users-to-report.service';
import { DisplayValueFormatService } from 'src/app/core/services/display-value-format.service';
import { HttpParams } from '@angular/common/http';
import { map } from 'rxjs/operators';
import { UserToReportModel } from 'src/app/core/models/dto/user-to-report.model';
import { RoleToReportModel } from 'src/app/core/models/dto/role-to-report.model';
import { LoginService } from 'src/app/core/services/login.service';

@Component({
  selector: 'app-reports-select-global-admin',
  templateUrl: './reports-select-global-admin.component.html',
  styleUrls: ['./reports-select-global-admin.component.scss'],
})
export class ReportsSelectGlobalAdminComponent extends ComponentWithForm<
  ReportModel,
  ReportsService
> {
  public displayValueFilteringOperand = DisplayValueFilteringOperand.instance();

  @Input()
  formGroup: FormGroup;

  @Input()
  sourceTable: ESourceTable;

  @Input()
  title = 'Услуги';

  @Input()
  administrationId: number;

  @Input()
  isCreateForm: boolean;

  objectId: number = null;
  role: string;

  changeDetectorRef: ChangeDetectorRef;

  isDataLoading = false;
  isDataLoaded = false;

  constructor(
    service: ReportsService,
    private rolesToReportService: RolesToReportService,
    private usersToReportService: UsersToReportService,
    private oidcSecurityService: OidcSecurityService,
    injector: Injector,
    public displayValueService: DisplayValueFormatService
  ) {
    super(service, injector);
    this.oidcSecurityService.userData$.subscribe((userData) => {
      this.role = userData.role;
    });
    this.changeDetectorRef = this.injector.get<ChangeDetectorRef>(
      ChangeDetectorRef as any

    );
  }

  ngOnInitImpl() {

  }

  ngOnChanges(changes: SimpleChanges) {
    // You can also use administrationId.previousValue and
    // administrationId.firstChange for comparing old and new values

    this.readReportsByAdministration(changes);
  }

  public readData(params?: HttpParams) {
    this.service.getAllNoWrap(params).subscribe((data: ReportModel[]) => {
      const obj = Object(data);
      this.dataBehavior.next(obj);
    });
  }

  private readReportsByAdministration(changes: SimpleChanges) {
    const filteringParam =
      'authority.id eq ' + changes.administrationId.currentValue;
    let params = new HttpParams();
    params = params.append('$filter', filteringParam);
    if (this.administrationId !== undefined) {
      this.readData(params);
    }
  }

  protected initializeFilter() {
    this.activatedRoute.params.subscribe((params) => {
      const idField = params['ID'];
      if (idField) {
        this.objectId = idField;
        if(!this.isCreateForm){
          this.readSelectedOperations();
        }
      }
      //this.afterFilterInitialized();
    });
  }

  private readSelectedOperations() {
    if (this.objectId) {
      let httpParameters = new HttpParams();
      let idStr = null;
      if (this.sourceTable === ESourceTable.USERS) {
        idStr = 'UserId';
      } else if (this.sourceTable === ESourceTable.ROLES) {
        idStr = 'RoleId';
      } else {
        throw new Error('not implemented');
      }
      const filteringParam =
        idStr +
        ' eq ' +
        this.objectId +
        ' and report.authorityId eq ' +
        this.administrationId;
      httpParameters = httpParameters.append('$filter', filteringParam);

      this.isDataLoading = true;
      this.isDataLoaded = false;

      if (this.sourceTable === ESourceTable.ROLES) {
        this.readRolesToReports(httpParameters);
      } else if (this.sourceTable === ESourceTable.USERS) {
        this.readUsersToReports(httpParameters);
      }
    }
  }

  private readUsersToReports(httpParameters: HttpParams) {
    this.usersToReportService
      .getAllNoWrap(httpParameters)
      .pipe(
        map((items: UserToReportModel[]) => {
          return items.map((item) => {
            return item.report.id;
          });
        })
      )
      .subscribe((data) => {
        this.selectTableRows(data);
      });
  }

  private readRolesToReports(httpParameters: HttpParams) {
    this.rolesToReportService
      .getAllNoWrap(httpParameters)
      .pipe(
        map((items: RoleToReportModel[]) => {
          return items.map((item) => {
            return item.report.id;
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

  showAuditValues(item: ReportModel, cell?) {}

  onShowMenuSelected(event) {}

  onRowClickChange(event) {
    console.log(event);
    this.formGroup.markAllAsTouched();
    this.formGroup.markAsDirty();
  }
}
