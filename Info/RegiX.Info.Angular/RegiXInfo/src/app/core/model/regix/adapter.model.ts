import { BaseModel } from './base.model';
import { OperationModel } from './operation.model';
import { ROUTES } from 'src/app/public/routes/static-routes';

export class AdapterModel extends BaseModel {
  version: string;
  interface: string;
  operations: OperationModel[];

  public constructor(init?: Partial<AdapterModel>) {
    super(init);
    if (this.operations == null) {
      this.operations = [];
    }
    if (init) {
      this.version = init.version;
      this.interface = init.interface;
      if (init.operations) {
        this.operations = init.operations;
        //init.Operations.map(d => this.Operations.push(new OperationModel(d)));
      }
    }
  }

}
