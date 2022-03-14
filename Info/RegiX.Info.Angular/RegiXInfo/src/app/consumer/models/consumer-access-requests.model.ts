import { DisplayValueConsumerAccessRequests } from './display-value-consumer-access-request.model';
import { ABaseModel } from '@tl/tl-common';
import { DisplayValue } from './display-value.model';
import { DisplayValueConsumerRequest } from './display-value-consumer-request.model';

export class ConsumerAccessRequestsModel extends ABaseModel {
  public lawReason: string;
  public relatedServices: string;
  public relatedServicesCode: string;
  public status: number;

  public adapterOperation: DisplayValueConsumerAccessRequests;
  public consumerSystemCertificate: DisplayValue;
  public consumerRequest: DisplayValueConsumerRequest;

  constructor(init?: Partial<ConsumerAccessRequestsModel>) {
    super(init);
    if (init) {
      this.lawReason = init.lawReason;
      this.relatedServices = init.relatedServices;
      this.relatedServicesCode = init.relatedServicesCode;
      this.status = init.status;
      if (init.adapterOperation) {
        this.adapterOperation = new DisplayValueConsumerAccessRequests(init.adapterOperation);
      }
      if (init.consumerRequest) {
        this.consumerRequest = new DisplayValueConsumerRequest(init.consumerRequest);
      }
      if (init.consumerSystemCertificate) {
        this.consumerSystemCertificate = new DisplayValue(init.consumerSystemCertificate);
      }
    }
  }
  
}
