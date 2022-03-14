import { ABaseModel } from 'src/app/core/models/dto/base.model';

export class AccessReportFilterConsumerModel extends ABaseModel {
  administrationName: string;
  consumerName: string;
  consumerCertificateName: string;
  administrationId: number;
  consumerId: number;
  consumerCertificateId: number;

  constructor(init?: Partial<AccessReportFilterConsumerModel>) {
    super(init);
    if (init) {
      this.administrationName = init.administrationName;
      this.consumerName = init.consumerName;
      this.consumerCertificateName = init.consumerCertificateName;
      this.administrationId = init.administrationId;
      this.consumerId = init.consumerId;
      this.consumerCertificateId = init.consumerCertificateId;
    }
  }
}
