import { DisplayValueAdapterOperation } from './../display-values-register-object.model';
import { ABaseModel } from './base.model';
import { DisplayValueStatus } from '../display-values-status.model';

export class ConsumerRequestOperationsModel extends ABaseModel {
  public consumerAccessRequest: DisplayValueStatus = null;
  public consumerAccessRequestStatus: number = null;
  public comment: string = null;
  public adapterOperation: DisplayValueAdapterOperation = null;

  constructor(init?: Partial<ConsumerRequestOperationsModel>) {
    super(init);
    if (init) {
      if (init.adapterOperation) {
        this.adapterOperation = new DisplayValueAdapterOperation(init.adapterOperation);
      }
      if (init.consumerAccessRequest) {
        this.consumerAccessRequest = new DisplayValueStatus(init.consumerAccessRequest);
        this.consumerAccessRequestStatus = this.consumerAccessRequest.status;
      }
    }

    
  }
}
