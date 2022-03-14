import { DisplayValue } from '../display-value.model';
import { ABaseModel } from '@tl/tl-common';

export class UserToRoleModel extends ABaseModel {
  public user: DisplayValue;
  public role: DisplayValue;

  constructor(init?: Partial<UserToRoleModel>) {
    super(init);
    if (init) {
      if (init.user) {
        this.user = new DisplayValue(init.user);
      }
      if (init.role) {
        this.role = new DisplayValue(init.role);
      }
    }
  }
}
