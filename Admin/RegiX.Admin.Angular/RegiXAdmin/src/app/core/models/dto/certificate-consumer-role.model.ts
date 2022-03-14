import { ABaseModel } from 'src/app/core/models/dto/base.model';
import { DisplayValue } from './../display-value.model';
import { ABaseCreatableModel } from './base-creatable.model';

export class CertificateConsumerRoleModel extends ABaseModel {
    public consumerCertificate: DisplayValue = null;
    public consumerRole: DisplayValue = null;
    public editAccessComment: string = null;


    constructor(init?: Partial<CertificateConsumerRoleModel>) {
      super(init);
      if (init) {
        if (init.consumerCertificate) {
          this.consumerCertificate = new DisplayValue(init.consumerCertificate);
        }
        if (init.consumerRole) {
          this.consumerRole = new DisplayValue(init.consumerRole);
        }
        this.editAccessComment = init.editAccessComment;
      }
    }
  }
