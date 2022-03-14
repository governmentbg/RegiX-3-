import { ABaseCreatableModel } from './base-creatable.model';
import { DisplayValue } from '../display-value.model';

export class UserShowModel extends ABaseCreatableModel {
    public userName: string = null;
    public name: string = null;
    public email: string = null;
    public active: boolean = false;
    public isLockedOut: boolean = null;
    public administration: DisplayValue = null;
    public administrationName: string = null;

    constructor(init?: Partial<UserShowModel>) {
        super(init);
        if (init) {
          this.userName = init.userName;
          this.name = init.name;
          this.email = init.email;
          this.active = init.active;
          this.isLockedOut = init.isLockedOut;
          if (init.administration) {
            this.administration = new DisplayValue(init.administration);
            this.administrationName = this.administration.displayName;
          }
        }
      }
}
