import { ABaseModel } from './base.model';

export abstract class ABaseCreatableModel extends ABaseModel {
  public updatedOn: Date = null;
  public updatedBy: string = null;
  public createdBy: string = null;

  constructor(init?: Partial<ABaseCreatableModel>) {
    super(init);
    if (init) {
      this.updatedOn = new Date(init.updatedOn);
      this.updatedBy = init.updatedBy;
      this.createdBy = init.createdBy;
    }
  }
}
