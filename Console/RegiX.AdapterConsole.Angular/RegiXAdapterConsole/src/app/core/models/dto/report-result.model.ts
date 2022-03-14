export class ReportResultModel {
  public error: string = null;
  public hasError: boolean = null;
  public isReady: boolean = null;
  public request: string = null;
  public response: string = null;
  public requestXML: string = null;
  public responseXML: string = null;


  constructor(init?: Partial<ReportResultModel>) {
    if (init) {
      this.error = init.error;
      this.hasError = init.hasError;
      this.isReady = init.isReady;
      this.request = init.request;
      this.response = init.response;
      this.requestXML = init.requestXML;
      this.responseXML = init.responseXML;
    }
  }
}
