import { DisplayValue } from '../display-value.model';
import { ABaseCreatableModel } from './base-creatable.model';

export class AdministrationModel extends ABaseCreatableModel {
  public name: string = null;
  public displayName: string = null;
  public code: string = null;
  public acronym: string = null;
  public oid: string = null;
  public certificateThumbprint: string = null;
  public certificateStore: number = null;
  public parentAuthority: DisplayValue = null;
  public parentAuthorityName: string = null;
  public isMultitenantAuthority: boolean = null;

  constructor(init?: Partial<AdministrationModel>) {
    super(init);
    if (init) {
      this.code = init.code;
      this.displayName = init.displayName;
      this.certificateThumbprint = init.certificateThumbprint;
      this.certificateStore = init.certificateStore;
      this.acronym = init.acronym;
      this.name = init.name;
      this.oid = init.oid;
      this.isMultitenantAuthority = init.isMultitenantAuthority;
      if (init.parentAuthority) {
        this.parentAuthority = new DisplayValue(init.parentAuthority);
        this.parentAuthorityName = this.parentAuthority.displayName;
      }
    }
  }
}
