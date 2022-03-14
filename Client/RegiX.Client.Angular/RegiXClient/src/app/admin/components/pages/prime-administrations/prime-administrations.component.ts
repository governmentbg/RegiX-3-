import { Component, OnInit } from '@angular/core';
import { DisplayValue } from 'src/app/core/models/display-value.model';
import { ActivatedRoute, Router } from '@angular/router';
import { ReportsForUserService } from 'src/app/core/services/rest/reports-for-user.service';
import { ToastService, TLRouteReference, TlRouteArguments } from '@tl/tl-common';
import { HttpParams } from '@angular/common/http';
import { ReportForUserModel } from 'src/app/core/models/dto/report-for-user.model';
import { ROUTES } from 'src/app/admin/routes/static-routes';
import { ClientPermissions } from 'src/app/admin/permissions';

@Component({
  selector: 'app-prime-administrations',
  templateUrl: './prime-administrations.component.html',
  styleUrls: ['./prime-administrations.component.scss']
})
export class PrimeAdministrationsComponent implements OnInit {
  administrationRoute = ROUTES.ADMINISTRATIONS;
  administrationId: string = null;
  authorities: DisplayValue[] = [];
  registries: any = {};

  pageTitle = 'Администрации';

  isDataLoading = false;
  isDataLoaded = false;
  errorMessage: string = null;
  changingFavouirteStatus = false;
  changingId: number = null;
  clientPermissions = ClientPermissions;

  constructor(
    private router: Router,
    private activatedRoute: ActivatedRoute,
    private reportForUserService: ReportsForUserService,
    private toastService: ToastService
  ) {
    this.activatedRoute.params.subscribe(params => {
      console.log(params);
      this.administrationId = params['ADM_ID'];
      this.readAuthorities();
    });
  }

  ngOnInit() {}

  private readAuthorities() {
    this.authorities = [];
    let httpParameters = new HttpParams();
    if (this.administrationId && this.administrationId !== '-') {
      const filteringParam = 'authorityId eq ' + this.administrationId;
      httpParameters = httpParameters.append('$filter', filteringParam);
    }

    this.isDataLoading = true;
    this.reportForUserService.getAllForUser(httpParameters).subscribe(
      data => {
        this.loadAuthoritiesData(data);
      },
      error => {
        this.isDataLoaded = false;
        this.isDataLoading = false;
        this.errorMessage = 'Грешка при извличане на данни за администрации';
        this.toastService.showMessage(
          'Грешка при извличане на данни за администрации!'
        );
      }
    );
    // this.administrationService.find(this.authorityId).subscribe(data => {
    //   this.pageTitle = data.acronym + ' - ' + data.name;
    // });\
  }

  private loadAuthoritiesData(data: ReportForUserModel[]) {
    this.populateAuthorities(data);
    this.populateRegistriesForAuthorities(data);

    if (data.length > 0) {
      const item = data[0];
      this.pageTitle = 'Администрации';
    } else {
      this.pageTitle = 'Няма намерени администрации';
    }

    this.isDataLoaded = true;
    this.isDataLoading = false;
    this.errorMessage = null;
  }

  private populateRegistriesForAuthorities(data: ReportForUserModel[]) {
    const obj: any = {};
    this.authorities.forEach(authority => {
      // find all for register
      const registers = data.filter(item => item.authorityId === authority.id);
      // transform to DisplayValue objects
      const arr = registers.map(item => {
        const newObj = {
          id:  item.registerId,
          reference: ROUTES.REGISTERS,
          args: {':REG_ID': item.registerId + '', ':ADM_ID': this.administrationId},
          title: item.registerName
        };
        return newObj;
      });
      const distinctArray = arr.filter(
        (register, index, self) =>
          index === self.findIndex(
            (t) => (t.id === register.id)
          )
      );

      distinctArray.sort((a, b) => {
        if (a.title > b.title) {
          return 1;
        }
        if (a.title < b.title) {
          return -1;
        }
        return 0;
      });
      // store in dictionary
      obj[authority.id] = distinctArray;
    });
    this.registries = obj;
  }

  private populateAuthorities(data: ReportForUserModel[]) {
    const arr: DisplayValue[] = [];
    data.forEach(item => {
      const foundItem = arr.find(d => d.id === item.authorityId);
      if (!foundItem) {
        arr.push(
          new DisplayValue({
            id: item.authorityId,
            displayName: item.authorityName
          })
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
    this.authorities = arr;
  }
}
