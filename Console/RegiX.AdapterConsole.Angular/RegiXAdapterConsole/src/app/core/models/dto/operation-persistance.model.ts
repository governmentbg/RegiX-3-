import { ABaseModel } from '@tl/tl-common';

export class OperationPersistanceModel extends ABaseModel {
  adapterOperationId: number;
  adapterOperationName: string;
  apiServiceCallId: number;
  rawResult: string;
  rawUnsignedResult: string;

  constructor(init?: Partial<OperationPersistanceModel>) {
    super(init);
    if (init) {
      this.adapterOperationId = init.adapterOperationId;
      this.adapterOperationName = init.adapterOperationName;
      this.apiServiceCallId = init.apiServiceCallId;
      this.rawResult = init.rawResult;
      this.rawUnsignedResult = init.rawUnsignedResult;
    }
  }
}
