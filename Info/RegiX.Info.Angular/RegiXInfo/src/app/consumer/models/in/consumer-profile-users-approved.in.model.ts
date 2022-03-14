import { ABaseModel } from '@tl/tl-common';
export class ConsumerProfileUsersApprovedInModel extends ABaseModel {
  public isActive: boolean;

  constructor(init?: Partial<ConsumerProfileUsersApprovedInModel>) {
    super(init);
    if (init) {
      this.isActive = init.isActive;
    }
  }
}
