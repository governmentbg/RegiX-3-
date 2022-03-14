import { ABaseModel } from '@tl/tl-common';
export class ConsumerProfileUsersModel extends ABaseModel {
  public name: string;
  public email: string;
  public phoneNumber: number;
  public position: string;

  constructor(init?: Partial<ConsumerProfileUsersModel>) {
    super(init);
    if (init) {
      this.name = init.name;
      this.email = init.email;
      this.phoneNumber = init.phoneNumber;
      this.position = init.position;
    }
  }
}
