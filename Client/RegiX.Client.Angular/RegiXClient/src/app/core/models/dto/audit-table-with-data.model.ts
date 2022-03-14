import { ABaseCreatableModel } from './base-creatable.model';
import { DisplayValue } from '../display-value.model';
import { AuditValueModel } from './audit-value.model';

export class AuditTableWithDataModel extends ABaseCreatableModel {
  public action: string = null;
  public tableName: string = null;
  public authority: DisplayValue = null;
  public authorityName: string = null;
  public createdOn: Date = null;
  public auditValues: AuditValueModel[] = null;

  public user: DisplayValue;

  constructor(init?: Partial<AuditTableWithDataModel>) {
    super(init);
    if (init) {
      this.action = init.action;
      this.user = init.user;
      this.tableName = init.tableName;
      if (init.authority) {
        this.authority = new DisplayValue(init.authority);
        this.authorityName = this.authority.displayName;
      }
      if (init.user) {
        this.user = new DisplayValue(init.user);
      }
      if (init.createdOn) {
        this.createdOn = new Date(init.createdOn);
      }

      this.auditValues = [];
      init.auditValues.forEach(element => {
        this.auditValues.push(new AuditValueModel({
          id: element.id,
          auditTableId: element.auditTableId,
          columnName: element.columnName,
          oldValue: element.oldValue,
          newValue: element.newValue,
          auditTable: element.auditTable,
          auditTableName: element.auditTableName
        }))
      });
    }
  }
}