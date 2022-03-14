import { ABaseModel } from '@tl/tl-common';
import { OperationParameterModel } from '../operations/operation-parameter.model';

export class AdapterOperationModel extends ABaseModel {
  public name: string = null;
  public description: string = null;
  public contract: string = null;

  public requestMetadata?: OperationParameterModel[] = [];
  public responseMetadata?: OperationParameterModel[] = [];

  constructor(init?: Partial<AdapterOperationModel>) {
    super(init);
    if (init) {
      this.name = init.name;
      this.description = init.description;
      this.contract = init.contract;
    }
    if (init.requestMetadata !== null && init.responseMetadata !== undefined) {
      init.requestMetadata.forEach(element => {
        this.requestMetadata.push(new OperationParameterModel({
          parameterInfo: element.parameterInfo,
          childParamteters: element.childParamteters,}))
      })
    }

    if (init.responseMetadata !== null && init.responseMetadata !== undefined) {
      init.responseMetadata.forEach(element => {
        this.responseMetadata.push(new OperationParameterModel({
          parameterInfo: element.parameterInfo,
          childParamteters: element.childParamteters,}))
      })
    }
  }
}
