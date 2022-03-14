import { DatеFormatService } from 'src/app/core/services/date-format.service';
import { Component, OnInit, Injector } from '@angular/core';
import {
  RemoteComponentWithForm,
  DisplayValueFilteringOperand,
  GridRemoteFilteringService,
  EColumnType,
} from '@tl/tl-common';
import { ConsumerSystemCertificatesModel } from 'src/app/core/models/dto/consumer-system-certificates.model';
import { ConsumerSystemCertificatesService } from 'src/app/core/services/rest/consumer-system-certificates.service';
import { DisplayValueFormatService } from 'src/app/core/services/display-value-format.service';
import { ROUTES } from 'src/app/admin/routes/static-routes';
import { ETables } from 'src/app/admin/enums/tables.enum';

@Component({
  selector: 'app-consumer-system-certificates',
  templateUrl: './consumer-system-certificates.component.html',
  styleUrls: ['./consumer-system-certificates.component.scss'],
})
export class ConsumerSystemCertificatesComponent extends RemoteComponentWithForm<
  ConsumerSystemCertificatesModel,
  ConsumerSystemCertificatesService
> {
  public routes = ROUTES;

  public CONSUMER_SYSTEM_CERTIFICATES = ETables.CONSUMER_SYSTEM_CERTIFICATES.toLowerCase();
  public displayValueFilteringOperand = DisplayValueFilteringOperand.instance();
  public subtitle: string;

  constructor(
    service: ConsumerSystemCertificatesService,
    injector: Injector,
    public displayValueService: DisplayValueFormatService,
    public dateFormatService: DatеFormatService
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
  protected getFilterField(): string {
    return 'CON_SYS_ID';
  }

  protected getFilterColumn(): string {
    return 'consumerSystem.id';
  }

  protected getIdColumn(): string {
    return 'id';
  }

  protected getFilterColumnType(): EColumnType {
    return EColumnType.DECIMAL;
  }

  protected excelExportMapItem(item: ConsumerSystemCertificatesModel){
    return {
      Име: item.name,
      Сертификат: item.consumerCertificate?.displayName,
      Система: item.consumerSystem?.displayName,
      Дата: this.dateFormatService.formatForExport(item.requestDate),
      Среда: item.environment
    };
  }
}
