import { DisplayValue } from './../display-value.model';
import { ABaseModel } from '@tl/tl-common';

export class ConsumerSystemCertificatesModel extends ABaseModel {
  public csr: string = null;
  public content: string = null;
  public requestDate: Date = null;
  public environment: string = null;
  public name: string = null;

  public consumerCertificate: DisplayValue;
  public consumerSystem: DisplayValue;

  constructor(init?: Partial<ConsumerSystemCertificatesModel>) {
    super(init);
    if (init) {
      //The atob() method decodes a base-64 encoded string.
      this.csr = atob(init.csr);
      this.content = atob(init.content);
      this.requestDate = init.requestDate;
      this.environment = init.environment;
      this.name = init.name;

      if (init.consumerCertificate) {
        this.consumerCertificate = new DisplayValue(init.consumerCertificate);
      }
      if (init.consumerSystem) {
        this.consumerSystem = new DisplayValue(init.consumerSystem);
      }
    }
  }
}
