import { ABaseCreatableModel } from './base-creatable.model';
import { DisplayValue } from '../display-value.model';

export class AdapterOperationModel extends ABaseCreatableModel {
  public operationName: string = null;
  public displayOperationName: string = null;
  public register: DisplayValue = null;
  public code: string = null;
  public controllerName: string = null;
  public registerDisplayName: string = null;
  public requestObjectName: string = null;
  public namespace: string = null;
  public url: string = null;
  public selected = false;

  constructor(init?: Partial<AdapterOperationModel>) {
    super(init);

    if (init) {
      this.operationName = init.operationName;
      this.displayOperationName = init.displayOperationName;
      this.register = init.register;
      this.code = init.code;
      this.controllerName = init.controllerName;
      this.requestObjectName = init.requestObjectName;
      this.namespace = init.namespace;
      this.url = init.url;
      this.registerDisplayName = init.registerDisplayName;

      if (init.register) {
        this.register = new DisplayValue(init.register);
      } else {
        this.register = new DisplayValue({ id: init['registerId'] });
      }
    }
  }
}
