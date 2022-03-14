import { ABaseModel } from '@tl/tl-common';

export class ConsumerSystemCertificatesModel extends ABaseModel {
  public name: string;
  public csr: string;
  public consumerCertificateId: number;

  constructor(init?: Partial<ConsumerSystemCertificatesModel>) {
    super(init);
    if (init) {
      this.name = init.name;
      this.csr = init.csr;
      this.consumerCertificateId = init.consumerCertificateId;
    }
  }
}