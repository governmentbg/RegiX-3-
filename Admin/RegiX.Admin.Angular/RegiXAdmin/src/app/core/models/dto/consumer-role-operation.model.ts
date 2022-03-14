import { DisplayValue } from "../display-value.model";
import { ABaseCreatableModel } from './base-creatable.model';

export class ConsumerRoleOperationModel extends ABaseCreatableModel {
  public consumerRole: DisplayValue = null;
  public adapterOperationId: number = null;
  public adapterOperation: DisplayValue = null;
  public administrationDisplayName: string = null;
  public registerDisplayName: string = null;
  public adapterDisplayName: string = null;
  public adapterOperationDisplayName: string = null;

  public hasAccess: boolean = null;

  constructor(init?: Partial<ConsumerRoleOperationModel>) {
    super(init);
    if (init) {
      this.adapterOperationId = init.adapterOperationId;
      this.administrationDisplayName = init.administrationDisplayName;
      this.registerDisplayName = init.registerDisplayName;
      this.adapterDisplayName = init.adapterDisplayName;
      this.adapterOperationDisplayName = init.adapterOperationDisplayName;

      if (init.consumerRole)
        this.consumerRole = new DisplayValue(init.consumerRole);
    }
    if (init.adapterOperation) {
      this.adapterOperation = new DisplayValue(init.adapterOperation);
    }
    this.hasAccess = init.hasAccess;
  }
}
