import { ParameterTypeModel } from './parameter-type.model';

export enum IdentifierTypeEnum {
  EGN = 1,
  LNCH = 2,
  EGN_LNCH = 3,
  EIK = 4,
  EGN_EIK = 5,
  ALL = 7,
}

export class ParameterInfoModel {
  public parameterName?: string = null;
  public parameterLabel?: string = null;
  public regexExpression?: string = null;
  public isRequired?: boolean = null;
  public isXmlElement?: boolean = null;
  public orderNumber?: string = null;
  public parameterType?: ParameterTypeModel = null;
  public identifierType?: IdentifierTypeEnum = null;

  constructor(init?: Partial<ParameterInfoModel>) {
    if (init) {
      this.parameterName = init.parameterName;
      this.regexExpression = init.regexExpression;
      this.parameterLabel = init.parameterLabel;
      this.isRequired = init.isRequired;
      this.isXmlElement = init.isXmlElement;
      this.orderNumber = init.orderNumber;
      this.parameterType = init.parameterType;
      this.identifierType = init.identifierType;
    }
  }
}
