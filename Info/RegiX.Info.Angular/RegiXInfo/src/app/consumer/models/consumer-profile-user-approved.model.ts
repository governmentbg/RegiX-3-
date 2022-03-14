import { ABaseModel } from '@tl/tl-common';
export class ConsumerProfileUsersApprovedModel extends ABaseModel {
  public name: string;
  public email: string;
  public phoneNumber: number;
  public position: string;
  public isActive: boolean;

  constructor(init?: Partial<ConsumerProfileUsersApprovedModel>) {
    super(init);
    if (init) {
      this.name = init.name;
      this.email = init.email;
      this.phoneNumber = init.phoneNumber;
      this.position = init.position;
      this.isActive = init.isActive;
    }
  }
}
