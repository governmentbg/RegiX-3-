
import { ABaseModel } from '@tl/tl-common';

export class ConsumerRequestsInModel extends ABaseModel {
  public name: string;
  public status: number;
  public consumerSystemId: number;

  constructor(init?: Partial<ConsumerRequestsInModel>) {
    super(init);
    if (init) {
      this.name = init.name;
      this.status = init.status;
      this.consumerSystemId = init.consumerSystemId;
    }
  }
}