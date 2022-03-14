import { Component, Injector } from '@angular/core';
import { NotRegisterAdapterModel } from 'src/app/core/models/dto/not-register-adapter.model';

import { ComponentWithForm } from '@tl/tl-common';
import { NotRegisterAdaptersService } from 'src/app/core/services/rest/not-register-adapters.service';
import { ROUTES } from 'src/app/admin/routes/static-routes';

@Component({
  selector: 'app-not-register-adapters',
  templateUrl: './not-register-adapters.component.html',
  styleUrls: ['./not-register-adapters.component.scss']
})

export class NotRegisterAdaptersComponent extends ComponentWithForm<
  NotRegisterAdapterModel,
  NotRegisterAdaptersService
> {
  public routes = ROUTES;
  public notRegisterAdapters: NotRegisterAdapterModel[] = [];
  public isDataLoaded: boolean;
  public isDataLoading: boolean;
  public errorMessage: string;


  //TODO: Other options without casting?
  public get NotRegisterAdaptersService(): NotRegisterAdaptersService {
    return (this.backService as any) as NotRegisterAdaptersService;
  }

  constructor(
    service: NotRegisterAdaptersService,
    injector: Injector
  ) {
    super(service, injector);
  }

  public ngOnInit(): void {
    this.service.getAllNoWrap()
    .subscribe(
      (data: NotRegisterAdapterModel[] )=> {
        this.notRegisterAdapters = data;
        this.isDataLoaded = true;
        this.isDataLoading = false;
      },
      error => {
        this.isDataLoaded = false;
        this.isDataLoading = false;
        this.errorMessage = 'Грешка при извличане на данни за нерегистрирани адаптери.';
      }
    );
  }
}
