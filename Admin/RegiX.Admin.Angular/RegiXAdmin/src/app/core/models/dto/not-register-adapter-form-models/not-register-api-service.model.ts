import { NotRegisterApiServiceOperationModel } from './not-register-api-service-operation.model';

export class NotRegisterApiServiceModel {
    public name: string = null;
    public code: string = null;
    public description: string = null;
    public contract: string = null;
    public serviceUrl: string = null;

    public apiServiceOperations: NotRegisterApiServiceOperationModel[] = [];
  
    constructor(init?: Partial<NotRegisterApiServiceModel>) {
          if (init) {
              this.name = init.name;
              this.code = init.code;
              this.description = init.description;
              this.contract = init.contract;  
              this.serviceUrl = init.serviceUrl;    
              
            if(init.apiServiceOperations){
                init.apiServiceOperations.map(d => this.apiServiceOperations.push(new NotRegisterApiServiceOperationModel(d)))
              }
          }
      }
}
