import { DisplayValue } from '../display-value.model';
import { ABaseModel } from './base.model';

export class AsyncReportModel extends ABaseModel {
  apiServiceCallId: number = null;
  adapterOperationId: number = null;
  userId: number = null;
  submittedOn: Date = null;
  receivedOn?: Date = null;
  result: string = null;
  adapterOperationDisplayName: string = null;

  constructor(init?: Partial<AsyncReportModel>) {
    super(init);
    if (init) {
      this.apiServiceCallId = init.apiServiceCallId;
      this.adapterOperationId = init.adapterOperationId;
      this.userId = init.userId;
      this.submittedOn = init.submittedOn;
      this.receivedOn = init.receivedOn;
      this.result = init.result;
      this.adapterOperationDisplayName = init.adapterOperationDisplayName;
    }
  }
}
