import { UsersModel } from '../users.model';

export class UserInModel {
  public name: string = null;
  public userName: string = null;
  public email: string = null;
  public position: string = null;
  public isActive: boolean = null;
  public authorityId: number = null;
  public reportIds: number[] = [];
  public roleIds: number[] = [];

  constructor(init?: Partial<UsersModel>) {
    if (init) {
      this.name = init.name;
      this.position = init.position;
      this.userName = init.userName;
      this.email = init.email;
      this.isActive = init.isActive;
      this.position = init.position;
    }
  }
}
