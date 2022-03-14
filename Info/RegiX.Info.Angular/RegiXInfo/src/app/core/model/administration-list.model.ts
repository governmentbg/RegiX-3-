import { BaseModel } from './regix/base.model';

export class AdministrationListModel extends BaseModel {
  acronym: string;
  code: string;

  public constructor(init?: Partial<AdministrationListModel>) {
    super(init);

    if (init) {
      this.acronym = init.acronym;
      this.code = init.code;
    }
  }
}
