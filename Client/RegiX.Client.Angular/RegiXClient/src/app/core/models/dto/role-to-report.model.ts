import { ABaseCreatableModel } from './base-creatable.model';
import { DisplayValue } from '../display-value.model';

export class RoleToReportModel extends ABaseCreatableModel {
  public report: DisplayValue = null;
  public reportName: string = null;
  public role: DisplayValue = null;
  public roleName: string = null;

  constructor(init?: Partial<RoleToReportModel>) {
    super(init);
    if (init) {
      if (init.report) {
        this.report = new DisplayValue(init.report);
        this.reportName = this.report.displayName;
      }
      if (init.role) {
        this.role = new DisplayValue(init.role);
        this.roleName = this.role.displayName;
      }
    }
  }
}
