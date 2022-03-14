import { DisplayValue } from '../display-value.model';

export class AuditExceptionModel {
  public id: number = null;
  public userName: string = null;
  public exceptionTime: Date = null;
  public exceptionText: number = null;
  public controller: string = null;
  public actionMethod: string = null;
  public authority: DisplayValue =  null;
  public authorityName: string =  null;

  constructor(init?: Partial<AuditExceptionModel>) {
    if (init) {
      this.id = init.id;
      this.userName = init.userName;
      this.controller = init.controller;
      this.actionMethod = init.actionMethod;
      this.exceptionTime = new Date(init.exceptionTime);
      this.exceptionText = init.exceptionText;
      if (init.authority) {
        this.authority = new DisplayValue(init.authority);
        this.authorityName = this.authority.displayName;
      }
    }
  }
}
