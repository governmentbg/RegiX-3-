import { EnumValueModel } from './enum-value.model';

export class ParameterTypeModel {
  public type?: string = null;
  public enumValues?: EnumValueModel[] = null;

  constructor(init?: Partial<ParameterTypeModel>) {
    if (init) {
      this.type = init.type;
    }
  }
}
