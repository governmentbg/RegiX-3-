import { AdministrationModel } from '../administration.model';

export class AdministrationInModel {
  public name: string = null;
  public displayName: string = null;
  public code: string = null;
  public acronym: string = null;
  public oid: string = null;
  public certificateThumbprint: string = null;
  public certificateStore: number = null;
  public parentAuthorityId: number = null;
  public isMultitenantAuthority: boolean = null;

  constructor(init?: Partial<AdministrationModel>) {
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
        this.parentAuthorityId = init.parentAuthority.id;
      }
    }
  }
}
