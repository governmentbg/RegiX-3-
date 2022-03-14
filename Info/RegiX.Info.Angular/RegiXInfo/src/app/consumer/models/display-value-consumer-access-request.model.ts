import { DisplayValue } from './display-value.model';

export class DisplayValueConsumerAccessRequests extends DisplayValue {
  public registerObjectId: number;

  constructor(init?: Partial<DisplayValueConsumerAccessRequests>) {
    super(init);
    if (init) {
      this.registerObjectId = init.registerObjectId;
    }
  }
}