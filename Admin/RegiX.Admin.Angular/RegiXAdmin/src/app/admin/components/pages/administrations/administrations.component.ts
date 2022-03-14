import { Component, Injector } from '@angular/core';
import { AdministrationModel } from 'src/app/core/models/dto/administration.model';
import { AdministrationsService } from 'src/app/core/services/rest/administration.service';
import {
  RemoteComponentWithForm,
  DisplayValueFilteringOperand,
  ITLRouteReference,
} from '@tl/tl-common';
import { ETables } from 'src/app/admin/enums/tables.enum';
import { GridRemoteFilteringService } from '@tl/tl-common';
import { ROUTES } from 'src/app/admin/routes/static-routes';
import { DisplayValueFormatService } from 'src/app/core/services/display-value-format.service';
import {
  ConnectedPositioningStrategy,
  HorizontalAlignment,
  VerticalAlignment,
  NoOpScrollStrategy,
  IgxExcelExporterOptions,
} from 'igniteui-angular';
import { AdminPermissions } from 'src/app/admin/permissions';
import { HttpParams } from '@angular/common/http';
import { Observable } from 'rxjs';

@Component({
  selector: 'app-administrations',
  templateUrl: './administrations.component.html',
  styleUrls: ['./administrations.component.scss'],
  providers: [AdministrationsService],
})
export class AdministrationsComponent extends RemoteComponentWithForm<
  AdministrationModel,
  AdministrationsService
> {
  public routes = ROUTES;
  public ADMINISTRATIONS = ETables.ADMINISTRATIONS.toLowerCase();
  public displayValueFilteringOperand = DisplayValueFilteringOperand.instance();
  public globalAdmin = AdminPermissions.GLOBAL_ADMIN;

  public menuOverlaySettings = {
    positionStrategy: new ConnectedPositioningStrategy({
      horizontalDirection: HorizontalAlignment.Left,
      horizontalStartPoint: HorizontalAlignment.Right,
      verticalStartPoint: VerticalAlignment.Bottom,
    }),
    scrollStrategy: new NoOpScrollStrategy(),
  };
  constructor(
    service: AdministrationsService,
    injector: Injector,
    public displayValueService: DisplayValueFormatService
  ) {
    super(service, injector);
  }

  ngOnInitImpl() {}

  protected createRemoteService() {
    this.remoteService = new GridRemoteFilteringService(
      { administrationType: 'administrationType.displayName' },
      this.service,
      this.grid,
      this.injector
    );
  }

  protected excelExportGetAllNoWrap(httpParams: HttpParams): Observable<AdministrationModel[]> {
    if (this.showingPrimary()) {
      return this.service.GetAllPrimaries(httpParams);
    } else {
      return this.service.getAllNoWrap(httpParams);
    }
  }

  protected excelExportMapItem(item: AdministrationModel){
    return {
      // Ид: item.id,
      Име: item.name,
      Код: item.code,
      Акроним: item.acronym,
      Тип: item.administrationType?.displayName,
      Описание: item.description,
    };
  }

  public showingPrimary(): boolean {
    return this.activatedRoute.snapshot.params['ADM_TYPE'] === 'primary';
  }

  onShowMenuSelected($event) {}
}
