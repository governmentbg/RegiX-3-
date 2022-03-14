import { Component, OnInit, ViewChild } from '@angular/core';
import { AdministrationListModel } from 'src/app/core/model/administration-list.model';
import { Router, ActivatedRoute } from '@angular/router';
import { RestClientAdministrationsListService } from 'src/app/core/services/rest/rest-client-adminstrations-list-service';
import { IgxGridCellComponent, IgxGridComponent, IgxIconService } from 'igniteui-angular';
import { ROUTES } from '../../routes/static-routes';

@Component({
  selector: 'app-administration-list',
  templateUrl: './administration-list.component.html',
  styleUrls: ['./administration-list.component.scss'],
})
export class AdministrationListComponent implements OnInit {
  // @ViewChild("grid", { static: true })
  // public grid: IgxGridComponent;

  public routes = ROUTES;

  isDataLoading = false;
  isDataLoaded = false;

  errorMessage: string;
  pageTitle: string = 'Администрации';

  administrations: any[] = [];

  constructor(
    private administrationsService: RestClientAdministrationsListService,
    private router: Router,
    private activatedRoute: ActivatedRoute,
    private iconService: IgxIconService
  ) {}

  ngOnInit() {
    // register custom SVG icons
    // this.iconService.addSvgIcon('NZOK', '/assets/logos/NZOK.svg', 'administration-icons');

    this.isDataLoading = true;
    this.isDataLoaded = false;
    this.administrationsService.retrieveAll().subscribe(
      (data) => {
        this.administrations = data.map( d => {
          return {
            reference: ROUTES.REGISTRIES,
            args: {':ADM_CODE': d.code},
            title: d.name,
            permissions: [],
            icon: ROUTES.REGISTRIES.icon
          };
        });
        this.isDataLoaded = true;
        this.isDataLoading = false;
      },
      (error) => {
        this.isDataLoaded = false;
        this.isDataLoading = false;
        this.errorMessage = 'Грешка при извличане на данни за администрации.';
      }
    );
  }
}
