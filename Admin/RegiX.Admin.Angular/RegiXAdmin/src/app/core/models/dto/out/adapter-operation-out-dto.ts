import { DisplayValue } from 'src/app/core/models/display-value.model';
export class AdapterOperationOutDto extends DisplayValue {
  public description: string = null;

  constructor(init?: Partial<AdapterOperationOutDto>) {
    super(init)
    if (init) {
      this.description = init.description;
    }
  }
}