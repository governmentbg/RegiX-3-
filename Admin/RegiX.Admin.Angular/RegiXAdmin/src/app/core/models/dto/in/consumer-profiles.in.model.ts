import { ABaseModel } from '@tl/tl-common';
import { DisplayValue } from '../../display-value.model';

export class ConsumerProfilesInModel extends ABaseModel {
  public name: string;
  public identifier: string;
  public identifierType: number;
  public address: string;
  public status: number;
  public comment: string;
  public acceptedEula: boolean;
  public securityStamp: string;
  public documentNumber: string;

  public administration: DisplayValue;

  constructor(init?: Partial<ConsumerProfilesInModel>) {
    super(init);
    if (init) {
      this.name = init.name;
      this.identifier = init.identifier;
      this.identifierType = init.identifierType;
      this.address = init.address;
      this.status = init.status;
      this.comment = init.comment;
      this.acceptedEula = init.acceptedEula;
      this.securityStamp = init.securityStamp;
      this.documentNumber = init.documentNumber;

      if (init.administration) {
        this.administration = new DisplayValue(init.administration);
      }
    }
  }
}
