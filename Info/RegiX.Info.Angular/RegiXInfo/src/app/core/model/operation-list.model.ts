import { BaseModel } from './regix/base.model';

export class OperationListModel extends BaseModel{
    description: string;
    interface: string;
    public constructor(init?: Partial<OperationListModel>) {
        super(init);
        if (init) {
          this.description = init.description;
          this.interface = init.interface;
        }
      }
}
