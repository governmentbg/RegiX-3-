import { DisplayValue } from '../display-value.model';
import { ABaseCreatableModel } from './base-creatable.model';
import { AdapterOperationModel } from './adapter-operation.model';

export class RegistryModel extends ABaseCreatableModel {
  public name: string = null;
  public code: string = null;
  public clientName: string = null;
  public bindingName: string = null;
  public authority: DisplayValue = null;
  public operations: AdapterOperationModel[] = [];

  constructor(init?: Partial<RegistryModel>) {
    super(init);
    if (init) {
      this.code = init.code;
      this.clientName = init.clientName;
      this.bindingName = init.bindingName;
      this.name = init.name;
      if (init.authority) {
        this.authority = new DisplayValue(init.authority);
      }
    }
  }
}
