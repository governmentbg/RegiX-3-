import { BaseModel } from './regix/base.model';

export class RegisterListModel extends BaseModel {
  description: string;
  public constructor(init?: Partial<RegisterListModel>) {
      super(init);
      if (init) {
        this.description = init.description;
      }
  }
}
