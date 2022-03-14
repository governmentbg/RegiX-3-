import { ABaseModel } from 'src/app/core/models/dto/base.model';

export class UsersEauthModel extends ABaseModel {
  public identifier: string;
  public identifierType: string;

  constructor(init?: Partial<UsersEauthModel>) {
    super(init);
    if (init) {
      this.identifier = init.identifier;
      this.identifierType = init.identifierType;
    }
  }
}
