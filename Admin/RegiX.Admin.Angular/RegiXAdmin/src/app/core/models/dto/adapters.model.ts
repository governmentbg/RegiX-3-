import { DisplayValue } from '../display-value.model';
import { ABaseCreatableModel } from './base-creatable.model';

export class AdapterModel extends ABaseCreatableModel {
  public name: string = null;
  public register: DisplayValue = null;
  public description: string = null;

  public contract: string = null;
  public assembly: string = null;
  public adapterUrl: string = null;
  public bindingConfigName: string = null;
  public bindingType: string = null;
  public behaviour: string = null;
  public hostAvailability = false;

  constructor(init?: Partial<AdapterModel>) {
    super(init);
    if (init) {
      this.description = init.description;
      this.name = init.name;

      this.contract = init.contract;
      this.assembly = init.assembly;
      this.adapterUrl = init.adapterUrl;
      this.bindingConfigName = init.bindingConfigName;
      this.bindingType = init.bindingType;
      this.behaviour = init.behaviour;
      this.hostAvailability = init.hostAvailability;

      if (init.register) {
        this.register = new DisplayValue(init.register);
      }
    }
  }
}
