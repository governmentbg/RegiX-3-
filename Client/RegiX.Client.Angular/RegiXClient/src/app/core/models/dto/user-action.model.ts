export class UserActionModel {
  public id: number = null;
  public userName: string = null;

  public userActionTime: Date = null;
  public userActionText: string = null;
  public userActionType: string = null;
  public controller: string = null;
  public actionMethod: string = null;
  public executeStatus: string = null;
  public params: string = null;
  public url: string = null;
  public changedTables: string = null;

  constructor(init?: Partial<UserActionModel>) {
    if (init) {
      this.id = init.id;
      this.userName = init.userName;

      this.userActionTime = new Date(init.userActionTime);
      this.userActionText = init.userActionText;
      this.userActionType = init.userActionType;
      this.controller = init.controller;
      this.actionMethod = init.actionMethod;
      this.executeStatus = init.executeStatus;
      this.params = init.params;
      this.url = init.url;
      this.changedTables = init.changedTables;
    }
  }
}
