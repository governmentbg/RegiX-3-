import { ABaseCreatableModel } from './base-creatable.model';
import { DisplayValue } from '../display-value.model';

export class UserFavouriteReportModel extends ABaseCreatableModel {
  public user: DisplayValue = null;
  public report: DisplayValue = null;
  public adapterOperation: DisplayValue = null;
  public register: DisplayValue = null;
  public authority: DisplayValue = null;

  constructor(init?: Partial<UserFavouriteReportModel>) {
    super(init);
    if (init) {
      if (init.user) {
        this.user = new DisplayValue(init.user);
      }
      if (init.report) {
        this.report = new DisplayValue(init.report);
      }
      if (init.adapterOperation) {
        this.adapterOperation = new DisplayValue(init.adapterOperation);
      }
      if (init.register) {
        this.register = new DisplayValue(init.register);
      }
      if (init.authority) {
        this.authority = new DisplayValue(init.authority);
      }
    }
  }
}
