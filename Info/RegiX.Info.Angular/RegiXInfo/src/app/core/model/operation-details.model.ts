import { BaseModel } from './regix/base.model';import { OperationPropertyModel } from './regix/operation-property.model';


export class OperationDetailsModel extends BaseModel {
  description: string;
  fullName: string;
  request: OperationPropertyModel;
  response: OperationPropertyModel;
  requestXSD: string;
  responseXSD: string;
  commonXSD: string[];
  sampleRequestXML: string;
  sampleResponseXML: string;
  isDataLoading = false;
  isDataLoaded = false;

  public constructor(init?: Partial<OperationDetailsModel>) {
    super(init);
    if (init) {
      this.description = init.description;
      this.fullName = init.fullName;

      this.requestXSD = init.requestXSD;
      this.responseXSD = init.responseXSD;
      this.commonXSD = init.commonXSD;
      this.sampleRequestXML = init.sampleRequestXML;
      this.sampleResponseXML = init.sampleResponseXML;

      if (init.request) {
        this.request = new OperationPropertyModel(init.request);
      }
      if (init.response) {
        this.response = new OperationPropertyModel(init.response);
      }
    }
  }
}
