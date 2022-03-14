import { Component, OnInit, Injector } from '@angular/core';
import { DisplayValueFilteringOperand, RemoteComponentWithForm } from '@tl/tl-common';
import { OperationCallModel } from 'src/app/core/models/dto/operation-call.model';
import { OperationCallsService } from 'src/app/core/services/rest/operation-calls.service';
import { ConnectedPositioningStrategy, HorizontalAlignment, VerticalAlignment, NoOpScrollStrategy } from 'igniteui-angular';
import { GridRemoteFilteringService } from '@tl/tl-common';
import { HttpParams } from '@angular/common/http';
import { ROUTES } from 'src/app/admin/routes/static-routes';
import { DisplayValueFormatService } from 'src/app/core/services/display-value-format.service';

@Component({
  selector: 'app-operation-calls',
  templateUrl: './operation-calls.component.html',
  styleUrls: ['./operation-calls.component.scss']
})
export class OperationCallsComponent extends RemoteComponentWithForm<
OperationCallModel,
OperationCallsService
> {
  public routes = ROUTES;
  
  public displayValueFilteringOperand = DisplayValueFilteringOperand.instance();
  
  constructor(service: OperationCallsService, injector: Injector, public displayValueService: DisplayValueFormatService) {
    super(service, injector);
  }

  ngOnInitImpl() {
    // this.grid.sortingExpressions = [
    //   { fieldName: 'name', dir: SortingDirection.Asc }
    // ];
  }

  
  onShowMenuSelected(event) {}
}

