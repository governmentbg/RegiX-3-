import { ABaseModel } from '@tl/tl-common';
import { DisplayValue } from '../display-value.model';

export class ConsumerRequestsModel extends ABaseModel {
  public name: string;
  public status: number;
  public documentNumber: string;
  public outDocumentNumber: string;

  public consumerProfile: DisplayValue = null;

  constructor(init?: Partial<ConsumerRequestsModel>) {
    super(init);
    if (init) {
      this.name = init.name;
      this.status = init.status;
      this.documentNumber = init.documentNumber;
      this.outDocumentNumber = init.outDocumentNumber;

      if (init.consumerProfile) {
        this.consumerProfile = new DisplayValue(init.consumerProfile);
      }
    }
  }
}
