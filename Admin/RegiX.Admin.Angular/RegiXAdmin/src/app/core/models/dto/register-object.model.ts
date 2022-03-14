import { DisplayValue } from '../display-value.model';
import { ABaseCreatableModel } from './base-creatable.model';

export class RegisterObjectModel extends ABaseCreatableModel {
  public fullName: string = null;
  public registerAdapter: DisplayValue = null;
  public name: string = null;
  public description: string = null;
  public content: string = null;
  public xslt: string = null;

  constructor(init?: Partial<RegisterObjectModel>) {
    super(init);
    if (init) {
      this.content = init.content;
      this.xslt = init.xslt;
      this.fullName = init.fullName;
      this.name = init.name;
      this.description = init.description;
      if (init.registerAdapter) {
        this.registerAdapter = new DisplayValue(init.registerAdapter);
      }
    }
  }
}
