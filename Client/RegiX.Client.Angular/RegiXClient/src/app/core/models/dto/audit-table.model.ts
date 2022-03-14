import { ABaseCreatableModel } from './base-creatable.model';
import { DisplayValue } from '../display-value.model';

export class AuditTableModel extends ABaseCreatableModel {
  public user: string = null;

  public action: string = null;
  public tableName: string = null;
  public authority: DisplayValue = null;
  public authorityName: string = null;
  public createdOn: Date = null;

  constructor(init?: Partial<AuditTableModel>) {
    super(init);
    if (init) {
      this.action = init.action;
      this.user = init.user;
      this.tableName = init.tableName;
      if (init.authority) {
        this.authority = new DisplayValue(init.authority);
        this.authorityName = this.authority.displayName;
      }
      if (init.createdOn) {
        this.createdOn = new Date(init.createdOn);
      }
    }
  }
}
