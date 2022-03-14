
import { ABaseModel } from '@tl/tl-common';

export class UserToReportModel extends ABaseModel {
  public name: string = null;

  constructor(init?: Partial<UserToReportModel>) {
    super(init);
    if (init) {
      this.name = init.name;
    }
  }
}
