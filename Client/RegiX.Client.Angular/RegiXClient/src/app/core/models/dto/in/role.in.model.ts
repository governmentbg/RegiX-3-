import { RoleModel } from '../role.model';

export class RoleInModel {
  public name: string = null;
  public roleType: number = null;
  public authorityId: number = null;
  public reportIds: number[] = [];
  public userIds: number[] = [];

  constructor(init?: Partial<RoleModel>) {
    if (init) {
      this.roleType = init.roleType;
      this.name = init.name;
      if (init.authority) {
        this.authorityId = init.authority.id;
      }
    }
  }
}
