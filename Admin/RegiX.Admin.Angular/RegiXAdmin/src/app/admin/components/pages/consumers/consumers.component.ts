import { Component, OnInit, Injector } from '@angular/core';
import { ConsumerModel } from 'src/app/core/models/dto/consumer.model';
import { ConsumersService } from 'src/app/core/services/rest/consumers.service';
import { RemoteComponentWithForm, EColumnType, DisplayValueFilteringOperand } from '@tl/tl-common';
import { ETables } from 'src/app/admin/enums/tables.enum';
import { GridRemoteFilteringService } from '@tl/tl-common';
import { ROUTES } from 'src/app/admin/routes/static-routes';
import { AdministrationsService } from 'src/app/core/services/rest/administration.service';
import { DisplayValueFormatService } from 'src/app/core/services/display-value-format.service';
import { AdminPermissions } from 'src/app/admin/permissions';

@Component({
  selector: 'app-consumers',
  templateUrl: './consumers.component.html',
  styleUrls: ['./consumers.component.scss'],
})
export class ConsumersComponent extends RemoteComponentWithForm<
  ConsumerModel,
  ConsumersService
> {
  public routes = ROUTES;
  public API_SERVICE_CONSUMERS = ETables.API_SERVICE_CONSUMERS.toLowerCase();
  public displayValueFilteringOperand = DisplayValueFilteringOperand.instance();
  public globalAdmin = AdminPermissions.GLOBAL_ADMIN;

  pageTitle = this.routes.CONSUMERS.title;
  subtitle: string;

  constructor(
    private administrationService: AdministrationsService,
    service: ConsumersService,
    injector: Injector,
    public displayValueService: DisplayValueFormatService
  ) {
    super(service, injector);
  }

  ngOnInitImpl() {
    // this.grid.sortingExpressions = [
    //   { fieldName: 'name', dir: SortingDirection.Asc }
    // ];
    if (this.filter) {
      if (!this.isIDFilter) {
        this.administrationService
          .find(this.filter.columnValue)
          .subscribe((data) => {
            if (data) {
              this.pageTitle = 'Консуматори на "' + data.acronym + '"';
              this.subtitle = this.pageTitle;
            }
          });
      } else {
        this.pageTitle = 'Консуматор с ID: ' + this.filter.columnValue;
        this.subtitle = this.pageTitle;
      }
    } else {
      this.pageTitle = 'Консуматори';
      this.subtitle = null;
    }
  }

  protected getFilterField(): string {
    return 'ADM_ID';
  }

  protected createRemoteService() {
    this.remoteService = new GridRemoteFilteringService(
      { administration: 'administration.displayName' },
      this.service,
      this.grid,
      this.injector
    );
  }

  protected getFilterColumn(): string {
    return 'administration.id';
  }

  protected getFilterColumnType(): EColumnType {
    return EColumnType.DECIMAL;
  }

  protected getIdColumn(): string {
    return 'ApiServiceConsumerId';
  }

  protected excelExportMapItem(item: ConsumerModel){
    return {
      // Ид: item.id,
      Име: item.name,
      Описание: item.description,
      OID: item.oid,
      Тип: item.administration?.displayName,
    };
  }
}
