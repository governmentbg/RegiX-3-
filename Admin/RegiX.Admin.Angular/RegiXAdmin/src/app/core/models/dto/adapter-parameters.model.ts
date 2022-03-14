export class AdapterParametersModel{
  public key: string = null;
  public description: string = null;
  public value: string = null;

  constructor(init?: Partial<AdapterParametersModel>) {
    if (init) {
      this.description = init.description;
      this.key = init.key;
      this.value = init.value;
    }
  }
}
