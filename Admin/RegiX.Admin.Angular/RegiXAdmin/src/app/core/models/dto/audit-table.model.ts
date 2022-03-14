import { DisplayValue } from '../display-value.model';
import { AuditTablesService } from '../../services/rest/audit-tables.service';

export class AuditTableModel {
  public id: number = null;
  public userName: string = null;
  public userId: number = null;
  public tableName: string = null;
  public auditDate: Date = null;
  public action: string = null;
  public ipAddress: string = null;
  public appName: string = null;
  public description: string = null;

  constructor(init?: Partial<AuditTableModel>) {
    if (init) {
      this.id = init.id;
      this.userName = init.userName;
      this.userId = init.userId;
      this.tableName = init.tableName;
      this.auditDate = new Date(init.auditDate);
      this.action = init.action;
      this.ipAddress = init.ipAddress;
      this.appName = init.appName;
      this.description = init.description;
    }
  }
}

