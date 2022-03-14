import { BaseModel } from './regix/base.model';

export class AdapterListModel extends BaseModel {

    version: string;

    public constructor(init?: Partial<AdapterListModel>) {
        super(init);
        if (init) {
            this.version = init.version;
        }
      }
}
