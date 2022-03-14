import { DisplayValue } from '../display-value.model';
import { ABaseCreatableModel } from './base-creatable.model';

export class ReportModel extends ABaseCreatableModel {
  public name: string = null;
  public code: string = null;
  public lawReason: string = null;
  public orderNumber: number = null;

  public isActive = false;

  public adapterOperation: DisplayValue = null;
  public adapterOperationName: string = null;

  public authority: DisplayValue = null;
  public authorityName: string = null;

  public register: DisplayValue = null;
  public registerName: string = null;
  public registerAuthority: DisplayValue = null;
  public registerAuthorityName: string = null;

  constructor(init?: Partial<ReportModel>) {
    super(init);
    if (init) {
      this.code = init.code;
      this.lawReason = init.lawReason;

      if (init.isActive) {
        this.isActive = init.isActive;
      }
      this.name = init.name;

      if (init.adapterOperation) {
        this.adapterOperation = new DisplayValue(init.adapterOperation);
        this.adapterOperationName = this.adapterOperation.displayName;
      }
      if (init.authority) {
        this.authority = new DisplayValue(init.authority);
        this.authorityName = this.authority.displayName;
      }
      if (init.register) {
        this.register = new DisplayValue(init.register);
        this.registerName = this.register.displayName;
      }
      if (init.registerAuthority) {
        this.registerAuthority = new DisplayValue(init.registerAuthority);
        this.registerAuthorityName = this.registerAuthority.displayName;
      }
    }
  }
}
