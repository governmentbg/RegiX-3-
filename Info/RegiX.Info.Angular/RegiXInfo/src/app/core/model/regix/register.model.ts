import { BaseModel } from './base.model';
import { AdapterModel } from './adapter.model';

export class RegisterModel extends BaseModel {
  description: string;
  adapters: AdapterModel[];

  public constructor(init?: Partial<RegisterModel>) {
    super(init);
    if (init) {
      this.adapters = [];
      this.description = init.description;
      if (init.adapters) {
        init.adapters.map((d) => this.adapters.push(new AdapterModel(d)));
      }
    }
  }
}
