
import { ABaseModel } from '@tl/tl-common';
import { DisplayValue } from '../display-value.model';

export class ConsumerRequestsModel extends ABaseModel {
  public name: string;
  public consumerSystem: DisplayValue;
  public statusChanged: boolean = false;
  
  constructor(init?: Partial<ConsumerRequestsModel>) {
    super(init);
    if (init) {
      this.name = init.name;

      if (init.consumerSystem) {
        this.consumerSystem = new DisplayValue(init.consumerSystem);
      }
    }
  }
}