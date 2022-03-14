import { Component, Injector, OnInit } from '@angular/core';
import {
  RemoteComponentWithForm,
  DisplayValueFilteringOperand,
  EColumnType,
} from '@tl/tl-common';
import { ConsumerRequestsStatus } from 'src/app/admin/enums/consumer-requests-status.enum';
import { ETables } from 'src/app/admin/enums/tables.enum';
import { ROUTES } from 'src/app/admin/routes/static-routes';
import { ConsumerRequestsModel } from 'src/app/core/models/dto/consumer-requests.model';
import { DisplayValueFormatService } from 'src/app/core/services/display-value-format.service';
import { ConsumerRequestsService } from 'src/app/core/services/rest/consumer-requests.service';

@Component({
  selector: 'app-consumer-requests-approval',
  templateUrl: './consumer-requests-approval.component.html',
  styleUrls: ['./consumer-requests-approval.component.scss'],
})
export class ConsumerRequestsApprovalComponent extends RemoteComponentWithForm<
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

  protected getFilterExpression() {
    return "status eq 1";
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
