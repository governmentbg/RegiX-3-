export class OperaitonCallResultModel {
  public startTime: Date = null;
  public assignedTo: string = null;
  public response: string = null;

  constructor(init?: Partial<OperaitonCallResultModel>) {
    if (init) {
        this.assignedTo = init.assignedTo;
        this.startTime = init.startTime;
        this.response = init.response;
    }

  }
}
