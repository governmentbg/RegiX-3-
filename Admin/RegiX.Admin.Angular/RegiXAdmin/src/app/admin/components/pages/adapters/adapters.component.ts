import { DisplayValueFormatService } from './../../../../core/services/display-value-format.service';
import { DisplayValue } from './../../../../core/models/display-value.model';
import { ETables } from './../../../enums/tables.enum';
import { Component, OnInit, Injector } from '@angular/core';
import { AdapterModel } from 'src/app/core/models/dto/adapters.model';
import { AdaptersService } from 'src/app/core/services/rest/adapters.service';
import { RemoteComponentWithForm, DisplayValueFilteringOperand } from '@tl/tl-common';
import {
  SortingDirection,
  ConnectedPositioningStrategy,
  HorizontalAlignment,
  VerticalAlignment,
  NoOpScrollStrategy
} from 'igniteui-angular';
import { EColumnType } from '@tl/tl-common';
import { RegistryService } from 'src/app/core/services/rest/registry.service';
import { GridRemoteFilteringService } from '@tl/tl-common';
import { ROUTES } from 'src/app/admin/routes/static-routes';

@Component({
  selector: 'app-adapters',
  templateUrl: './adapters.component.html',
  styleUrls: ['./adapters.component.scss']
})
export class AdaptersComponent extends RemoteComponentWithForm<
  AdapterModel,
  AdaptersService
> {
  public routes = ROUTES;
  public REGISTER_ADAPTERS  = ETables.REGISTER_ADAPTERS.toLowerCase();
  public displayValueFilteringOperand = DisplayValueFilteringOperand.instance();

  pageTitle = this.routes.ADAPTERS.title;
  subtitle: string;

  constructor(
    service: AdaptersService,
    private registryService: RegistryService,
    injector: Injector,
    public displayValueService: DisplayValueFormatService
  ) {
    super(service, injector);
  }
  public getFilterField(): string {
    return 'REG_ID';
  }

  ngOnInitImpl() {
    // this.grid.sortingExpressions = [
    //   { fieldName: 'name', dir: SortingDirection.Asc }
    // ];
    if (this.filter) {
      if (!this.isIDFilter) {
        this.registryService.find(this.filter.columnValue).subscribe(data => {
          if (data) {
            this.pageTitle = 'Адаптери на "' + data.name + '"';
            this.subtitle = this.pageTitle;
          }
        });
      } else {
        this.pageTitle = 'Адаптер с ID: "' + this.filter.columnValue.name + '"';
        this.subtitle = this.pageTitle;
      }
    } else {
      this.pageTitle = 'Адаптери';
      this.subtitle = null;
    }

    //TODO Check if needed ?
  }

  protected createRemoteService() {
    this.remoteService = new GridRemoteFilteringService(
      { register: 'register.displayName' },
      this.service,
      this.grid,
      this.injector
    );
  }

  protected getIdColumn(): string {
    return 'RegisterAdapterId';
  }

  protected getFilterColumn(): string {
    return 'register.id';
  }

  protected getFilterColumnType(): EColumnType {
    return EColumnType.DECIMAL;
  }

  protected excelExportMapItem(item: AdapterModel){
    return {
      // Ид: item.id,
      Име: item.name,
      Регистър: item.register?.displayName,
      Интерфейс: item.contract,
      Асембли: item.assembly,
      Описание: item.description,
      ТипBinding: item.description,
      bindingConfigName: item.bindingConfigName,
      adapterUrl: item.adapterUrl,
      behaviour: item.behaviour,
      hostAvailability: item.hostAvailability,
    };
  }
}
