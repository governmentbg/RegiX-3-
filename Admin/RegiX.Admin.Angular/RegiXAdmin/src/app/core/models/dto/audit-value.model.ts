import { DisplayValue } from '../display-value.model';

export class AuditValueModel {
  public id: number = null;
  public auditTableId: number = null;
  public columnName: string = null;
  public oldValue: string = null;
  public newValue: string = null;
  
  public auditTable: DisplayValue = null;
  public auditTableName: string = null;
 
  constructor(init?: Partial<AuditValueModel>) {
    if (init) {
      this.id = init.id;
      this.columnName = init.columnName;
      this.oldValue = init.oldValue;
      this.newValue = init.newValue;
      
      if (init.auditTable) {
        this.auditTable = new DisplayValue(init.auditTable);
        this.auditTableName = init.auditTable.displayName;
        this.auditTableId = init.auditTable.id;
      }
    }
  }
}
