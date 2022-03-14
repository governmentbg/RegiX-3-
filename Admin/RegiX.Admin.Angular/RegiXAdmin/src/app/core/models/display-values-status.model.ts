export class DisplayValueStatus {
    public id: any;
    public status: number;
  
    constructor(init?: Partial<DisplayValueStatus>) {
      if (init) {
        this.id = init.id;
        this.status = init.status;
      }
    }
  }