import { Component, Injector } from '@angular/core';
import { ROUTES } from 'src/app/admin/routes/static-routes';
import {
  RemoteComponentWithForm,
  DisplayValueFilteringOperand,
  GridRemoteFilteringService,
  EColumnType,
} from '@tl/tl-common';
import { ConsumerRequestsModel } from 'src/app/core/models/dto/consumer-requests.model';
import { ConsumerRequestsService } from 'src/app/core/services/rest/consumer-requests.service';
import { DisplayValueFormatService } from 'src/app/core/services/display-value-format.service';
import { ConsumerProfilesStatus } from 'src/app/admin/enums/consumer-profiles-status.enum';
import { ConsumerAccessRequestsStatus } from 'src/app/admin/enums/consumer-access-requests-status.enum';
import { ConsumerRequestsStatus } from 'src/app/admin/enums/consumer-requests-status.enum';
import { ETables } from 'src/app/admin/enums/tables.enum';

@Component({
  selector: 'app-consumer-requests',
  templateUrl: './consumer-requests.component.html',
  styleUrls: ['./consumer-requests.component.scss'],
})
export class ConsumerRequestsComponent extends RemoteComponentWithForm<
  ConsumerRequestsModel,
  ConsumerRequestsService
> {
  public routes = ROUTES;

  public CONSUMER_REQUESTS = ETables.CONSUMER_REQUESTS.toLowerCase();
  public displayValueFilteringOperand = DisplayValueFilteringOperand.instance();

  public Status: any = {
    0: ConsumerRequestsStatus.DRAFT,
    1: ConsumerRequestsStatus.NEW,
    2: ConsumerRequestsStatus.DECLINED,
    3: ConsumerRequestsStatus.ACCEPTED,
  };

  //pageTitle = ROUTES.CONSUMER_PROFILES.title; //fix titles icons and add routes
  subtitle: string;

  constructor(
    service: ConsumerRequestsService,
    injector: Injector,
    public displayValueService: DisplayValueFormatService
  ) {
    super(service, injector);
  }

  protected getFilterField(): string {
    return 'CON_PROF_ID';
  }

  protected getFilterColumn(): string {
    return 'consumerProfile.id';
  }

  protected getIdColumn(): string {
    return 'id';
  }

  protected getFilterColumnType(): EColumnType {
    return EColumnType.DECIMAL;
  }

  protected excelExportMapItem(item: ConsumerRequestsModel){
    return {
      // Ид: item.id,
      Име: item.name,
      Статус: item.status,
      'Профил на консуматор': item.consumerProfile?.displayName,
      'Изходящ номер документ': item.outDocumentNumber,
      'Номер документ': item.documentNumber,
    };
  }
}
