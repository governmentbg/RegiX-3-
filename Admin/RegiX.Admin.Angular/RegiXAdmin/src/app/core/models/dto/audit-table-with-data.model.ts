import { AuditValueModel } from './audit-value.model';

export class AuditTableWithDataModel {
  public id: number = null;
  public userId: number = null;
  public userName: string = null;
  public auditDate: Date = null;
  public action: string = null;
  public tableName: string = null;
  public tableId: number = null;
  public ipAddress: string = null;
  public appName: string = null;
  public description: string = null;
  public auditValues: AuditValueModel[] = null;

  constructor(init?: Partial<AuditTableWithDataModel>) {
    if (init) {
      this.id = init.id;
      this.userName = init.userName;
      this.userId = init.userId;
      this.auditDate = new Date(init.auditDate);
      this.action = init.action;

      if (init.tableId) {
        this.tableName = init.tableName;
        this.tableId = init.tableId;     
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

      this.ipAddress = init.ipAddress;
      this.appName = init.appName;
      this.description = init.description;
    }
  }
}