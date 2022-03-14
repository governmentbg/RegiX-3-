import { Component, OnInit, Injector } from '@angular/core';
import {
  RemoteComponentWithForm,
  DisplayValueFilteringOperand,
  EColumnType,
} from '@tl/tl-common';
import { ConsumerAccessRequestsModel } from '../../models/consumer-access-requests.model';
import { ConsumerAccessRequestsService } from '../../services/consumer-access-requests.service';
import { CONSUMER_ROUTES } from '../../routes/consumer-static-routes';
import { DisplayValueFormatService } from '../../services/display-value-format.service';
import { ConsumerRequestsService } from '../../services/consumer-requests.service';

@Component({
  selector: 'app-access-requests',
  templateUrl: './access-requests.component.html',
  styleUrls: ['./access-requests.component.scss'],
})
export class AccessRequestsComponent extends RemoteComponentWithForm<
  ConsumerAccessRequestsModel,
  ConsumerAccessRequestsService
> {
  public routes = CONSUMER_ROUTES;
  public displayValueFilteringOperand = DisplayValueFilteringOperand.instance();
  public requestStatus: number;

  constructor(
    service: ConsumerAccessRequestsService,
    injector: Injector,
    public displayValueService: DisplayValueFormatService,
    private consumerRequestsService: ConsumerRequestsService
  ) {
    super(service, injector);
  }

  ngOnInitImpl() {
    this.consumerRequestsService
      .find(this.activatedRoute.snapshot.params['REQ_ID'])
      .subscribe((data) => {
        this.requestStatus = data.status;
      });
  }

  protected getFilterField(): string {
    return 'REQ_ID';
  }

  protected getFilterColumn(): string {
    return 'consumerRequest.id';
  }

  protected getIdColumn(): string {
    return 'id';
  }

  protected getFilterColumnType(): EColumnType {
    return EColumnType.DECIMAL;
  }
}
