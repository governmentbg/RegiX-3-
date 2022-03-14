import { RegisterModel } from './register.model';
import { BaseModel } from './base.model';

export class AgencyModel extends BaseModel {
  acronym: string;
  registers: RegisterModel[];

  public constructor(init?: Partial<AgencyModel>) {
    super(init);
    if (this.registers == null) {
      this.registers = [];
    }
    if (init) {
      this.acronym = init.acronym;
      if (init.registers) {
        init.registers.map(d => this.registers.push(new RegisterModel(d)));
      }
    }
  }
}
