import { DisplayValue } from './display-value.model';

export class ConsumerRequestElementsModel {
  public id: any = null;
  public consumerAccessRequestId: number;
  public registerObjectElement: DisplayValue = null;

  constructor(init?: Partial<ConsumerRequestElementsModel>) {
    if (init) {
      this.id = init.id;
      this.consumerAccessRequestId = init.consumerAccessRequestId;
      if (init.registerObjectElement) {
        this.registerObjectElement = new DisplayValue(init.registerObjectElement);
      }
    }
  }
}
