import { DisplayValue } from './../display-value.model';
import { ABaseCreatableModel } from './base-creatable.model';

export class ConsumerOperationModel extends ABaseCreatableModel {
    public adapterOperation: DisplayValue = null;
    public consumerRole: DisplayValue = null;
    public hasAccess: boolean = null;
  
    constructor(init?: Partial<ConsumerOperationModel>) {
      super(init);
      if (init) {
        if (init.adapterOperation) {
          this.adapterOperation = new DisplayValue(init.adapterOperation);
        }
        if (init.consumerRole) {
          this.consumerRole = new DisplayValue(init.consumerRole);
        }
        this.hasAccess = init.hasAccess;
      }
    }
  }
