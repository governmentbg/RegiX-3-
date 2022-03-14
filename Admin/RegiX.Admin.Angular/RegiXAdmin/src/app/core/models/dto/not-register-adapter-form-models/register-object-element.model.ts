export class RegisterObjectElementModel {

  public pathToRoot: string = null;
  public name: string = null;
  public description: string = null;

  constructor(init?: Partial<RegisterObjectElementModel>) {
    if (init) {
      this.pathToRoot = init.pathToRoot;
      this.name = init.name;
      this.description = init.description;
    }
  }
}
