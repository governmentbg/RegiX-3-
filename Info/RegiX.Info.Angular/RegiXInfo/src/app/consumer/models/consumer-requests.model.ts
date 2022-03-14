import { DisplayValue } from './display-value.model';
import { ABaseModel } from '@tl/tl-common';

export class ConsumerRequestsModel extends ABaseModel {
  public name: string;
  public status: number;

  public consumerSystem: DisplayValue;

  constructor(init?: Partial<ConsumerRequestsModel>) {
    super(init);
    if (init) {
      this.name = init.name;
      this.status = init.status;

      if (init.consumerSystem) {
        this.consumerSystem = new DisplayValue(init.consumerSystem);
      }
    }
  }
}
