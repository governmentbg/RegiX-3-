import { Component, OnInit } from '@angular/core';
import { UsersFavouriteReportService } from 'src/app/core/services/rest/users-favourite-report.service';
import { UserFavouriteReportModel } from 'src/app/core/models/dto/user-favourite-report.model';
import { ROUTES } from 'src/app/admin/routes/static-routes';
import { ReportsForUserService } from 'src/app/core/services/rest/reports-for-user.service';
import { map } from 'rxjs/operators';
import { ReportForUserModel } from 'src/app/core/models/dto/report-for-user.model';
import { DisplayValue } from 'src/app/core/models/display-value.model';
import { Routes, ActivatedRoute, Router } from '@angular/router';
import { Route } from '@angular/compiler/src/core';
import { ClientPermissions } from 'src/app/admin/permissions';


export class AdministrationLoader {
  reportsForUserService: ReportsForUserService;
  loaded = false;
  adminstrations = [];
  constructor(
    reportsForUserService: ReportsForUserService
    ) {
    this.reportsForUserService = reportsForUserService;
    this.reportsForUserService
      .getAllForUser()
      .pipe(
        map((items: ReportForUserModel[]) => {
          const arr: {id: number, displayName: string, tooltip: string} [] = [];
          items.forEach(item => {
            const foundItem = arr.find(d => d.id === item.authorityId);
            if (!foundItem) {
              arr.push(
                  {
                    id: item.authorityId,
                    displayName: item.authorityAcronym,
                    tooltip: item.authorityName
                  }
              );
            }
          });
          arr.sort((a, b) => {
            if (a.displayName > b.displayName) {
              return 1;
            }
            if (a.displayName < b.displayName) {
              return -1;
            }
            return 0;
          });
          return arr;
        })
      )
      .subscribe(
        data => {
          this.adminstrations = [];
          data.forEach( adm =>
              this.adminstrations.push(
                {
                  reference: ROUTES.REGISTERS,
                  args: {':ADM_ID': adm.id + ''},
                  title: adm.displayName,
                  tooltip: adm.tooltip
                }
              )
          );
          this.loaded = true;
        },
        error => {
          this.loaded = true;
        }
      );
  }
}

@Component({
  selector: 'app-home',
  templateUrl: './home.component.html',
  styleUrls: ['./home.component.scss'],
})
export class HomeComponent implements OnInit {
  favouriteReports: any[] = [];

  isDataLoading = false;
  isDataLoaded = false;
  errorMessage: string = null;
  public allRoutes = ROUTES;
  public routes = [
    {reference: ROUTES.SETTINGS},
    {reference: ROUTES.AUDIT},
  ];
  public operation = ROUTES.OPERATION;
  public admininistrationsLoader: AdministrationLoader;
  public clientPermissions = ClientPermissions;
  public settings = [
    {reference: ROUTES.ADMINISTRATIONS},
    {reference: ROUTES.USERS},
    {reference: ROUTES.ROLES},
    {reference: ROUTES.REPORTS}
  ];
  public auditReference = ROUTES.AUDIT;
  public audit = [
    {reference: ROUTES.AUDIT_DATA},
    {reference: ROUTES.SYSTEM_ERRORS},
    {reference: ROUTES.USER_ACTIONS},
    {reference: ROUTES.REPORT_EXECUTIONS}
  ];

  constructor(
    private router: Router,
    private activatedRoutes: ActivatedRoute,
    private favouriteReportsService: UsersFavouriteReportService,
    reportsForUserService: ReportsForUserService) {
    this.admininistrationsLoader = new AdministrationLoader(reportsForUserService);
  }

  mapFavouriteReports(data: UserFavouriteReportModel[]): any[] {
    return data.map((d) => {
      return {
        reference: ROUTES.OPERATION,
        args: {
          ':ADM_ID': d.authority.id + '',
          ':REG_ID': d.register.id + '',
          ':REPORT_ID': d.report.id,
        },
        title: d.report.displayName,
      };
    });
  }

  ngOnInit() {
    this.loadFavourites();
  }
  private loadFavourites() {
    this.isDataLoading = true;
    this.favouriteReportsService.getAllNoWrap().subscribe(
      (data) => {
        this.favouriteReports = this.mapFavouriteReports(data);
        this.isDataLoaded = true;
        this.isDataLoading = false;
        this.errorMessage = null;
      },
      (error) => {
        this.isDataLoaded = true;
        this.isDataLoading = false;
        this.errorMessage = error.message;
      }
    );
  }

  filterAdministrations(adm: any) {
    adm.reference.navigate(this.router, adm.args, this.activatedRoutes);
  }
  public searchWithClear(input: any) {
    if (input && input.value !== '') {
      ROUTES.SEARCH_RESULTS.navigate(
        this.router,
        { ':TERM': input.value },
        this.activatedRoutes
      );
      input.value = '';
    }
  }
  public favouritesChanged(event: any) {
    this.loadFavourites();
  }
}
