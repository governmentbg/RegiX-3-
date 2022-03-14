import { Component, OnInit } from '@angular/core';
import { AdapterListModel } from 'src/app/core/model/adapter-list.model';
import { RestClientAdapterService } from 'src/app/core/services/rest/rest-client-adapter-service';
import { Router, ActivatedRoute } from '@angular/router';
import { ROUTES } from 'src/app/public/routes/static-routes';

@Component({
  selector: 'app-register-details',
  templateUrl: './register-details.component.html',
  styleUrls: ['./register-details.component.scss'],
})
export class RegisterDetailsComponent implements OnInit {
  isDataLoading = false;
  isDataLoaded = false;

  errorMessage: string;
  registerName: string;
  pageTitle = 'Преглед на адаптери';

  adapters: AdapterListModel[] = [];

  constructor(
    private adapterService: RestClientAdapterService,
    private router: Router,
    private activatedRoute: ActivatedRoute,

  ) {}

  ngOnInit() {

    this.activatedRoute.params.subscribe((params) => {
      this.registerName = params['REGISTER_NAME'];
      this.pageTitle = 'Преглед на адаптери за: ' + this.registerName;
    });
    this.getAdaptersByRegister();
  }

  private getAdaptersByRegister() {
    this.isDataLoading = true;
    this.isDataLoaded = false;
    this.adapterService.retrieveAllByRegister({key: 'registerName', value: this.registerName}).subscribe(
      (data) => {
        this.adapters = data;
        this.isDataLoaded = true;
        this.isDataLoading = false;
      },
      () => {
        this.isDataLoaded = false;
        this.isDataLoading = false;
        this.errorMessage = 'Грешка при извличане на данни за регистри.';
      }
    );
  }

  selectCell(item: AdapterListModel, cell?: any) {
    ROUTES.ADAPTERS_VIEW.navigate(this.router, {':ADAPTER_NAME': item.name }, this.activatedRoute);
  }
}
