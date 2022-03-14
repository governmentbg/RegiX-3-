import { ABaseCreatableModel } from './base-creatable.model';
import { UsersEauthModel } from './users-eauth.model';

export class MyProfileModel extends ABaseCreatableModel {
  public userName: string = null;
  public name: string = null;
  public email: string = null;
  public position: string = null;
  public usersEauth?: UsersEauthModel;

  constructor(init?: Partial<MyProfileModel>) {
    super(init);
    if (init) {
      this.userName = init.userName;
      this.email = init.email;
      this.name = init.name;
      this.position = init.position;
      if(init.usersEauth){
        this.usersEauth = new UsersEauthModel(init.usersEauth);
      }
    }
  }
}
