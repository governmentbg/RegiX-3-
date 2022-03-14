import { DisplayValue } from '../display-value.model';

export class ConsumerAccessRequestsInModel {
  public lawReason: string;
  public relatedServices: string;
  public relatedServicesCode: string;
  public consumerRequestId: number;

  public elementsIds: number[];

  public adapterOperation: DisplayValue;
  public consumerSystemCertificate: DisplayValue;

  constructor(init?: Partial<ConsumerAccessRequestsInModel>) {
    if (init) {
      this.lawReason = init.lawReason;
      this.relatedServices = init.relatedServices;
      this.relatedServicesCode = init.relatedServicesCode;
      if (init.adapterOperation) {
        this.adapterOperation = new DisplayValue(init.adapterOperation);
      }
      if (init.consumerSystemCertificate) {
        this.consumerSystemCertificate = new DisplayValue(init.consumerSystemCertificate);
      }
    }
  }
}