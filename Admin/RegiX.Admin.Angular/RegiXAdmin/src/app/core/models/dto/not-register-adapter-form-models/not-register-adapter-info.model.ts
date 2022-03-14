import { RegisterObjectModel } from './register-object.model';
import { AdapterOperationModel } from './adapter-operation.model';

export class NotRegisterAdapterInfoModel {
  public id: string = null;
  public name: string = null;
  public description: string = null;
  public contract: string = null;
  public assembly: string = null;
  public adapterUrl: string = null;
  public bindingConfigName: string = null;
  public bindingType: string = null;
  public register: number = null;
  public registerDisplay: string = null;

  public registerObjects: RegisterObjectModel[] = [];
  public adapterOperations: AdapterOperationModel[] = [];

  constructor(init?: Partial<NotRegisterAdapterInfoModel>) {
    if (init) {
      this.id = init.name;
      this.description = init.description;
      this.name = init.name;
      this.contract = init.contract;
      this.assembly = init.assembly;
      this.adapterUrl = init.adapterUrl;
      this.bindingConfigName = init.bindingConfigName;
      this.bindingType = init.bindingType;


      if (init.registerObjects) {
        init.registerObjects.map(d => this.registerObjects.push(new RegisterObjectModel(d)))
      }
      if (init.adapterOperations) {
        init.adapterOperations.map(d => this.adapterOperations.push(new AdapterOperationModel(d)))
      }

    }
  }
}
