import { AdapterListModel } from './../../../core/model/adapter-list.model';
import { Component, OnInit } from '@angular/core';
import { RestClientAdapterService } from 'src/app/core/services/rest/rest-client-adapter-service';
import { Router, ActivatedRoute } from '@angular/router';
import { ROUTES } from '../../routes/static-routes';

@Component({
  selector: 'app-adapters-list',
  templateUrl: './adapters-list.component.html',
  styleUrls: ['./adapters-list.component.scss']
})
export class AdaptersListComponent implements OnInit {
  public routes = ROUTES;
  
  isDataLoading = false;
  isDataLoaded = false;

  errorMessage: string;

  adapters: AdapterListModel[] = [];

  constructor(
    private adapterService: RestClientAdapterService,
    private router: Router,
    private activatedRoute: ActivatedRoute) {

    }

    ngOnInit() {
      this.isDataLoading = true;
      this.isDataLoaded = false;
      this.adapterService.retrieveAll().subscribe(
        (data) => {
          this.adapters = data;
          this.isDataLoaded = true;
          this.isDataLoading = false;
        },
        (error) => {
          this.isDataLoaded = false;
          this.isDataLoading = false;
          this.errorMessage = "Грешка при извличане на данни за регистри.";
        }
      );
    }
}
