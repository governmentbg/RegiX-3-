import { Component, Input, ChangeDetectorRef, Injector } from '@angular/core';
import { RemoteComponentWithForm} from '@tl/tl-common';
import { ReportForUserModel } from 'src/app/core/models/dto/report-for-user.model';
import { ReportsForUserService } from 'src/app/core/services/rest/reports-for-user.service';
import { GridRemoteFilteringService} from '@tl/tl-common';
import { HttpParams } from '@angular/common/http';
import { UsersFavouriteReportService } from 'src/app/core/services/rest/users-favourite-report.service';
import { UserFavouriteReportModel } from 'src/app/core/models/dto/user-favourite-report.model';
import { map } from 'rxjs/operators';
import { SortingDirection } from 'igniteui-angular';
import { LoginService } from 'src/app/core/services/login.service';
import { ComponentWithForm } from '@tl/tl-common';

@Component({
  selector: 'app-reports-for-user-select',
  templateUrl: './reports-for-user-select.component.html',
  styleUrls: ['./reports-for-user-select.component.scss']
})
export class ReportsForUserSelectComponent extends ComponentWithForm<
  ReportForUserModel,
  ReportsForUserService
> {
  @Input()
  title = 'Услуги';

  objectId: number = null;

  changeDetectorRef: ChangeDetectorRef;

  isDataLoading = false;
  isDataLoaded = false;

  constructor(
    service: ReportsForUserService,
    private favouriteReports: UsersFavouriteReportService,
    private loginService: LoginService,
    injector: Injector
  ) {
    super(service, injector);

    this.changeDetectorRef = this.injector.get<ChangeDetectorRef>(
      ChangeDetectorRef as any
    );
  }

  public readData(params?: HttpParams) {
    this.service.getAllNoWrap(params).subscribe((data: ReportForUserModel[]) => {
      const obj = Object(data);
      this.dataBehavior.next(obj);
    });
  }

  ngOnInitImpl() {
    this.grid.sortingExpressions = [
      { fieldName: 'reportName', dir: SortingDirection.Asc }
    ];
    this.readSelectedUserReports();
  }

  // protected initializeFilter() {}

  private readSelectedUserReports() {
    // let httpParameters = new HttpParams();
    // const idStr = 'UserId';
    // const filteringParam = idStr + ' eq ' + this.loginService.user.id;
    // httpParameters = httpParameters.append('$filter', filteringParam);
    this.isDataLoading = true;
    this.isDataLoaded = false;

    this.readFavouriteReports();
  }

  private readFavouriteReports() {
    this.favouriteReports
      .getAllNoWrap()
      .pipe(
        map((items: UserFavouriteReportModel[]) => {
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

  prepareForEdit(item: ReportForUserModel, cell?) {}

  showAuditValues(item: ReportForUserModel, cell?) {}

  prepareForCreate() {}

  prepareForShow(item: ReportForUserModel, cell?) {}

  onShowMenuSelected(event) {}

  onRowClickChange(event) {
  }
}
