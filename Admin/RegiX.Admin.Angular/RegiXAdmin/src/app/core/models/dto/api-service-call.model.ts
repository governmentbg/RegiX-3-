import { ABaseModel } from './base.model';
import { DisplayValue } from '../display-value.model';

export class ApiServiceCallModel extends ABaseModel {
  public instanceId: string = null;
  public resultReady: boolean;
  public startTime: Date = null;
  public endTime: Date = null;
  public resultReturned: boolean;
  public callContext: string = null;
  public eidToken: string = null;
  public clientIpAddress: string = null;
  public resultContent: string = null;
  public hasError: boolean;
  public errorContent: string = null;
  public oidToken: string = null;
  public contextSerivceUri: string = null;
  public contextServiceType: string = null;
  public contextEmployeeIdentifier: string = null;
  public contextEmployeeNames: string = null;
  public contextEmployeeAditionalId: string = null;
  public contextEmployeePosition: string = null;
  public contextAdministrationOid: string = null;
  public contextAdministrationName: string = null;
  public contextResponsibleNames: string = null;
  public contextLawReason: string = null;
  public ipAddress: string = null;
  public appName: string = null;
  public apiServiceOperation: DisplayValue = null;
  public apiServiceOperationName: string = null;
  public consumerCertificate: DisplayValue = null;
  public consumerCertificateName: string = null;

  constructor(init?: Partial<ApiServiceCallModel>) {
    super(init);
    if (init) {
      this.instanceId = init.instanceId;
      this.resultReady = init.resultReady;
      this.startTime = new Date(init.startTime);
      this.endTime = new Date(init.endTime);
      this.resultReturned = init.resultReturned;
      this.callContext = init.callContext;
      this.eidToken = init.eidToken;
      this.clientIpAddress = init.clientIpAddress;
      this.resultContent = init.resultContent;
      this.hasError = init.hasError;
      this.errorContent = init.errorContent;
      this.oidToken = init.oidToken;
      this.contextSerivceUri = init.contextSerivceUri;
      this.contextServiceType = init.contextServiceType;
      this.contextEmployeeIdentifier = init.contextEmployeeIdentifier;
      this.contextEmployeeNames = init.contextEmployeeNames;
      this.contextEmployeeAditionalId = init.contextEmployeeAditionalId;
      this.contextEmployeePosition = init.contextEmployeePosition;
      this.contextAdministrationOid = init.contextAdministrationOid;
      this.contextAdministrationName = init.contextAdministrationName;
      this.contextResponsibleNames = init.contextResponsibleNames;
      this.contextLawReason = init.contextLawReason;
      this.ipAddress = init.ipAddress;
      this.appName = init.appName;
      if (init.apiServiceOperation) {
        this.apiServiceOperation = new DisplayValue(init.apiServiceOperation);
        this.apiServiceOperationName = this.apiServiceOperation.displayName;
      }
      if (init.consumerCertificate) {
        this.consumerCertificate = new DisplayValue(init.consumerCertificate);
        this.consumerCertificateName = this.consumerCertificate.displayName;
      }
    }
  }
}
