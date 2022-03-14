import { BaseModel } from "./base.model";

export class AgencyInfo extends BaseModel {
  acronym: string;
  registersCount: number;
  adaptersCount: number;
  operationsCount: number;

  public constructor(init?: Partial<AgencyInfo>) {
    super(init);
    if (init) {
      this.acronym = init.acronym;
      this.registersCount = init.registersCount;
      this.adaptersCount = init.adaptersCount;
      this.operationsCount = init.operationsCount;
    }
  }


}
