import { ABaseModel } from '@tl/tl-common';
import { DisplayValueAdapterOperation } from '../../display-values-register-object.model';
import { DisplayValue } from '../../display-value.model';


export class ConsumerAccessRequestsModelInModel extends ABaseModel {
    public status: number;
    public lawReason: string;
    public relatedServices: string;
    public relatedServicesCode: string;
    
    public comment: string;
    public approvedRequestElementIds: number[] = null;
  
    public consumerSystemCertificate: DisplayValue = null;
    public consumerRequest: DisplayValue = null;
    public adapterOperation: DisplayValueAdapterOperation = null;
  
    constructor(init?: Partial<ConsumerAccessRequestsModelInModel>) {
      super(init);
      if (init) {
        this.status = init.status;
        this.lawReason = init.lawReason;
        this.relatedServices = init.relatedServices;
        this.relatedServicesCode = init.relatedServicesCode;
  
        if (init.consumerSystemCertificate) {
          this.consumerSystemCertificate = new DisplayValue(
            init.consumerSystemCertificate
          );
        }
  
        if (init.consumerRequest) {
          this.consumerRequest = new DisplayValue(
            init.consumerRequest
          );
        }
  
        if (init.adapterOperation) {
          this.adapterOperation = new DisplayValueAdapterOperation(
            init.adapterOperation
          );
        }
      }
    }
  }