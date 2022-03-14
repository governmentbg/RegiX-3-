import { Component, OnInit, Injector } from '@angular/core';
import { ApiServiceModel } from 'src/app/core/models/dto/api-service.model';
import { ApiServiceService } from 'src/app/core/services/rest/api-service.service';
import { RemoteComponentWithForm } from '@tl/tl-common';
import { SortingDirection } from 'igniteui-angular';
import { ETables } from 'src/app/admin/enums/tables.enum';
import { EColumnType } from '@tl/tl-common';
import { AdministrationsService } from 'src/app/core/services/rest/administration.service';
import { GridRemoteFilteringService } from '@tl/tl-common';
import { ROUTES } from 'src/app/admin/routes/static-routes';

@Component({
  selector: 'app-interfaces',
  templateUrl: './interfaces.component.html',
  styleUrls: ['./interfaces.component.scss']
})
export class InterfacesComponent extends RemoteComponentWithForm<
  ApiServiceModel,
  ApiServiceService
> {
  public routes = ROUTES;
  public API_SERVICES = ETables.API_SERVICES.toLowerCase();

  title: string;
  objectName = 'интерфейс';
  pageTitle = 'Интерфейси';

  constructor(
    service: ApiServiceService,
    private administrationService: AdministrationsService,
    injector: Injector
  ) {
    super(service, injector);
  }

  protected getFilterField(): string {
    return 'ADM_ID';
  }

  ngOnInitImpl() {
    // this.grid.sortingExpressions = [
    //   { fieldName: 'name', dir: SortingDirection.Asc }
    // ];
    if (this.filter) {
      if (!this.isIDFilter) {
        this.administrationService
          .find(this.filter.columnValue)
          .subscribe(data => {
            if (data) {
              this.pageTitle = 'Интерфейси на "' + data.acronym + '"';
            }
          });
      } else {
        this.pageTitle = 'Интерфейс с ID: ' + this.filter.columnValue;
      }
    } else {
      this.pageTitle = 'Интерфейси';
    }
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

  formatDisplayValue(value) {
    return value.displayName;
  }

  protected excelExportMapItem(item: ApiServiceModel){
    return {
      Име: item.name,
      'URL адрес': item.serviceUrl,
      Администрация: item.administration?.displayName,
      Комплексен: item.isComplex,
      Активен: item.enabled
    };
  }
}
