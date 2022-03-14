import { ABaseModel } from '@tl/tl-common';

export class ConsumerAccessRequstsStatusModel extends ABaseModel {
  public oldStatus: string;
  public newStatus: string;
  public comment: string;
  public date: Date;
  public consumerAccessRequestId: number;

  constructor(init?: Partial<ConsumerAccessRequstsStatusModel>) {
    super(init);
    if (init) {
      this.oldStatus = init.oldStatus;
      this.newStatus = init.newStatus;
      this.comment = init.comment;
      this.date = init.date;
      this.consumerAccessRequestId = init.consumerAccessRequestId;
    }
  }
}
