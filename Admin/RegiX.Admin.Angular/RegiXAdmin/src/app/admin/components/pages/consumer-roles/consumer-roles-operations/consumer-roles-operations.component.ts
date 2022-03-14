import { Component, Injector } from '@angular/core';
import { RemoteComponentWithForm } from '@tl/tl-common';
import { ConsumerRoleOperationModel } from 'src/app/core/models/dto/consumer-role-operation.model';
import { ConsumerRolesOperationsService } from 'src/app/core/services/rest/consumer-roles-operations.service';
import { GridRemoteFilteringService } from '@tl/tl-common';
import { CertificateOperationModel } from 'src/app/core/models/dto/certificate-operation.model';
import { ETables } from 'src/app/admin/enums/tables.enum';
import { EColumnType } from '@tl/tl-common';
import { ROUTES } from 'src/app/admin/routes/static-routes';
import { ConsumerRoleService } from 'src/app/core/services/rest/consumer-role.service';

@Component({
  selector: 'app-consumer-roles-operations',
  templateUrl: './consumer-roles-operations.component.html',
  styleUrls: ['./consumer-roles-operations.component.scss']
})
export class ConsumerRolesOperationsComponent extends RemoteComponentWithForm<
  ConsumerRoleOperationModel,
  ConsumerRolesOperationsService
> {
  public routes = ROUTES;
  public CERTIFICATE_OPERATION_ACCESS = ETables.CERTIFICATE_OPERATION_ACCESS.toLowerCase();

  title: string;
  objectName = 'операция на роля';
  pageTitle = 'Операции на роля';
  subtitle: string;
  isLoading = false;

  constructor(
    private consumerRolesService: ConsumerRoleService,
    service: ConsumerRolesOperationsService,
    injector: Injector
  ) {
    super(service, injector);
    this.activatedRoute.params.subscribe(params => {
      const consumerRoleId = params['ROLE_ID'];
      if (consumerRoleId) {
        this.isLoading = true;
        this.consumerRolesService.find(consumerRoleId).subscribe(data => {
          this.isLoading = false;
          this.subtitle = data.name;
        },
        error => {
          this.isLoading = false;
        });
      }
    });
  }

  ngOnInitImpl() {}

  protected createRemoteService() {
    this.remoteService = new GridRemoteFilteringService(
      {
        adapterOperation: 'adapterOperation.displayName',
        consumerRole: 'consumerRole.displayName'
      },
      this.service,
      this.grid,
      this.injector
    );
  }
  onShowMenuSelected($event) {}

  protected getFilterColumn(): string {
    return 'consumerCertificate.id';
  }

  protected getIdColumn(): string {
    return 'Id';
  }

  protected getFilterColumnType(): EColumnType {
    return EColumnType.DECIMAL;
  }

  protected getFilterField(): string {
    return 'ROLE_ID';
  }

  protected getFilterExpression() {
    this.filter.columnName = 'consumerRole.id';
    if (this.filter && this.filter.columnName) {
      let columnValue = this.filter.columnValue;
      if (this.filter.columnType === EColumnType.STRING) {
        columnValue = '\'' + columnValue + '\'';
      }
      return this.filter.columnName + ' eq ' + columnValue;
    }
    return null;
  }

  protected excelExportMapItem(item: ConsumerRoleOperationModel){
    return {
      Администрация: item.administrationDisplayName,
      Регистър: item.registerDisplayName,
      Адаптер: item.adapterDisplayName,
      Операция: item.adapterOperationDisplayName,
      Достъп: item.hasAccess
    };
  }
}
