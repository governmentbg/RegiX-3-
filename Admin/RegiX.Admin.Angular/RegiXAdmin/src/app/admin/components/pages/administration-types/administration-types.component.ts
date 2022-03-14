import { AdministrationTypeModel } from './../../../../core/models/dto/administration-type.model';
import { AdministrationTypeService } from './../../../../core/services/rest/administration-type.service';
import { Component, OnInit, Injector } from '@angular/core';
import {
  RemoteComponentWithForm,
  GridRemoteFilteringService,
} from '@tl/tl-common';
import {
  ConnectedPositioningStrategy,
  HorizontalAlignment,
  VerticalAlignment,
  NoOpScrollStrategy,
} from 'igniteui-angular';
import { ROUTES } from 'src/app/admin/routes/static-routes';

@Component({
  selector: 'app-administration-types',
  templateUrl: './administration-types.component.html',
  styleUrls: ['./administration-types.component.scss'],
})
export class AdministrationTypesComponent extends RemoteComponentWithForm<
  AdministrationTypeModel,
  AdministrationTypeService
> {
  public routes = ROUTES;

  constructor(service: AdministrationTypeService, injector: Injector) {
    super(service, injector);
  }

  ngOnInitImpl() {
    // this.grid.sortingExpressions = [
    //   { fieldName: 'name', dir: SortingDirection.Asc }
    // ];
  }

  protected createRemoteService() {
    this.remoteService = new GridRemoteFilteringService(
      {},
      this.service,
      this.grid,
      this.injector
    );
  }

  protected excelExportMapItem(item: AdministrationTypeModel){
    return {
      // Ид: item.id,
      Име: item.name,
      Описание: item.description,
      Публичен: item.publiclyVisible,
    };
  }
}
