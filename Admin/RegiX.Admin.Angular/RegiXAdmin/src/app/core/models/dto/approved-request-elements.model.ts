import { ABaseModel } from './base.model';
import { DisplayValue } from '../display-value.model';

export class ApprovedRequestElementsModel extends ABaseModel {
  public consumerAccessRequestId: number;
  public registerObjectElement: DisplayValue = null;

  constructor(init?: Partial<ApprovedRequestElementsModel>) {
    super(init);
    if (init) {
      this.consumerAccessRequestId = init.consumerAccessRequestId;
      if (init.registerObjectElement) {
        this.registerObjectElement = new DisplayValue(init.registerObjectElement);
      }
    }
  }
}