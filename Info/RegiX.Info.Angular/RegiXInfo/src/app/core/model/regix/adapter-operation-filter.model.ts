import { ABaseCreatableModel } from './abase-creatable-model.model';
import { DisplayValue } from 'src/app/consumer/models/display-value.model';

export class AdapterOperationFilterModel extends ABaseCreatableModel {
    public name: string = null;
    public description: string = null;
    public registerAdapter: DisplayValue = null;
    public registerAdapterName: string = null;
    public registerObject: DisplayValue = null;
    public registerObjectName: string = null;
  
    constructor(init?: Partial<AdapterOperationFilterModel>) {
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