import { ABaseModel } from '@tl/tl-common';
import { DisplayValueStatus } from '../../display-values-status.model';
import { DisplayValueAdapterOperation } from '../../display-values-register-object.model';


export class ConsumerRequestOperationsInModel extends ABaseModel {
  public consumerAccessRequest: DisplayValueStatus = null;
  public consumerAccessRequestStatus: number = null;
  public consumerSystemCertiicateId: number = null;
  public comment: string = null;
  public adapterOperation: DisplayValueAdapterOperation = null;
  public approvedRequestElementIds: number[] = null;

  constructor(init?: Partial<ConsumerRequestOperationsInModel>) {
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