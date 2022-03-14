import { ABaseModel } from './base.model';

export class ConsumerUsageModel extends ABaseModel {
  public consumerName: string = null;
  public consumerDescription: string = null;
  public consumerNameWithoutOID: string = null;
  public consumerOID: string = null;
  public consumerCertificate: string = null;
  public certificateThumbprint: string = null;
  public registerName: string = null;
  public adapterName: string = null;
  public operationName: string = null;
  public operationNameEn: string = null;

  public administrationId: number = null;
  public registerId: number = null;
  public adapterId: number = null;
  public operationId: number = null;
  public consumerId: number = null;
  public certificateId: number = null;
  public consumerAdministrationId: number = null;
  public certificateIsActive: boolean = null;
  public updatedBy: string = null;
  public updatedOn: Date = null;
  public elementId: string = null;
  public elementName: string = null;

  constructor(init?: Partial<ConsumerUsageModel>) {
    super(init);
    if (init) {
      this.consumerName = init.consumerName;
      this.consumerDescription = init.consumerDescription;
      this.consumerNameWithoutOID = init.consumerNameWithoutOID;
      this.consumerOID = init.consumerOID;
      this.consumerCertificate = init.consumerCertificate;
      this.certificateThumbprint = init.certificateThumbprint;
      this.registerName = init.registerName;
      this.adapterName = init.adapterName;
      this.operationName = init.operationName;
      this.operationNameEn = init.operationNameEn;
      this.administrationId = init.administrationId;
      this.registerId = init.registerId;
      this.adapterId = init.adapterId;
      this.operationId = init.operationId;
      this.consumerId = init.consumerId;
      this.certificateId = init.certificateId;
      this.consumerAdministrationId = init.consumerAdministrationId;
      this.certificateIsActive = init.certificateIsActive;
      this.updatedBy = init.updatedBy;
      this.elementId = init.elementId;
      this.elementName = init.elementName;

      if (init.updatedOn) {
        this.updatedOn = new Date(init.updatedOn);
      }
    }
  }
}
