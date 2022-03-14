import { Component, Injector, DebugElement } from '@angular/core';
import { ReturnedCallModel } from 'src/app/core/models/dto/returned-call.model';
import { ReturnedCallsService } from 'src/app/core/services/rest/returned-calls.service';
import { DisplayValueFilteringOperand, RemoteComponentWithForm } from '@tl/tl-common';
import { GridRemoteFilteringService } from '@tl/tl-common';
import { ROUTES } from 'src/app/admin/routes/static-routes';
import { DisplayValueFormatService } from 'src/app/core/services/display-value-format.service';

@Component({
  selector: 'app-returned-calls',
  templateUrl: './returned-calls.component.html',
  styleUrls: ['./returned-calls.component.scss']
})
export class ReturnedCallsComponent extends RemoteComponentWithForm<
ReturnedCallModel,
ReturnedCallsService
> {
  public routes = ROUTES;
 
  public displayValueFilteringOperand = DisplayValueFilteringOperand.instance();
  
  constructor(service: ReturnedCallsService, injector: Injector, public displayValueService: DisplayValueFormatService) {
    super(service, injector);
  }

  ngOnInitImpl() {}

  onShowMenuSelected() {}
}
