import { DisplayValue } from '../display-value.model';
import { ABaseCreatableModel } from './base-creatable.model';

export class AdministrationModel extends ABaseCreatableModel {
  public name: string = null;
  public code: string = null;
  public acronym: string = null;
  public administrationType: DisplayValue = null;
  public administrationTypeName: string = null;
  public parentAuthority: DisplayValue = null;
  public parentAuthorityName: string = null;
  public description: string = null;

  constructor(init?: Partial<AdministrationModel>) {
    super(init);
    if (init) {
      this.code = init.code;
      this.description = init.description;
      this.acronym = init.acronym;
      this.name = init.name;
      if (init.administrationType) {
        this.administrationType = new DisplayValue(init.administrationType);
        this.administrationTypeName = this.administrationType.displayName;
      }
      if (init.parentAuthority) {
        this.parentAuthority = new DisplayValue(init.parentAuthority);
        this.parentAuthorityName = this.parentAuthority.displayName;
      }
    }
  }
}
