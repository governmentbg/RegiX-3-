export class HierarchyModel{
  public id: any = null;
  public administrationName: string;
  public registerName: string;
  public adapterName: string;

  constructor(init?: Partial<HierarchyModel>) {
    if (init) {
      this.id = init.id;
      this.administrationName = init.administrationName;
      this.registerName = init.registerName;
      this.adapterName = init.adapterName;
    }
  }
}
