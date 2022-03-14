export class SelectedTypesModel {
    public id: number;
    public name: string;
    public data: any;
    public key: string;
  
    constructor(init?: Partial<SelectedTypesModel>) {
      if (init) {
        this.id = init.id;
        this.name = init.name;
        this.data = init.data;
        this.key = init.key;     
      }
    }
  }
  