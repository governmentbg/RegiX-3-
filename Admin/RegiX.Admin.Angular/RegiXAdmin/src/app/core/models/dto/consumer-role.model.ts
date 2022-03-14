import { ABaseCreatableModel } from './base-creatable.model';

export class ConsumerRoleModel extends ABaseCreatableModel {
    public name: string = null;
    public description: string = null;
  
    constructor(init?: Partial<ConsumerRoleModel>) {
      super(init);
      if (init) {  
        this.name = init.name;
        this.description = init.description;
      }
    }
  }
