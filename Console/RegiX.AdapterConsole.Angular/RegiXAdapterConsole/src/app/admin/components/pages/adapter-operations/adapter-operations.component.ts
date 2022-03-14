import { Component, OnInit, Injector } from "@angular/core";
import { AdapterOperationModel } from "src/app/core/models/dto/adapter-operation.model";
import { AdapterOperationsService } from "src/app/core/services/rest/adapter-operations.service";
import { RemoteComponentWithForm } from '@tl/tl-common';
import {
  ConnectedPositioningStrategy,
  HorizontalAlignment,
  VerticalAlignment,
  NoOpScrollStrategy
} from "igniteui-angular";
import { GridRemoteFilteringService } from '@tl/tl-common';
import { ROUTES } from 'src/app/admin/routes/static-routes';

@Component({
  selector: "app-adapter-operations",
  templateUrl: "./adapter-operations.component.html",
  styleUrls: ["./adapter-operations.component.scss"]
})
export class AdapterOperationsComponent extends RemoteComponentWithForm<
  AdapterOperationModel,
  AdapterOperationsService
> {
  public routes = ROUTES;
 
  constructor(service: AdapterOperationsService, injector: Injector) {
    super(service, injector);
  }

  ngOnInitImpl() {
    // this.grid.sortingExpressions = [
    //   { fieldName: 'name', dir: SortingDirection.Asc }
    // ];
  }

  protected createRemoteService() {
    this.remoteService = new GridRemoteFilteringService(
      {},
      this.service,
      this.grid,
      this.injector
    );
  }
}
