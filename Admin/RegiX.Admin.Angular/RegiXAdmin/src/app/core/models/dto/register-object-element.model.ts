import { DisplayValue } from '../display-value.model';
import { ABaseCreatableModel } from './base-creatable.model';

export class RegisterObjectElementModel extends ABaseCreatableModel {
  public pathToRoot: string = null;
  public registerObject: DisplayValue = null;
  public name: string = null;
  public description: string = null;

  constructor(init?: Partial<RegisterObjectElementModel>) {
    super(init);
    if (init) {
      this.pathToRoot = init.pathToRoot;
      this.name = init.name;
      this.description = init.description;
      if (init.registerObject) {
        this.registerObject = new DisplayValue(init.registerObject);
      }
    }
  }
}
