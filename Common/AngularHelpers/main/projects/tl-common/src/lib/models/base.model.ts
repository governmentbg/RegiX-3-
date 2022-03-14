export abstract class ABaseModel {
    public id: any = null;
  
    constructor(init?: Partial<ABaseModel>) {
      if (init) {
        this.id = init.id;
      }
    }
  }
  