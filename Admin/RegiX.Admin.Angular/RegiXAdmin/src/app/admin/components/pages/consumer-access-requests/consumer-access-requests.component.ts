import { Component, OnInit, Injector } from '@angular/core';
import {
  RemoteComponentWithForm,
  DisplayValueFilteringOperand,
  EColumnType,
} from '@tl/tl-common';
import { ConsumerAccessRequestsModel } from 'src/app/core/models/dto/consumer-access-requests.model';
import { ConsumerAccessRequestsService } from 'src/app/core/services/rest/consumer-access-requests.service';
import { DisplayValueFormatService } from 'src/app/core/services/display-value-format.service';
import { ROUTES } from 'src/app/admin/routes/static-routes';
import { OidcSecurityService } from 'angular-auth-oidc-client';
import { ConsumerAccessRequestsStatus } from 'src/app/admin/enums/consumer-access-requests-status.enum';
import { ETables } from 'src/app/admin/enums/tables.enum';

@Component({
  selector: 'app-consumer-access-requests',
  templateUrl: './consumer-access-requests.component.html',
  styleUrls: ['./consumer-access-requests.component.scss'],
})
export class ConsumerAccessRequestsComponent extends RemoteComponentWithForm<
  ConsumerAccessRequestsModel,
  ConsumerAccessRequestsService
> {
  public routes = ROUTES;
  public CONSUMER_ACCESS_REQUESTS = ETables.CONSUMER_ACCESS_REQUESTS.toLowerCase();
  public displayValueFilteringOperand = DisplayValueFilteringOperand.instance();
  currentUserRole: string;

  public Status: any = {
    0: ConsumerAccessRequestsStatus.NEW,
    1: ConsumerAccessRequestsStatus.ENTERED,
    2: ConsumerAccessRequestsStatus.DECLINED,
    3: ConsumerAccessRequestsStatus.ACCEPTED,
    4: ConsumerAccessRequestsStatus.APPROVED,
  };

  //pageTitle = ROUTES.CONSUMER_PROFILES.title; //fix titles icons and add routes
  subtitle: string;

  constructor(
    service: ConsumerAccessRequestsService,
    injector: Injector,
    public displayValueService: DisplayValueFormatService,
    private oidcSecurityService: OidcSecurityService,
  ) {
    super(service, injector);
  }

  ngOnInitImpl() {
    this.oidcSecurityService.userData$.subscribe((userData) => {
      if (userData) {
        this.currentUserRole = userData.role;
      }
    });
  }

  protected getFilterField(): string {
    return 'CON_ACC_ID';
  }

  protected getFilterColumn(): string {
    return 'consumerRequest.id';
  }

  protected getIdColumn(): string {
    return 'id';
  }

  protected getFilterColumnType(): EColumnType {
    return EColumnType.DECIMAL;
  }

  protected excelExportMapItem(item: ConsumerAccessRequestsModel){
    return {
      Операция: item.adapterOperation?.displayName,
      Статус: item.status,
      Сертификат: item.consumerSystemCertificate?.displayName,
      Заявка: item.consumerRequest?.displayName
    };
  }
}
