import { ConsumerModel } from '../consumer.model';

export class ConsumerInModel {
  public name: string = null;
  public oid: string = null;
  public administrationId: number = null;
  public description: string = null;

  constructor(init?: Partial<ConsumerModel>) {
    if (init) {
      this.oid = init.oid;
      this.description = init.description;
      this.name = init.name;
      if (init.administration) {
        this.administrationId = init.administration.id;
      }
    }
  }
}
