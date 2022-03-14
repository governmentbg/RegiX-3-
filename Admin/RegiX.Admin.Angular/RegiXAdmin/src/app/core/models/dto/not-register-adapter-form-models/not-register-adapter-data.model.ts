import { NotRegisterAdapterInfoModel } from './not-register-adapter-info.model';
import { NotRegisterApiServiceModel } from './not-register-api-service.model';
import { NotRegisterApiServiceAdapterOperationModel } from './not-register-api-service-adapter-operation.model';

export class NotRegisterAdapterDataModel  {
    id: string = null;
    notRegisterAdapterInfo: NotRegisterAdapterInfoModel;
    notRegisterApiService: NotRegisterApiServiceModel;

    notRegisterApiServiceAdapterOperations: NotRegisterApiServiceAdapterOperationModel[] = [];

    constructor(init?: Partial<NotRegisterAdapterDataModel>) {
        if (init) {
            this.id =  init.notRegisterAdapterInfo.name;
            this.notRegisterAdapterInfo = init.notRegisterAdapterInfo;
            this.notRegisterApiService = init.notRegisterApiService;
        
        if(init.notRegisterApiServiceAdapterOperations){
            init.notRegisterApiServiceAdapterOperations
            .map(d => this.notRegisterApiServiceAdapterOperations.push(new NotRegisterApiServiceAdapterOperationModel(d)))
            }
        }
    }
}
