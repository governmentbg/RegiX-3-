import { ABaseModel } from '@tl/tl-common';

export class UsersModel extends ABaseModel {

  public userName: string = null;
  public name: string = null;
  public isActive: boolean = null;


  constructor(init?: Partial<UsersModel>) {
    super(init);
    if (init) {
      this.userName = init.userName;
      this.name = init.name;
      this.isActive = init.isActive;
    }
  }
}
