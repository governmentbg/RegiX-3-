import { AdapterModel } from '../adapters.model';

export class AdapterInModel {
  public name: string = null;
  public description: string = null;
  public contract: string = null;
  public assembly: string = null;
  public adapterUrl: string = null;
  public bindingConfigName: string = null;
  public bindingType: string = null;
  public registerId: number = null;
  public behaviour: string = null;

  constructor(init?: Partial<AdapterModel>) {
    if (init) {
      this.description = init.description;
      this.name = init.name;

      this.contract = init.contract;
      this.assembly = init.assembly;
      this.adapterUrl = init.adapterUrl;
      this.bindingConfigName = init.bindingConfigName;
      this.bindingType = init.bindingType;
      this.behaviour = init.behaviour;

      if (init.register) {
        this.registerId = init.register.id;
      }
    }
  }
}
