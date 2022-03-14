import { Component, OnInit, Injector } from '@angular/core';
import { RemoteComponentWithForm } from '@tl/tl-common';
import { ConsumerOperationModel } from 'src/app/core/models/dto/consumer-operation.model';
import { ConsumerOperationService } from 'src/app/core/services/rest/consumer-operation.service';
import {
  ConnectedPositioningStrategy,
  HorizontalAlignment,
  VerticalAlignment,
  NoOpScrollStrategy,
} from 'igniteui-angular';
import { ConsumerCertificatesService } from 'src/app/core/services/rest/consumer-certificates.service';
import { AdapterOperationsService } from 'src/app/core/services/rest/adapter-operations.service';
import { GridRemoteFilteringService } from '@tl/tl-common';
import { CertificateOperationModel } from 'src/app/core/models/dto/certificate-operation.model';
import { ETables } from 'src/app/admin/enums/tables.enum';
import { EColumnType } from '@tl/tl-common';
import { ROUTES } from 'src/app/admin/routes/static-routes';
import { DatеFormatService } from 'src/app/core/services/date-format.service';

@Component({
  selector: 'app-consumer-operation',
  templateUrl: './consumer-operation.component.html',
  styleUrls: ['./consumer-operation.component.scss'],
})
export class ConsumerOperationComponent extends RemoteComponentWithForm<
  ConsumerOperationModel,
  ConsumerOperationService
> {
  public routes = ROUTES;
  public CERTIFICATE_OPERATION_ACCESS = ETables.CERTIFICATE_OPERATION_ACCESS.toLowerCase();
  pageTitle = 'Операции на консуматор';

  constructor(
    service: ConsumerOperationService,
    private consumerService: ConsumerCertificatesService,
    private operationsService: AdapterOperationsService,
    injector: Injector,
    public dateFormatService: DatеFormatService
  ) {
    super(service, injector);
  }

  ngOnInitImpl() {
    // this.grid.sortingExpressions = [
    //   { fieldName: 'updatedOn', dir: SortingDirection.Desc }
    // ];
    if (this.filter) {
      if (!this.isIDFilter) {
        if (!this.isFilterFieldFromData) {
          this.consumerService
            .find(this.filter.columnValue)
            .subscribe((data) => {
              if (data) {
                this.pageTitle = 'Операции на сертификат "' + data.name + '"';
              }
            });
        } else {
          this.operationsService
            .find(this.filter.columnValue)
            .subscribe((data) => {
              if (data) {
                this.pageTitle =
                  'Операции на сертификат за операция "' + data.name + '"';
              }
            });
        }
      } else {
        this.pageTitle =
          'Операция на сертификат с ID: ' + this.filter.columnValue;
      }
    }
  }

  protected createRemoteService() {
    this.remoteService = new GridRemoteFilteringService(
      {
        adapterOperation: 'adapterOperation.displayName',
        consumerCertificate: 'consumerCertificate.displayName',
      },
      this.service,
      this.grid,
      this.injector
    );
  }

  onShowMenuSelected(event) {}

  protected getFilterColumn(): string {
    return 'consumerCertificate.id';
  }

  protected getIdColumn(): string {
    return 'Id';
  }

  protected getFilterColumnType(): EColumnType {
    return EColumnType.DECIMAL;
  }

}
