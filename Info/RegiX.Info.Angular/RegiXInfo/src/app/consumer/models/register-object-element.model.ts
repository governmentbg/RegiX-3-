import { DisplayValue } from './display-value.model';

export class RegisterObjectElementModel{
  public id: any = null;
  public pathToRoot: string = null;
  public registerObject: DisplayValue = null;
  public name: string = null;
  public description: string = null;

  constructor(init?: Partial<RegisterObjectElementModel>) {
    if (init) {
      this.id = init.id;
      this.pathToRoot = init.pathToRoot;
      this.name = init.name;
      this.description = init.description;
      if (init.registerObject) {
        this.registerObject = new DisplayValue(init.registerObject);
      }
    }
  }
}
