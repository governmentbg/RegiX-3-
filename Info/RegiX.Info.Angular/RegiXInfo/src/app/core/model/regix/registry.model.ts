import { ABaseCreatableModel } from './abase-creatable-model.model';
import { DisplayValue } from 'src/app/consumer/models/display-value.model';


export class RegistryModel extends ABaseCreatableModel {
  public name: string = null;
  public code: string = null;
  public description: string = null;
  public administration: DisplayValue = null;

  constructor(init?: Partial<RegistryModel>) {
    super(init);
    if (init) {
      this.name = init.name;
      this.code = init.code;
      this.description = init.description;
      if (init.administration) {
        this.administration = new DisplayValue(init.administration);
      }
    }
  }
}