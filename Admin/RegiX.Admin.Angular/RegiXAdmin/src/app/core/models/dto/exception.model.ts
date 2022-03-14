export class ExceptionModel {
  public id: number = null;
  public userName: string = null;
  public userId: number = null;
  public exceptionTime: Date = null;
  public exceptionText: number = null;
  public controller: string = null;
  public actionMethod: string = null;
  public ipAddress: string = null;

  constructor(init?: Partial<ExceptionModel>) {
    if (init) {
      this.id = init.id;
      this.userName = init.userName;
      this.userId = init.userId;
      this.controller = init.controller;
      this.actionMethod = init.actionMethod;
      this.ipAddress = init.ipAddress;
      this.exceptionTime = new Date(init.exceptionTime);
      this.exceptionText = init.exceptionText;
    }
  }
}
