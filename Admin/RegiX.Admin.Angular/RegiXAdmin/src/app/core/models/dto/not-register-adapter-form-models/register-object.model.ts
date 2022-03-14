import { RegisterObjectElementModel } from './register-object-element.model';

export class RegisterObjectModel {

  public description: string = null;
  public fullName: string = null;
  public name: string = null;
  public registerElements: RegisterObjectElementModel[] = [];

  constructor(init?: Partial<RegisterObjectModel>) {
    if (init) {
      this.name = init.name;
      this.description = init.description;
      this.fullName = init.fullName;

      if(init.registerElements){
        init.registerElements.map(d => this.registerElements.push(new RegisterObjectElementModel(d)))
      }
    }
  }
}
