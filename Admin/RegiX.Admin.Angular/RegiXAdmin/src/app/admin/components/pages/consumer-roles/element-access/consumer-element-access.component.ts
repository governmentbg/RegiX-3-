import { Component, OnInit, Injector } from '@angular/core';
import { RemoteComponentWithForm, DisplayValueFilteringOperand } from '@tl/tl-common';
import { CertificateElementAccessModel } from 'src/app/core/models/dto/certificate-element-access.model';
import { CertificateElementAccessService } from 'src/app/core/services/rest/certificate-element-access.service';
import { SortingDirection } from 'igniteui-angular';
import { ETables } from 'src/app/admin/enums/tables.enum';
import { EColumnType } from '@tl/tl-common';
import { ConsumerCertificatesService } from 'src/app/core/services/rest/consumer-certificates.service';
import { GridRemoteFilteringService } from '@tl/tl-common';
import { ConsumerRoleElementAccessModel } from 'src/app/core/models/dto/consumer-role-element-access.model';
import { ConsumerRoleElementAccessService } from 'src/app/core/services/rest/consumer-role-element-access.service';
import { ROUTES } from 'src/app/admin/routes/static-routes';
import { DisplayValueFormatService } from 'src/app/core/services/display-value-format.service';

@Component({
  selector: 'app-consumer-element-access',
  templateUrl: './consumer-element-access.component.html',
  styleUrls: ['./consumer-element-access.component.scss']
})
export class ConsumerElementAccessComponent extends RemoteComponentWithForm<
  ConsumerRoleElementAccessModel,
  ConsumerRoleElementAccessService
> {
  public routes = ROUTES;
  public CONSUMER_ROLE_ELEMENT_ACCESS = ETables.CONSUMER_ROLE_ELEMENT_ACCESS.toLowerCase();
  public displayValueFilteringOperand = DisplayValueFilteringOperand.instance();

  title: string;
  objectName = 'елемент на операция';
  pageTitle = 'Елементи на операция';

  constructor(
    service: ConsumerRoleElementAccessService,
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
    // if (this.filter) {
    //   if (!this.isIDFilter) {
    //     this.certificateService
    //       .find(this.filter.columnValue)
    //       .subscribe(data => {
    //         if (data) {
    //           this.pageTitle =
    //             'Елементи на операция за сертификат "' + data.name + '"';
    //         }
    //       });
    //   } else {
    //     this.pageTitle = 'Елемент на операция с ID: ' + this.filter.columnValue;
    //   }
    // }
  }

  protected createRemoteService() {
    this.remoteService = new GridRemoteFilteringService(
      {
        consumerRole: 'consumerRole.displayName',
        registerObjectElement: 'registerObjectElement.displayName'
      },
      this.service,
      this.grid,
      this.injector
    );
  }

  protected getFilterColumn(): string {
    return 'consumerRole.id';
  }

  protected getFilterExpression() {
    this.filter.columnName = 'consumerRole.id';
    if (this.filter && this.filter.columnName) {
      let columnValue = this.filter.columnValue;
      if (this.filter.columnType === EColumnType.STRING) {
        columnValue = "'" + columnValue + "'";
      }
      return this.filter.columnName + ' eq ' + columnValue;
    }
    return null;
  }

  protected getFilterColumnType(): EColumnType {
    return EColumnType.DECIMAL;
  }

}
