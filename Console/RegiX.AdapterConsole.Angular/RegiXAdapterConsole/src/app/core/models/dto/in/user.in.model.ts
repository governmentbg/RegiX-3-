import { UsersModel } from '../users.model';

export class UserInModel {
  public name: string = null;
  public userName: string = null;
  public isActive: boolean = null;
  public roleIds: number[] = [];

  constructor(init?: Partial<UsersModel>) {
    if (init) {
      this.userName = init.userName;
      this.isActive = init.isActive;
      this.name = init.name;
    }
  }
}
