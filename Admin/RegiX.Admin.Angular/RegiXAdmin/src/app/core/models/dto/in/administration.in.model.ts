import { AdministrationModel } from '../administration.model';

export class AdministrationInModel {
  public name: string = null;
  public code: string = null;
  public acronym: string = null;
  public administrationTypeId: number = null;
  public parentAuthorityId: number = null;
  public description: string = null;

  constructor(init?: Partial<AdministrationModel>) {
    if (init) {
      this.code = init.code;
      this.description = init.description;
      this.acronym = init.acronym;
      this.name = init.name;
      if (init.administrationType) {
        this.administrationTypeId = init.administrationType.id;
      }
      if (init.parentAuthority) {
        this.parentAuthorityId = init.parentAuthority.id;
      }
    }
  }
}
