import { RoleModel } from '../role.model';

export class RoleInModel {
  public name: string = null;
  public reportIds: number[] = [];

  constructor(init?: Partial<RoleModel>) {
    if (init) {
      this.name = init.name;
    }
  }
}
