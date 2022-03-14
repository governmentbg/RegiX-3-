import { ABaseModel } from '@tl/tl-common';

export class HierarchyModel extends ABaseModel {
  public administrationName: string;
  public registerName: string;
  public adapterName: string;

  constructor(init?: Partial<HierarchyModel>) {
    super(init);
    if (init) {
      this.administrationName = init.administrationName;
      this.registerName = init.registerName;
      this.adapterName = init.adapterName;
    }
  }
}
