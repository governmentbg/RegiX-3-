import { DisplayValue } from 'src/app/core/models/display-value.model';
import { ABaseCreatableModel } from './base-creatable.model';

export class UsersModel extends ABaseCreatableModel {
  public userName: string = null;
  public name: string = null;
  public email: string = null;
  public position: string = null;
  public isActive: boolean = null;
  public userRoles: string[] = null;
  // public isLockedOut: boolean = null;
  public authority?: DisplayValue = null;

  constructor(init?: Partial<UsersModel>) {
    super(init);
    if (init) {
      this.userName = init.userName;
      this.email = init.email;
      this.name = init.name;
      this.position = init.position;
      this.isActive = init.isActive;
      this.userRoles = init.userRoles;
      // this.isLockedOut = init.isLockedOut;
      if (init.authority) {
        this.authority = new DisplayValue(init?.authority);
      }
    }
  }
}
