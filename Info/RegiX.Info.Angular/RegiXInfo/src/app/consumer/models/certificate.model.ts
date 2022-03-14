
import { DisplayValue } from './display-value.model';
import { ABaseModel } from '@tl/tl-common';

export class CertificateModel extends ABaseModel {
  public name: string = null;
  public content: string = null;
  public csr: string = null;
  public environment: string = null;
  public consumerSystem: DisplayValue;
  public consumerCertificate: DisplayValue;

  constructor(init?: Partial<CertificateModel>) {
    super(init);
    if (init) {
      this.content = init.content;
      this.name = init.name;
      this.csr = init.csr;
      this.environment = init.environment;
      
      if (init.consumerSystem) {
        this.consumerSystem = new DisplayValue(init.consumerSystem);
      }

      if (init.consumerCertificate) {
        this.consumerCertificate = new DisplayValue(init.consumerCertificate);
      }
    }
  }
}
