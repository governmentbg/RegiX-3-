import { DisplayValue } from '../display-value.model';
import { ABaseModel } from '@tl/tl-common';

export class  OperationsToRolesModel extends ABaseModel {
  public adapterOperation: DisplayValue = null;
  public role: DisplayValue = null;

  constructor(init?: Partial<OperationsToRolesModel>) {
    super(init);
    if (init) {
      if (init.adapterOperation) {
        this.adapterOperation = new DisplayValue(init.adapterOperation);
      }
      if (init.role) {
        this.role = new DisplayValue(init.role);
      }
    }
  }
}
