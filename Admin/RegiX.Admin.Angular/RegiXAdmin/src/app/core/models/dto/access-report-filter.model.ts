import { ABaseModel } from 'src/app/core/models/dto/base.model';

export class AccessReportFilterModel extends ABaseModel {
  administrationName: string;
  registerName: string;
  adapterName: string;
  operationName: string;
  operationNameEn: string;
  administrationId: number;
  registerId: number;
  adapterId: number;
  operationId: number;

  constructor(init?: Partial<AccessReportFilterModel>) {
    super(init);
    if (init) {
      this.administrationName = init.administrationName;
      this.registerName = init.registerName;
      this.adapterName = init.adapterName;
      this.operationName = init.operationName;
      this.operationNameEn = init.operationNameEn;
      this.administrationId = init.administrationId;
      this.registerId = init.registerId;
      this.adapterId = init.adapterId;
      this.operationId = init.operationId;
    }
  }
}
