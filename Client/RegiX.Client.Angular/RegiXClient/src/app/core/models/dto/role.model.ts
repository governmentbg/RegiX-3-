import { ABaseCreatableModel } from './base-creatable.model';
import { DisplayValue } from '../display-value.model';

export class RoleModel extends ABaseCreatableModel {
  public name: string = null;
  public roleType: number = null;
  public authority: DisplayValue = null;
  public authorityName: string = null;

  constructor(init?: Partial<RoleModel>) {
    super(init);
    if (init) {
      this.roleType = init.roleType;
      this.name = init.name;
      if (init.authority) {
        this.authority = new DisplayValue(init.authority);
        this.authorityName = this.authority.displayName;
      }
    }
  }
}
