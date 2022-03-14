import { ABaseModel } from '@tl/tl-common';
import { DisplayValue } from '../display-value.model';

export class ConsumerProfileUsersModel extends ABaseModel {
  public name: string;
  public position: string;
  public email: string;
  public isActive: boolean;
  public identifier: string;
  public identifierType: number;
  public lockoutEnabled: boolean;
  public accessFailedCount: number;
  public emailConfirmed: boolean;
  public phoneNumber: string;
  public phoneNumberConfirmed: boolean;
  public twoFactorEnabled: boolean;

  public consumerProfile: DisplayValue = null;

  constructor(init?: Partial<ConsumerProfileUsersModel>) {
    super(init);
    if (init) {
      this.name = init.name;
      this.position = init.position;
      this.identifierType = init.identifierType;
      this.email = init.email;
      this.isActive = init.isActive;
      this.identifier = init.identifier;
      this.lockoutEnabled = init.lockoutEnabled;
      this.accessFailedCount = init.accessFailedCount;
      this.emailConfirmed = init.emailConfirmed;
      this.phoneNumber = init.phoneNumber;
      this.phoneNumberConfirmed = init.phoneNumberConfirmed;
      this.twoFactorEnabled = init.twoFactorEnabled;

      if (init.consumerProfile) {
        this.consumerProfile = new DisplayValue(init.consumerProfile);
      }
    }
  }
}
