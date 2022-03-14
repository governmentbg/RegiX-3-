export class AdministrationTypeModel {
  public id: number = null;
  public name: string = null;
  public description: string = null;
  public publiclyVisible: boolean = null;

  constructor(init?: Partial<AdministrationTypeModel>) {
    if (init) {
      this.id = init.id;
      this.name = init.name;
      this.description = init.description;
      this.publiclyVisible = init.publiclyVisible;
    }
  }
}
