import {UsersModel} from '../users.model';

export class UserInModel {
    public name: string = null;
    public userName: string = null;
    public email: string = null;
    public isAdmin: boolean = false;
    public isActive: boolean = false;
    public administrationId: number = null;

    constructor(init?: Partial<UsersModel>) {
        if (init) {
          this.name = init.name;
          this.userName = init.userName;
          this.email = init.email;
          this.isActive = init.active;
          this.isAdmin = init.isAdmin;
          if (init.administration) {
            this.administrationId = init.administration.id;
          }
        }
      }
}
