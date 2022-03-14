import { ABaseModel } from '@tl/tl-common';
import { DisplayValue } from '../display-value.model';
import { OperationParameterWithValueModel } from '../operation-values/operation-parameter-with-value.model';

export class ReturnedCallModel extends ABaseModel {
  public startTime: Date = null;
  public adapterOperation: DisplayValue = null;
  public adapterOperationName: string = null;
  public returnedBy: DisplayValue = null;
  public returnedByName: string = null;
  public requestParamsValues?: OperationParameterWithValueModel[] = [];
  public responseParamsValues?: OperationParameterWithValueModel[] = [];

  constructor(init?: Partial<ReturnedCallModel>) {
    super(init);
    if (init) {
      this.startTime = init.startTime;

      if (init.adapterOperation) {
        this.adapterOperation = new DisplayValue(init.adapterOperation);
        this.adapterOperationName = this.adapterOperation.displayName;
      }

      if (init.returnedBy) {
        this.returnedBy = new DisplayValue(init.returnedBy);
        this.returnedByName = this.returnedBy.displayName;
      }

      if (
        init.responseParamsValues !== null &&
        init.responseParamsValues !== undefined
      ) {
        init.responseParamsValues.forEach(element => {
          this.responseParamsValues.push(
            new OperationParameterWithValueModel({
              name: element.name,
              value: element.value
            })
          );
        });
      }
      if (
        init.requestParamsValues !== null &&
        init.requestParamsValues !== undefined
      ) {
        init.requestParamsValues.forEach(element => {
          this.requestParamsValues.push(
            new OperationParameterWithValueModel({
              name: element.name,
              value: element.value
            })
          );
        });
      }
    }
  }
}
