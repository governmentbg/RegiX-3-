import { Router, ActivatedRoute } from '@angular/router';
import { Component, OnInit, Input, AfterViewInit } from '@angular/core';
import { RestClientAdministrationsService } from 'src/app/core/services/rest/rest-client-administrations-service';
import { AgencyInfo } from 'src/app/core/model/regix/agency-info.model';
import { RestClientAdapterService } from 'src/app/core/services/rest/rest-client-adapter-service';
import { ROUTES } from '../../routes/static-routes';

@Component({
  selector: 'app-info',
  templateUrl: './info.component.html',
  styleUrls: ['./info.component.scss']
})
export class InfoComponent implements OnInit {
  subtitle = 'RegiX Info';
  title = 'Администрации и регистри';
  agenciesInfo: AgencyInfo[] = [];
  isDataLoading = false;
  isDataLoaded = false;

  agencyDetails: any[] = [];

  constructor(
    //private adapterService: RestClientAdapterService,
    private administrationService: RestClientAdministrationsService,
    private router: Router,
    private activatedRoute: ActivatedRoute
  ) {}

  ngOnInit() {
    this.isDataLoading = true;
    this.administrationService.retrieveAllInfo().subscribe(
      (data: AgencyInfo[]) => {

        this.agencyDetails = data;

        this.isDataLoading = false;
        this.isDataLoaded = true;

      },
      err => {
        this.isDataLoading = false;
        this.isDataLoaded = true;
      }
    );
  }

  selectCell(item: any) {
    ROUTES.AGENCIES_VIEW.navigate(this.router, {':AGENCY_ID': item}, this.activatedRoute);
  }
}
