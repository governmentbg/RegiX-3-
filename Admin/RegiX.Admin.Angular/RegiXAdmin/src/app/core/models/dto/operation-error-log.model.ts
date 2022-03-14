import { DisplayValue } from '../display-value.model';
import { ABaseModel } from './base.model';

export class OperationErrorLogModel extends ABaseModel {
  public logTime: Date = null;
  public errorMessage: string = null;
  public errorContent: string = null;
  public adapterOperation: DisplayValue = null;
  public adapterOperationName: string = null;
  public apiServiceCall: DisplayValue = null;
  public apiServiceCallName: string = null;
  public apiServiceOperations: DisplayValue = null;
  public apiServiceOperationsName: string = null;
  public createdOn: Date = null;
  public apiServiceConsumer: DisplayValue;
  public consumerCertificate: DisplayValue;
  public administration: DisplayValue;


  constructor(init?: Partial<OperationErrorLogModel>) {
    super(init);
    if (init) {
      this.logTime = new Date(init.logTime);
      this.createdOn = new Date(init.logTime);
      this.errorMessage = init.errorMessage;
      this.errorContent = init.errorContent;
      if (init.adapterOperation) {
        this.adapterOperation = new DisplayValue(init.adapterOperation);
        this.adapterOperationName = this.adapterOperation.displayName;
      }
      if (init.apiServiceCall) {
        this.apiServiceCall = new DisplayValue(init.apiServiceCall);
        this.apiServiceCallName = this.apiServiceCall.displayName;
      }
      if (init.apiServiceOperations) {
        this.apiServiceOperations = new DisplayValue(init.apiServiceOperations);
        this.apiServiceOperationsName = this.apiServiceOperations.displayName;
      }

      if (init.apiServiceConsumer) {
        this.apiServiceConsumer = new DisplayValue(init.apiServiceConsumer);
      }
      if (init.consumerCertificate) {
        this.consumerCertificate = new DisplayValue(init.consumerCertificate);
      }
      if (init.administration) {
        this.administration = new DisplayValue(init.administration);
      }
    }
  }
}
