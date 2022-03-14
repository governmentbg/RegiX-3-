import { DisplayValue } from './display-value.model';

export class DisplayValueConsumerRequest extends DisplayValue {
  public status: number;

  constructor(init?: Partial<DisplayValueConsumerRequest>) {
    super(init);
    if (init) {
      this.status = init.status;
    }
  }
}