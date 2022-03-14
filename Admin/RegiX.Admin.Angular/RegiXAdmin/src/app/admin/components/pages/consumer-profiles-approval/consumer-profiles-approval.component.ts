import { ROUTES } from 'src/app/admin/routes/static-routes';
import { Component, Injector, OnInit } from '@angular/core';
import {
  EColumnType,
  RemoteComponentWithForm,
} from '@tl/tl-common';
import { ConsumerProfilesStatus } from 'src/app/admin/enums/consumer-profiles-status.enum';
import { ETables } from 'src/app/admin/enums/tables.enum';
import { ConsumerProfilesModel } from 'src/app/core/models/dto/consumer-profiles.model';
import { ConsumerProfilesService } from 'src/app/core/services/rest/consumer-profiles.service';

@Component({
  selector: 'app-consumer-profiles-approval',
  templateUrl: './consumer-profiles-approval.component.html',
  styleUrls: ['./consumer-profiles-approval.component.scss'],
})
export class ConsumerProfilesApprovalComponent extends RemoteComponentWithForm<
  ConsumerProfilesModel,
  ConsumerProfilesService
> {
  public routes = ROUTES;
  public CONSUMER_PROFILES = ETables.CONSUMER_PROFILES.toLowerCase();

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

  protected getFilterExpression() {
    return 'status eq 0'; // Returns only consumer-profiles with status new
  }

  protected excelExportMapItem(item: ConsumerProfilesModel) {
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
