import { ABaseModel } from '@tl/tl-common';
import { DisplayValue } from './display-value.model';

export class CertificateElementAccessModel extends ABaseModel {
  public hasAccess: boolean;

  public consumerCertificate: DisplayValue;
  public registerObjectElement: DisplayValue;

  constructor(init?: Partial<CertificateElementAccessModel>) {
    super(init);
    if (init) {
      this.hasAccess = init.hasAccess;
 
      if (init.consumerCertificate) {
        this.consumerCertificate = new DisplayValue(init.consumerCertificate);
      }
      if (init.registerObjectElement) {
        this.registerObjectElement = new DisplayValue(init.registerObjectElement);
      }
    }
  }
}