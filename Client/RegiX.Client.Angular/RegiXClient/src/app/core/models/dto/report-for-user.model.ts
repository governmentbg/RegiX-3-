import { ABaseModel } from './base.model';

export class ReportForUserModel extends ABaseModel {
  public userId: number = null;

  public operationId: number = null;
  public operationName: string = null;

  public authorityId: number = null;
  public authorityName: string = null;
  public authorityAcronym: string = null;

  public registerId: number = null;
  public registerName: string = null;

  public reportId: number = null;
  public reportName: string = null;

  public favourite = false;

  constructor(init?: Partial<ReportForUserModel>) {
    super(init);
    if (init) {
      this.authorityId = init.authorityId;
      this.authorityName = init.authorityName;
      this.authorityAcronym = init.authorityAcronym;
      this.registerId = init.registerId;
      this.registerName = init.registerName;
      this.operationId = init.operationId;
      this.operationName = init.operationName;
      this.reportId = init.reportId;
      this.reportName = init.reportName;
      this.userId = init.userId;
      this.favourite = init.favourite;
    }
  }
}
