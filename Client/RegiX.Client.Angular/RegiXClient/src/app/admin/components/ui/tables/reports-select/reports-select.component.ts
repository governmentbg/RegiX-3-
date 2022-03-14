import { OidcSecurityService } from 'angular-auth-oidc-client';
import { Component, Injector, ChangeDetectorRef, Input, SimpleChanges, OnChanges } from '@angular/core';
import { DisplayValueFilteringOperand} from '@tl/tl-common';
import { RolesToReportService } from 'src/app/core/services/rest/ropes-to-report.service';
import { HttpParams } from '@angular/common/http';
import { map } from 'rxjs/operators';
import { RoleToReportModel } from 'src/app/core/models/dto/role-to-report.model';
import { ReportsService } from 'src/app/core/services/rest/reports.service';
import { ReportModel } from 'src/app/core/models/dto/report.model';
import { FormGroup } from '@angular/forms';
import { UsersToReportService } from 'src/app/core/services/rest/users-to-report.service';
import { UserToReportModel } from 'src/app/core/models/dto/user-to-report.model';
import { ESourceTable } from 'src/app/admin/enums/source.table.enum';
import { LoginService } from 'src/app/core/services/login.service';
import { ComponentWithForm } from '@tl/tl-common';
import { DisplayValueFormatService } from 'src/app/core/services/display-value-format.service';

@Component({
  selector: 'app-reports-select',
  templateUrl: './reports-select.component.html',
  styleUrls: ['./reports-select.component.scss']
})
export class ReportsSelectComponent extends ComponentWithForm<
  ReportModel,
  ReportsService
> implements OnChanges{
  public displayValueFilteringOperand = DisplayValueFilteringOperand.instance();
  
  @Input()
  formGroup: FormGroup;

  @Input()
  sourceTable: ESourceTable;

  @Input()
  authorityId: number;

  @Input()
  title = 'Операции';

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

    this.changeDetectorRef = this.injector.get<ChangeDetectorRef>(
      ChangeDetectorRef as any
    );
  }

  ngOnInitImpl() {
    this.oidcSecurityService.userData$.subscribe((userData) => {
      this.role = userData.role;
    });
  }

  ngOnChanges(changes: SimpleChanges) {
    this.authorityId = changes.authorityId.currentValue;
    this.readData();
    
  }

  public readData(params?: HttpParams) {
    let httpParameters = new HttpParams();
    if (this.authorityId != undefined) {
      const filteringParam = 'authority.id' + ' eq ' + this.authorityId;
      httpParameters = httpParameters.append('$filter', filteringParam);
    }


    this.service.getAllNoWrap(httpParameters).subscribe((data: ReportModel[]) => {
      const obj = Object(data);
      this.dataBehavior.next(obj);
    });
  }

  protected initializeFilter() {
    this.activatedRoute.params.subscribe(params => {
      const idField = params['ID'];
      if (idField) {
        this.objectId = idField;
        this.readSelectedOperations();
      }
      this.afterFilterInitialized();
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
      const filteringParam = idStr + ' eq ' + this.objectId;
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
          return items.map(item => {
            return item.report.id;
          });
        })
      )
      .subscribe(data => {
        this.selectTableRows(data);
      });
  }

  private readRolesToReports(httpParameters: HttpParams) {
    this.rolesToReportService
      .getAllNoWrap(httpParameters)
      .pipe(
        map((items: RoleToReportModel[]) => {
          return items.map(item => {
            return item.report.id;
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
    console.log(event);
    this.formGroup.markAllAsTouched();
    this.formGroup.markAsDirty();
  }
}
