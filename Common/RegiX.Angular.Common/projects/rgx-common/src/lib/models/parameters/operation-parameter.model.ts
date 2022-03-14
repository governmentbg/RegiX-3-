import { ParameterInfoModel } from './parameter-info.model';

export class OperationParameterModel {
  public parameterInfo: ParameterInfoModel = null;
  public childParamteters: OperationParameterModel[] = null;

  constructor(init?: Partial<OperationParameterModel>) {
    if (init) {
      if (init.parameterInfo) {
        this.parameterInfo = new ParameterInfoModel(init.parameterInfo);
      }
      if (init.childParamteters) {
        this.childParamteters = init.childParamteters;
      }
    }
  }
}
