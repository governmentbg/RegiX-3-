import { DisplayValue } from './display-value.model';

export class DisplayValueAdapterOperation extends DisplayValue {
  public registerObjectId: number;
  public description: string;

  constructor(init?: Partial<DisplayValueAdapterOperation>) {
    super(init);
    if (init) {
      this.description = init.description;
      this.registerObjectId = init.registerObjectId;
    }
  }
}
