import { DisplayValue } from '../display-value.model';
import { ABaseCreatableModel } from './base-creatable.model';

export class UsersModel extends ABaseCreatableModel {
  public userName: string = null;
  public name: string = null;
  public active: boolean = null;
  public email: string = null;
  public isLockedOut: boolean = null;
  public lastLoginDate: string = null;
  public isAdmin: boolean = null;
  public administration: DisplayValue = null;
  public administrationName: string = null;

  constructor(init?: Partial<UsersModel>) {
    super(init);
    if (init) {
      this.userName = init.userName;
      this.name = init.name;
      this.active = init.active;
      this.email = init.email;
      this.isLockedOut = init.isLockedOut;
      this.lastLoginDate = init.lastLoginDate;
      if (init.administration) {
        this.administration = new DisplayValue(init.administration);
        this.administrationName = this.administration.displayName;
      }
    }
  }
}
