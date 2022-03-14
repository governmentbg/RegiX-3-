import { Component, OnInit, Injector } from '@angular/core';
import { CertificateOperationModel } from 'src/app/core/models/dto/certificate-operation.model';
import { RemoteComponentWithForm, TLRouteReference, TlRouteArguments, DisplayValueFilteringOperand } from '@tl/tl-common';
import { CertificateOperationsService } from 'src/app/core/services/rest/certificate-operations.service';
import {
  SortingDirection,
  ConnectedPositioningStrategy,
  HorizontalAlignment,
  VerticalAlignment,
  NoOpScrollStrategy,
} from 'igniteui-angular';
import { ETables } from 'src/app/admin/enums/tables.enum';
import { EColumnType } from '@tl/tl-common';
import { ConsumerCertificatesService } from 'src/app/core/services/rest/consumer-certificates.service';
import { AdapterOperationsService } from 'src/app/core/services/rest/adapter-operations.service';
import { GridRemoteFilteringService } from '@tl/tl-common';
import { ROUTES } from 'src/app/admin/routes/static-routes';
import { DatеFormatService } from 'src/app/core/services/date-format.service';
import { DisplayValueFormatService } from 'src/app/core/services/display-value-format.service';

@Component({
  selector: 'app-certificate-operations',
  templateUrl: './certificate-operations.component.html',
  styleUrls: ['./certificate-operations.component.scss'],
})
export class CertificateOperationsComponent extends RemoteComponentWithForm<
  CertificateOperationModel,
  CertificateOperationsService
> {
  public routes = ROUTES;
  public CERTIFICATE_OPERATION_ACCESS = ETables.CERTIFICATE_OPERATION_ACCESS.toLowerCase();
  public displayValueFilteringOperand = DisplayValueFilteringOperand.instance();
  title: string;
  icon: string;
  objectName = 'операция и сертификат';
  pageTitle = 'Операции и сертификат';
  subtitle: string;
  certificateOperationAccess: TLRouteReference;
  certificateOperationAccessArgs: TlRouteArguments;

  public menuOverlaySettings = {
    positionStrategy: new ConnectedPositioningStrategy({
      horizontalDirection: HorizontalAlignment.Left,
      horizontalStartPoint: HorizontalAlignment.Right,
      verticalStartPoint: VerticalAlignment.Bottom,
    }),
    scrollStrategy: new NoOpScrollStrategy(),
  };

  constructor(
    service: CertificateOperationsService,
    private certificateService: ConsumerCertificatesService,
    private operationsService: AdapterOperationsService,
    injector: Injector,
    public dateFormatService: DatеFormatService,
    public displayValueService: DisplayValueFormatService
  ) {
    super(service, injector);
  }

  protected getFilterField(): string {
    const routeField = this.activatedRoute.snapshot.data.filterField;
    if (routeField === 'AdapterOperationId') {
      return 'OPER_ID';
    } else {
      return 'CER_ID';
    }
  }

  ngOnInitImpl() {
    // this.grid.sortingExpressions = [
    //   { fieldName: 'updatedOn', dir: SortingDirection.Desc }
    // ];
    this.icon = this.activatedRoute.snapshot.data.icon;
    this.certificateOperationAccess = null;
    this.certificateOperationAccessArgs = null;
    if (this.filter) {
      if (!this.isIDFilter) {
        if (!this.isFilterFieldFromData) {
          this.certificateOperationAccess = this.routes.CERTIFICATE_OPERATION_ACCESS;
          this.certificateOperationAccessArgs = { ':ID': this.filter.columnValue };
          this.certificateService
            .find(this.filter.columnValue)
            .subscribe((data) => {
              if (data) {
                this.pageTitle = 'Операции на сертификат "' + data.name + '"';
                this.title = 'Операции на сертификат';
                this.icon = this.routes.OPERATIONS.icon;
                this.subtitle = data.name;
              }
            });
        } else {
          this.operationsService
            .find(this.filter.columnValue)
            .subscribe((data) => {
              if (data) {
                this.pageTitle = 'Сертификати за операция "' + data.name + '"';
                this.title = 'Сертификати за операция';
                this.icon = this.routes.CERTIFICATES.icon;
                this.subtitle = data.name;
              }
            });
        }
      } else {
        this.pageTitle =
          'Операция на сертификат с ID: ' + this.filter.columnValue;
        this.title = 'Операция на сертификат с ID: ' + this.filter.columnValue;
        this.subtitle = null;
      }
    } else {
      this.pageTitle = 'Операции и сертификати';
      this.title = 'Операции и сертификати';
      this.subtitle = null;
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

  protected excelExportMapItem(item: CertificateOperationModel){
    return {
      'Описание на операцията': item.adapterOperation?.description,
      Операция: item.adapterOperation?.displayName,
      Сертификат: item.consumerCertificate?.displayName,
      'Има достъп': item.hasAccess,
      Потребител: item.updatedBy,
      'Променено на': this.dateFormatService.formatForExport(item.updatedOn),
      Коментар: item.editComment
    };
  }
}
