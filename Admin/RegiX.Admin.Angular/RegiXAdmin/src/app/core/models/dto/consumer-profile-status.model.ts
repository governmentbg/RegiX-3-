import { ABaseModel } from '@tl/tl-common';
import { DisplayValue } from '../display-value.model';

export class ConsumerProfileStatusModel extends ABaseModel {
  public oldStatus: string;
  public newStatus: string;
  public comment: string;
  public date: Date;

  public consumerProfile: DisplayValue = null;

  constructor(init?: Partial<ConsumerProfileStatusModel>) {
    super(init);
    if (init) {
      this.oldStatus = init.oldStatus;
      this.newStatus = init.newStatus;
      this.comment = init.comment;
      this.date = init.date;

      if (init.consumerProfile) {
        this.consumerProfile = new DisplayValue(init.consumerProfile);
      }
    }
  }
}
