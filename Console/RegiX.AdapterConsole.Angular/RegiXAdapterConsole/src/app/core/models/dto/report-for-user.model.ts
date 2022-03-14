import { ABaseModel } from '@tl/tl-common';

export class ReportForUserModel extends ABaseModel {
  public userId: number = null;

  public operationId: number = null;
  public operationName: string = null;

  public authorityId: number = null;
  public authorityName: string = null;

  public registerId: number = null;
  public registerName: string = null;

  public reportId: number = null;
  public reportName: string = null;

  constructor(init?: Partial<ReportForUserModel>) {
    super(init);
    if (init) {
      this.authorityId = init.authorityId;
      this.authorityName = init.authorityName;
      this.registerId = init.registerId;
      this.registerName = init.registerName;
      this.operationId = init.operationId;
      this.operationName = init.operationName;
      this.reportId = init.reportId;
      this.reportName = init.reportName;
      this.userId = init.userId;
    }
  }
}
