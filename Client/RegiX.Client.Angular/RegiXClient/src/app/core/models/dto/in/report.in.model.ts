import { ReportModel } from '../report.model';

export class ReportInModel {
  public name: string = null;
  public code: string = null;
  public lawReason: string = null;
  public orderNumber: number = null;

  public isActive = false;
  public adapterOperationId: number = null;
  public authorityId: number = null;

  public roleIds: number[] = [];
  public userIds: number[] = [];

  constructor(init?: Partial<ReportModel>) {
    if (init) {
      this.code = init.code;
      this.lawReason = init.lawReason;

      if(init.isActive !== null){
        this.isActive = init.isActive;
      }
      this.name = init.name;

      if (init.adapterOperation) {
        this.adapterOperationId = init.adapterOperation.id;
      }
      if (init.authority) {
        this.authorityId = init.authority.id;
      }
    }
  }
}
