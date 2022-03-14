import { ABaseCreatableModel } from './base-creatable.model';
import { DisplayValue } from '../display-value.model';

export class UserEditModel extends ABaseCreatableModel {
    public userName: string = null;
    public name: string = null;
    public email: string = null;
    public active: boolean = false;
    public isAdmin: boolean = false;
    public administration: DisplayValue = null;
    public administrationName: string = null;

    constructor(init?: Partial<UserEditModel>) {
        super(init);
        if (init) {
          this.userName = init.userName;
          this.name = init.name;
          this.email = init.email;
          this.active = init.active;
          this.isAdmin = init.isAdmin;
          if (init.administration) {
            this.administration = new DisplayValue(init.administration);
            this.administrationName = this.administration.displayName;
          }
        }
      }
}
