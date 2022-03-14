import { ABaseCreatableModel } from './base-creatable.model';
import { DisplayValue } from '../display-value.model';

export class ReportExecutionsModel extends ABaseCreatableModel {
  public authority: DisplayValue = null;
  public report: DisplayValue = null;
  public user: DisplayValue = null;
  public reportExecutionTime: Date = null;
  public apiServiceCallId: number = null;
  public contextEmployeeAdditionalId: string = null;
  public contextServiceType: string = null;
  public contextServiceURI: string = null;
  public contextLawReason: string = null;
  public hasError: boolean = null;
  public registerErrorMessage: string = null;
  public unhandledErrorMessage: string = null;

  constructor(init?: Partial<ReportExecutionsModel>) {
    super(init);
    if (init) {
      this.reportExecutionTime = new Date(init.reportExecutionTime);
      this.apiServiceCallId = init.apiServiceCallId;
      this.contextEmployeeAdditionalId = init.contextEmployeeAdditionalId;
      this.contextServiceType = init.contextServiceType;
      this.contextServiceURI = init.contextServiceURI;
      this.contextLawReason = init.contextLawReason;
      this.hasError = init.hasError;
      this.registerErrorMessage = init.registerErrorMessage;
      this.unhandledErrorMessage = init.unhandledErrorMessage;
      if (init.authority) {
        this.authority = new DisplayValue(init.authority);
      }
      if (init.report) {
        this.report = new DisplayValue(init.report);
      }
      if (init.user) {
        this.user = new DisplayValue(init.user);
      }
    }
  }
}
