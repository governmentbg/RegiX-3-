import { ConsumerModel } from './consumer.model';
import { ConsumerUserModel } from './consumer-user.model';

export class ConsumerPorofileRegistrationModel {
  public name: string = null;
  public userName: string = null;
  public email: string = null;
  public password: string = null;
  public additionalAttributes: {
    [name: string]: string;
  } = null;
  // public additionalAttributes: {
  //   key: string;
  //   value: string;
  // }[] = [];

  constructor(init: Partial<ConsumerPorofileRegistrationModel>) {
    this.additionalAttributes = {};
    if (init) {
      this.name = init.name;
      this.userName = init.userName;
      this.email = init.email;
      this.password = init.password;
      this.additionalAttributes = init.additionalAttributes;
    }
  }

}
