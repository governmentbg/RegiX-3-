export class ConsumerModel {
  public id: any = null;
  public name: string = null;
  public address: string = null;
  public identifier: string = null;
  public identifierType: number = null;
  public acceptedEULA: boolean = null;
  public documentNumber: string = null;

  constructor(init: Partial<ConsumerModel>) {
    if (init) {
      this.id = init.id;
      this.name = init.name;
      this.address = init.address;
      this.identifier = init.identifier;
      this.identifierType = init.identifierType;
      this.acceptedEULA = init.acceptedEULA;
    }
  }
}
