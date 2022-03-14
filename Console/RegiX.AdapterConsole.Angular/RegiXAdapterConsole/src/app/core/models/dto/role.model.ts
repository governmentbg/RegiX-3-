import { ABaseModel } from '@tl/tl-common';

export class RoleModel extends ABaseModel{
  public name: string = null;

  constructor(init?: Partial<RoleModel>) {
    super(init);
    if (init) {
      this.name = init.name;
    }
  }
}
