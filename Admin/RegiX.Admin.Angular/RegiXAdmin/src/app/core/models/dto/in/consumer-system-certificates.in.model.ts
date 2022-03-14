import { DisplayValue } from '../../display-value.model';
import { ABaseModel } from '@tl/tl-common';

export class ConsumerSystemCertificatesInModel extends ABaseModel {
  public csr: string = null;
  public content: string = null;
  public requestDate: Date = null;
  public environment: string = null;

  public consumerCertificate: DisplayValue;
  public consumerSystem: DisplayValue;

  constructor(init?: Partial<ConsumerSystemCertificatesInModel>) {
    super(init);
    if (init) {
      //The btoa() method encodes a string in base-64.
      this.csr = btoa(init.csr);
      this.content = init.content;
      this.requestDate = init.requestDate;
      this.environment = init.environment;

      if (init.consumerCertificate) {
        this.consumerCertificate = new DisplayValue(init.consumerCertificate);
      }
      if (init.consumerSystem) {
        this.consumerSystem = new DisplayValue(init.consumerSystem);
      }
    }
  }
}
