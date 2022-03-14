import { ConsumerProfilesStatus } from '../../../enums/consumer-profiles-status.enum';
import { Component, Injector } from '@angular/core';
import {
  RemoteComponentWithForm,
  GridRemoteFilteringService,
} from '@tl/tl-common';
import { ROUTES } from 'src/app/admin/routes/static-routes';
import { ConsumerProfilesModel } from 'src/app/core/models/dto/consumer-profiles.model';
import { ConsumerProfilesService } from 'src/app/core/services/rest/consumer-profiles.service';
import { ETables } from 'src/app/admin/enums/tables.enum';

@Component({
  selector: 'app-consumer-profiles',
  templateUrl: './consumer-profiles.component.html',
  styleUrls: ['./consumer-profiles.component.scss'],
})
export class ConsumerProfilesComponent extends RemoteComponentWithForm<
  ConsumerProfilesModel,
  ConsumerProfilesService
> {

  public CONSUMER_PROFILES = ETables.CONSUMER_PROFILES.toLowerCase();
  public routes = ROUTES;
  public Status: any = {
    0: ConsumerProfilesStatus.NEW,
    1: ConsumerProfilesStatus.DECLINED,
    2: ConsumerProfilesStatus.ACCEPTED,
  };

  pageTitle = ROUTES.CONSUMER_PROFILES.title;
  subtitle: string;

  constructor(service: ConsumerProfilesService, injector: Injector) {
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

  protected excelExportMapItem(item: ConsumerProfilesModel){
    return {
      // Ид: item.id,
      Име: item.name,
      Статус: item.status,
      Адрес: item.address,
      Идентификатор: item.identifier,
      'Входящ номер': item.documentNumber,
      Администрация: item.administration?.displayName,
    };
  }
}
