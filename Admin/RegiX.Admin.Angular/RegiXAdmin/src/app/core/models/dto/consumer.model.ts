import { DisplayValue } from '../display-value.model';
import { ABaseCreatableModel } from './base-creatable.model';

export class ConsumerModel extends ABaseCreatableModel {
  public name: string = null;
  public description: string = null;
  public oid: string = null;
  public administration: DisplayValue = null;

  constructor(init?: Partial<ConsumerModel>) {
    super(init);
    if (init) {
      this.name = init.name;
      this.description = init.description;
      this.oid = init.oid;

      if (init.administration) {
        this.administration = new DisplayValue(init.administration);
      }
    }
  }
}
