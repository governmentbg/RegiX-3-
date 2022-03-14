import { ABaseModel } from '@tl/tl-common';
import { DisplayValue } from '../display-value.model';

export class ConsumerRequestStatusModel extends ABaseModel {
  public name: string;
  public date: Date;
  public comment: string;
  public oldStatus: number;
  public newStatus: number;

  public consumerRequest: DisplayValue = null;

  constructor(init?: Partial<ConsumerRequestStatusModel>) {
    super(init);
    if (init) {
      this.name = init.name;
      this.date = init.date;
      this.comment = init.comment;
      this.oldStatus = init.oldStatus;
      this.newStatus = init.newStatus; //add service and components next

      if (init.consumerRequest) {
        this.consumerRequest = new DisplayValue(init.consumerRequest);
      }
    }
  }
}
