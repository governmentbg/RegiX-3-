import { Component, OnInit, Injector } from '@angular/core';
import { RemoteComponentWithForm } from '@tl/tl-common';
import { ConsumerRoleModel } from 'src/app/core/models/dto/consumer-role.model';
import { ConsumerRoleService } from 'src/app/core/services/rest/consumer-role.service';
import { ETables } from 'src/app/admin/enums/tables.enum';
import { GridRemoteFilteringService } from '@tl/tl-common';
import { ROUTES } from 'src/app/admin/routes/static-routes';

@Component({
  selector: 'app-consumer-roles',
  templateUrl: './consumer-roles.component.html',
  styleUrls: ['./consumer-roles.component.scss'],
})
export class ConsumerRolesComponent extends RemoteComponentWithForm<
  ConsumerRoleModel,
  ConsumerRoleService
> {
  public routes = ROUTES;
  public CONSUMER_ROLES = ETables.CONSUMER_ROLES.toLowerCase();

  title: string;
  objectName = 'потребител';
  pageTitle = this.routes.CONSUMER_ROLES.title;

  constructor(service: ConsumerRoleService, injector: Injector) {
    super(service, injector);
  }

  ngOnInitImpl() {}

  protected createRemoteService() {
    this.remoteService = new GridRemoteFilteringService(
      {},
      this.service,
      this.grid,
      this.injector
    );
  }

  protected getIdColumn(): string {
    return 'Id';
  }

  protected excelExportMapItem(item: ConsumerRoleModel){
    return {
      // Ид: item.id,
      Име: item.name,
      Описание: item.description,
    };
  }

  onShowMenuSelected(event) {}
}
