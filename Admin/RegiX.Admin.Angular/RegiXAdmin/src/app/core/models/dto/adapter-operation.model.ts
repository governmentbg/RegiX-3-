import { DisplayValue } from '../display-value.model';
import { ABaseCreatableModel } from './base-creatable.model';

export class AdapterOperationModel extends ABaseCreatableModel {
  public name: string = null;
  public description: string = null;
  public registerAdapter: DisplayValue = null;
  public registerAdapterName: string = null;
  public registerObject: DisplayValue = null;
  public registerObjectName: string = null;

  constructor(init?: Partial<AdapterOperationModel>) {
    super(init);
    if (init) {
      this.description = init.description;
      this.name = init.name;

      if (init.registerAdapter) {
        this.registerAdapter = new DisplayValue(init.registerAdapter);
        this.registerAdapterName = this.registerAdapter.displayName;
      }

      if (init.registerObject) {
        this.registerObject = new DisplayValue(init.registerObject);
        this.registerObjectName = this.registerObject.displayName;
      }
    }
  }
}
