export abstract class ABaseModel {
  public id: number = null;

  constructor(init?: Partial<ABaseModel>) {
    if (init) {
      this.id = init.id;
    }
  }
}
