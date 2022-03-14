import { ABaseModel } from '@tl/tl-common';

export abstract class ABaseCreatableModel extends ABaseModel {
  public modifiedOn: Date = null;
  public modifiedBy: string = null;
  public createdBy: string = null;

  constructor(init?: Partial<ABaseCreatableModel>) {
    super(init);
    if (init) {
      this.modifiedOn = new Date(init.modifiedOn);
      this.modifiedBy = init.modifiedBy;
      this.createdBy = init.createdBy;
    }
  }
}
