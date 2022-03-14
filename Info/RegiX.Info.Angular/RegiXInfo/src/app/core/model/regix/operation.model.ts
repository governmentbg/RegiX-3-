import { BaseModel } from './base.model';
import { OperationPropertyModel } from './operation-property.model';

export class OperationModel extends BaseModel {
  description: string;
  fullName: string;
  request: OperationPropertyModel;
  response: OperationPropertyModel;
  xsdRequest: string;
  xsdResponse: string;
  xsdCommon: string[];
  requestSampleData: string;
  responseSampleData: string;
  isDataLoading = false;
  isDataLoaded = false;

  public constructor(init?: Partial<OperationModel>) {
    super(init);
    if (init) {
      this.description = init.description;
      this.fullName = init.fullName;

      this.xsdRequest = init.xsdRequest;
      this.xsdResponse = init.xsdResponse;
      this.xsdCommon = init.xsdCommon;
      this.requestSampleData = init.requestSampleData;
      this.responseSampleData = init.responseSampleData;

      if (init.request) {
        this.request = new OperationPropertyModel(init.request);
      }
      if (init.response) {
        this.response = new OperationPropertyModel(init.response);
      }
    }
  }
}
