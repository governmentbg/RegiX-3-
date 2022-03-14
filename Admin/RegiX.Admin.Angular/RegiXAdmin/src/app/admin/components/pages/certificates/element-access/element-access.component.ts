import { Component, OnInit, Injector } from '@angular/core';
import { RemoteComponentWithForm, DisplayValueFilteringOperand } from '@tl/tl-common';
import { CertificateElementAccessModel } from 'src/app/core/models/dto/certificate-element-access.model';
import { CertificateElementAccessService } from 'src/app/core/services/rest/certificate-element-access.service';
import { SortingDirection } from 'igniteui-angular';
import { ETables } from 'src/app/admin/enums/tables.enum';
import { EColumnType } from '@tl/tl-common';
import { ConsumerCertificatesService } from 'src/app/core/services/rest/consumer-certificates.service';
import { GridRemoteFilteringService } from '@tl/tl-common';
import { ROUTES } from 'src/app/admin/routes/static-routes';
import { DisplayValueFormatService } from 'src/app/core/services/display-value-format.service';
import { Params } from '@angular/router';

@Component({
  selector: 'app-element-access',
  templateUrl: './element-access.component.html',
  styleUrls: ['./element-access.component.scss']
})
export class ElementAccessComponent extends RemoteComponentWithForm<
  CertificateElementAccessModel,
  CertificateElementAccessService
> {
  public routes = ROUTES;
  public CONSUMER_ROLE_ELEMENT_ACCESS = ETables.CONSUMER_ROLE_ELEMENT_ACCESS.toLowerCase();
  public displayValueFilteringOperand = DisplayValueFilteringOperand.instance();
  public filterField: number;
  public certificateId: number;

  title: string;
  objectName = 'елемент на операция';
  pageTitle = 'Елементи на операция';
  subtitle: string;

  constructor(
    service: CertificateElementAccessService,
    private certificateService: ConsumerCertificatesService,
    injector: Injector,
    public displayValueService: DisplayValueFormatService
  ) {
    super(service, injector);
  }

  ngOnInitImpl() {
    // this.grid.sortingExpressions = [
    //   { fieldName: 'id', dir: SortingDirection.Desc }
    // ];
    if (this.filter) {
      if (!this.isIDFilter) {
        this.certificateService
          .find(this.filter.columnValue)
          .subscribe(data => {
            if (data) {
              this.pageTitle =
                'Елементи на операция за сертификат "' + data.name + '"';
              this.subtitle = this.pageTitle;
            }
          });
      } else {
        this.pageTitle = 'Елемент на операция с ID: ' + this.filter.columnValue;
        this.subtitle = this.pageTitle;
      }
    } else {
      this.subtitle = null;
    }
  }

  protected createRemoteService() {
    this.remoteService = new GridRemoteFilteringService(
      {
        consumerCertificate: 'consumerCertificate.displayName',
        registerObjectElement: 'registerObjectElement.displayName'
      },
      this.service,
      this.grid,
      this.injector
    );
  }

  protected initializeFilterWithParams(params: Params){
    this.filterField = params['FILTER_FIELD'];
    this.certificateId = params['CER_ID'];
  }

  protected getFilterExpression() {
    return `consumerCertificate.id eq ${this.certificateId} and RegisterObjectElement/RegisterObjectId eq ${this.filterField}`;
  }

  prepareForShow(item: CertificateElementAccessModel, cell?) {
    const theItem = new CertificateElementAccessModel(item);
    super.prepareForShow(theItem);
    // this.modalInstance.open(this.currentAction);
    this.router.navigate([
      'admin',
      'consumers',
      'certificates',
      'operations',
      'elementsAccess',
      'elementAccess',
      theItem.id
    ]);
    //TODO:Add routing PS. not present in old routing
    //Add elemet-access-form component ?
  }

  protected getFilterColumn(): string {
    return 'consumerCertificate.id';
  }

  protected getFilterColumnType(): EColumnType {
    return EColumnType.DECIMAL;
  }
  protected excelExportMapItem(item: CertificateElementAccessModel){
    return {
      Елемент: item.registerObjectElement?.displayName,
      Сертификат: item.consumerCertificate?.displayName,
      'Има достъп': item.hasAccess
    };
  }
}
