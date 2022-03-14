import { Component, Injector } from '@angular/core';
import { RegistryModel } from 'src/app/core/models/dto/registy.model';
import { RegistryService } from 'src/app/core/services/rest/registry.service';
import { RemoteComponentWithForm, DisplayValueFilteringOperand } from '@tl/tl-common';
import { ETables } from 'src/app/admin/enums/tables.enum';
import { EColumnType } from '@tl/tl-common';
import { AdministrationsService } from 'src/app/core/services/rest/administration.service';
import { GridRemoteFilteringService } from '@tl/tl-common';
import { ROUTES } from 'src/app/admin/routes/static-routes';
import { DisplayValueFormatService } from 'src/app/core/services/display-value-format.service';
import { HttpParams } from '@angular/common/http';

@Component({
  selector: 'app-registries',
  templateUrl: './registries.component.html',
  styleUrls: ['./registries.component.scss'],
})
export class RegistriesComponent extends RemoteComponentWithForm<
  RegistryModel,
  RegistryService
> {
  public routes = ROUTES;
  public REGISTERS = ETables.REGISTERS.toLowerCase();

  pageTitle = 'Регистри';
  subtitle: string;

  constructor(
    service: RegistryService,
    private administrationService: AdministrationsService,
    public displayValueService: DisplayValueFormatService,
    injector: Injector
  ) {
    super(service, injector);
  }

  public displayValueFilteringOperand = DisplayValueFilteringOperand.instance();

  protected getFilterField(): string {
    return 'ADM_ID';
    // return 'FILTER_FIELD';
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
              this.pageTitle = 'Регистри на "' + data.acronym + '"';
              this.subtitle = this.pageTitle;
            }
          });
      } else {
        this.pageTitle = 'Регистър с ID: ' + this.filter.columnValue;
        this.subtitle = this.pageTitle;
      }
    } else {
      this.pageTitle = 'Регистри';
      this.subtitle = null;
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

  protected excelExportMapItem(item: RegistryModel){
    return {
      // Ид: item.id,
      Име: item.name,
      Код: item.code,
      Администрация: item.administration?.displayName,
      Описание: item.description,
    };
  }

  protected getFilterColumn(): string {
    return 'administration.id';
  }

  protected getIdColumn(): string {
    return 'id';
  }

  protected getFilterColumnType(): EColumnType {
    return EColumnType.DECIMAL;
  }
}
