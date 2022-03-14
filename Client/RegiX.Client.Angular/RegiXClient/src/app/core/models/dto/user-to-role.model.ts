import { ABaseCreatableModel } from './base-creatable.model';
import { DisplayValue } from '../display-value.model';

export class UserToRoleModel extends ABaseCreatableModel {
  public user: DisplayValue = null;
  public userName: string = null;
  public role: DisplayValue = null;
  public roleName: string = null;

  constructor(init?: Partial<UserToRoleModel>) {
    super(init);
    if (init) {
      if (init.user) {
        this.user = new DisplayValue(init.user);
        this.userName = this.user.displayName;
      }
      if (init.role) {
        this.role = new DisplayValue(init.role);
        this.roleName = this.role.displayName;
      }
    }
  }
}
