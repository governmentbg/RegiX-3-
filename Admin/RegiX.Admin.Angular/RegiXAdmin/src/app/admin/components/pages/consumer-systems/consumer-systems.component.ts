import { Component, OnInit, Injector } from '@angular/core';
import {
  RemoteComponentWithForm,
  GridRemoteFilteringService,
  DisplayValueFilteringOperand,
} from '@tl/tl-common';
import { ConsumerSystemsModel } from 'src/app/core/models/dto/consumer-systems.model';
import { ConsumerSystemsService } from 'src/app/core/services/rest/consumer-systems.service';
import { ROUTES } from 'src/app/admin/routes/static-routes';
import { DisplayValueFormatService } from 'src/app/core/services/display-value-format.service';
import { ETables } from 'src/app/admin/enums/tables.enum';

@Component({
  selector: 'app-consumer-systems',
  templateUrl: './consumer-systems.component.html',
  styleUrls: ['./consumer-systems.component.scss'],
})
export class ConsumerSystemsComponent extends RemoteComponentWithForm<
  ConsumerSystemsModel,
  ConsumerSystemsService
> {
  public routes = ROUTES;
  public CONSUMER_SYSTEMS = ETables.CONSUMER_SYSTEMS.toLowerCase();
  public displayValueFilteringOperand = DisplayValueFilteringOperand.instance();
  public subtitle: string;

  constructor(
    service: ConsumerSystemsService,
    injector: Injector,
    public displayValueService: DisplayValueFormatService
  ) {
    super(service, injector);
  }

  protected createRemoteService() {
    this.remoteService = new GridRemoteFilteringService(
      {},
      this.service,
      this.grid,
      this.injector
    );
  }
  protected excelExportMapItem(item: ConsumerSystemsModel){
    return {
      // Ид: item.id,
      Име: item.name,
      'IP адрес': item.staticIP,
      Консуматор: item.apiServiceConsumer?.displayName,
      consumerProfile: item.consumerProfile?.displayName,
      Описание: item.description,
    };
  }
}
