import { RegistryModel } from '../registy.model';

export class RegistryInModel {
  public name: string = null;
  public code: string = null;
  public administrationId: number = null;
  public description: string = null;

  constructor(init?: Partial<RegistryModel>) {
    if (init) {
      this.code = init.code;
      this.description = init.description;
      this.name = init.name;
      if (init.administration) {
        this.administrationId = init.administration.id;
      }
    }
  }
}
