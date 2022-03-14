import { Component, Injector } from '@angular/core';
import {
  RemoteComponentWithForm,
  DisplayValueFilteringOperand,
  GridRemoteFilteringService,
  EColumnType,
} from '@tl/tl-common';
import { CertificateOperationAccessModel } from '../../models/certificate-operation-access.model';
import { CertificateOperationAccessService } from '../../services/certificate-operation-access.service';
import { CONSUMER_ROUTES } from '../../routes/consumer-static-routes';
import { DisplayValueFormatService } from '../../services/display-value-format.service';

@Component({
  selector: 'app-certificate-operation-access',
  templateUrl: './certificate-operation-access.component.html',
  styleUrls: ['./certificate-operation-access.component.scss'],
})
export class CertificateOperationAccessComponent extends RemoteComponentWithForm<
  CertificateOperationAccessModel,
  CertificateOperationAccessService
> {
  public routes = CONSUMER_ROUTES;
  public displayValueFilteringOperand = DisplayValueFilteringOperand.instance();

  constructor(
    service: CertificateOperationAccessService,
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
 
  protected getFilterField(): string {
    return 'CER_ID';
  }

  protected getFilterColumn(): string {
    return 'consumerCertificate.id';
  }

  protected getIdColumn(): string {
    return 'id';
  }

  protected getFilterColumnType(): EColumnType {
    return EColumnType.DECIMAL;
  }

}
