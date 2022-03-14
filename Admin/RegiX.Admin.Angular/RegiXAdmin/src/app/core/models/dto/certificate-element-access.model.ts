import { ABaseModel } from './base.model';
import { DisplayValue } from '../display-value.model';

export class CertificateElementAccessModel extends ABaseModel {
  public hasAccess: boolean = null;
  public consumerCertificate: DisplayValue = null;
  public registerObjectElement: DisplayValue = null;
  public registerObjectId: number = null;

  constructor(init?: Partial<CertificateElementAccessModel>) {
    super(init);
    if (init) {
      this.hasAccess = init.hasAccess;
      this.registerObjectId = init.registerObjectId;
      if (init.consumerCertificate) {
        this.consumerCertificate = new DisplayValue(init.consumerCertificate);
      }
      if (init.registerObjectElement) {
        this.registerObjectElement = new DisplayValue(
          init.registerObjectElement
        );
      }
    }
  }
}
