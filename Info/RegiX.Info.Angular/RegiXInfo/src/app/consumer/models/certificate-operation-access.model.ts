import { ABaseModel } from '@tl/tl-common';
import { DisplayValue } from './display-value.model';

export class  CertificateOperationAccessModel extends ABaseModel {
  public consumerCertificate: DisplayValue;
  public adapterOperation: DisplayValue;

  constructor(init?: Partial<CertificateOperationAccessModel>) {
    super(init);
    if (init) {
      
      if (init.consumerCertificate) {
        this.consumerCertificate = new DisplayValue(init.consumerCertificate);
      }
      if (init.adapterOperation) {
        this.adapterOperation = new DisplayValue(init.adapterOperation);
      }
    }
  }
}