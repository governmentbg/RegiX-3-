export class NotRegisterApiServiceOperationModel {
  public name: string = null;
  public code: string = null;
  public description: string = null;

  constructor(init?: Partial<NotRegisterApiServiceOperationModel>) {
        if (init) {
            this.name = init.name;
            this.code = init.code;
            this.description = init.description;  
        }
    }
}
