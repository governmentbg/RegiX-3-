import { ABaseModel } from '@tl/tl-common';
import { DisplayValue } from "../display-value.model";
import { OperationParameterWithValueModel } from '../operation-values/operation-parameter-with-value.model';

export class OperationCallModel extends ABaseModel {

  public apiServiceCallId: number = null;
  public startTime: Date = null;

  public requestParamsValues?: OperationParameterWithValueModel[] = [];
  public responseParamsValues?: OperationParameterWithValueModel[] = [];

  public adapterOperation: DisplayValue = null;
  public adapterOperationName: string = null;

  public assignedTo?: DisplayValue = null;
  public assignedToName: string = null;

  constructor(init?: Partial<OperationCallModel>) {
    super(init);
    if (init) {
      this.apiServiceCallId = init.apiServiceCallId;
      this.startTime = init.startTime;

      if (init.adapterOperation) {
        this.adapterOperation = new DisplayValue(init.adapterOperation);
        this.adapterOperationName = this.adapterOperation.displayName;
      }

      if (init.assignedTo) {
        this.assignedTo = new DisplayValue(init.assignedTo);
        this.assignedToName = this.assignedTo.displayName;
      }

      if (init.requestParamsValues !== null) {
        init.requestParamsValues.forEach(element => {
          this.requestParamsValues.push(new OperationParameterWithValueModel({
            name: element.name,
            value: element.value,}))
        })
      }

      if (init.responseParamsValues !== null) {
        init.responseParamsValues.forEach(element => {
          this.responseParamsValues.push(new OperationParameterWithValueModel({
            name: element.name,
            value: element.value,}))
        })
      }
    }
  }
}
