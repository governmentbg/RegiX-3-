export class ReportResultModel {
  public error: string = null;
  public hasError: boolean = null;
  public isReady: boolean = null;
  public request: string = null;
  public response: string = null;
  public requestXml: string = null;
  public responseXml: string = null;
  public rawResponseXml: string = null;
  public signatureVerified?: boolean = null;
  public signatureCertirifcate: string = null;
  public responsePdf: string = null;
  public createdOn: Date = null;
  public unhandledErrorContent: string = null;
  public unhandledErrorMessage: string = null;
  public apiServiceCallId: number = null;
  public contextEmployeeAdditionalId: string = null;
  public contextLawReason: string = null;
  public contextServiceType: string = null;
  public contextServiceURI: string = null;
  public registerErrorContent: string = null;
  public registerErrorMessage: string = null;



  constructor(init?: Partial<ReportResultModel>) {
    if (init) {
      this.createdOn = init.createdOn;
      this.error = init.error;
      this.hasError = init.hasError;
      this.isReady = init.isReady;
      this.request = init.request;
      this.response = init.response;
      this.requestXml = init.requestXml;
      this.responseXml = init.responseXml;
      this.responsePdf = init.responsePdf;
      this.rawResponseXml = init.rawResponseXml;
      this.signatureCertirifcate = init.signatureCertirifcate;
      this.signatureVerified = init.signatureVerified;
      this.unhandledErrorContent = init.unhandledErrorContent;
      this.unhandledErrorMessage = init.unhandledErrorMessage;
      this.apiServiceCallId = init.apiServiceCallId;
      this.contextEmployeeAdditionalId = init.contextEmployeeAdditionalId;
      this.contextLawReason = init.contextLawReason;
      this.contextServiceType = init.contextServiceType;
      this.contextServiceURI = init.contextServiceURI;
      this.registerErrorContent = init.registerErrorContent;
      this.registerErrorMessage = init.registerErrorMessage;
    }
  }
}
