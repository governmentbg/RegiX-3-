import { DisplayValue } from './../display-value.model';
import { ABaseModel } from '@tl/tl-common';

export class ConsumerSystemsModel extends ABaseModel {
  public name: string = null;
  public staticIP: string = null;
  public description: string = null;

  public apiServiceConsumer: DisplayValue;
  public consumerProfile: DisplayValue;
  public consumerProfileName: string;

  constructor(init?: Partial<ConsumerSystemsModel>) {
    super(init);
    if (init) {
      this.name = init.name;
      this.staticIP = init.staticIP;
      this.description = init.description;

      if (init.apiServiceConsumer) {
        this.apiServiceConsumer = new DisplayValue(init.apiServiceConsumer);
      }
      if (init.consumerProfile) {
        this.consumerProfile = new DisplayValue(init.consumerProfile);
        this.consumerProfileName = init.consumerProfile.displayName;
      }
    }
  }
}
