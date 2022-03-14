export class AdapterOperationModel {
    
    public description: string = null;
    public name: string = null;

    constructor(init?: Partial<AdapterOperationModel>) {
        if (init) {
          this.name = init.name;
          this.description = init.description;
        }
      }
}
