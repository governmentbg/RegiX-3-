import { Component, OnInit, ViewChild, Injector } from '@angular/core';
import { UserFavouriteReportModel } from 'src/app/core/models/dto/user-favourite-report.model';
import { UsersFavouriteReportService } from 'src/app/core/services/rest/users-favourite-report.service';
import { FormComponent } from '@tl/tl-common';
import { ESourceTable } from 'src/app/admin/enums/source.table.enum';
import { UserToReportsComponent } from '../../ui/tables/readonly/user-to-reports/user-to-reports.component';
import { FormBuilder, FormGroup } from '@angular/forms';
import { UserFavouriteReportInModel } from 'src/app/core/models/dto/in/user-favourite-report.in.model';
import { Location } from '@angular/common';
import { LoginService } from 'src/app/core/services/login.service';
import { ReportsSelectComponent } from '../../ui/tables/reports-select/reports-select.component';
import { ToastService } from '@tl/tl-common';
import { Router } from '@angular/router';
import { ROUTES } from 'src/app/admin/routes/static-routes';

@Component({
  selector: 'app-favourite-reports',
  templateUrl: './favourite-reports.component.html',
  styleUrls: ['./favourite-reports.component.scss']
})
export class FavouriteReportsComponent implements OnInit {
  readonly FAVOURITE_REPORTS = ESourceTable.FAVOURITE_REPORTS;
  routes = ROUTES;
  errorMessage: string = null;
  isDataLoading = false;
  isDataLoaded = false;

  isPending = false;

  title = 'Предпочитани услуги';

  @ViewChild('reports', { static: true })
  reports: ReportsSelectComponent;

  constructor(
    private favouriteReportsService: UsersFavouriteReportService,
    private location: Location,
    private router: Router,
    private toastService: ToastService
  ) {}

  ngOnInit() {}

  createInputObject(): any {
    const users = new UserFavouriteReportInModel();
    users.reportIds = this.reports.grid.selectedRows();
    return users;
  }

  onCancel() {
    this.location.back();
  }

  onSave() {
    this.isPending = true;
    const inputObj = this.createInputObject();
    this.favouriteReportsService.save(inputObj).subscribe(
      data => {
        this.isPending = false;
        this.errorMessage = null;
        this.toastService.showMessage('Предпочитани услуги са запазени успешно!');
        ROUTES.HOME.navigate(this.router);
      },
      error => {
        this.isPending = false;
        this.toastService.showMessage(
          'Грешка при запазване на предпочитани услуги!'
        );
        this.errorMessage =
          'Грешка при запазване на предпочитани услуги: ' + error.message;
      }
    );
  }
}
