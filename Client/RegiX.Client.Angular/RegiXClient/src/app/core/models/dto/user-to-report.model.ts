import { ABaseCreatableModel } from './base-creatable.model';
import { DisplayValue } from '../display-value.model';

export class UserToReportModel extends ABaseCreatableModel {
  public user: DisplayValue = null;
  public userName: string = null;
  public report: DisplayValue = null;
  public reportName: string = null;

  constructor(init?: Partial<UserToReportModel>) {
    super(init);
    if (init) {
      if (init.user) {
        this.user = new DisplayValue(init.user);
        this.userName = this.user.displayName;
      }
      if (init.report) {
        this.report = new DisplayValue(init.report);
        this.reportName = this.report.displayName;
      }
    }
  }
}
