import { ABaseModel } from '@tl/tl-common';

export class ConsumerSystemsModel extends ABaseModel {
  public name: string = null;
  public description: string = null;
  public staticIP: string = null;

  constructor(init?: Partial<ConsumerSystemsModel>) {
    super(init);
    if (init) {
      this.name = init.name;
      this.description = init.description;
      this.staticIP = init.staticIP;
    }
  }
}
