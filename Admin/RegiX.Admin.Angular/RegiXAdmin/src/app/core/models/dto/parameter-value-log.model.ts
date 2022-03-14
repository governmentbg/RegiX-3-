import { ABaseModel } from './base.model';
import { DisplayValue } from '../display-value.model';

export class ParameterValueLogModel extends ABaseModel {
  public key: string = null;
  public oldValue: string = null;
  public newValue: string = null;
  public editedTime: string = null;
  public registerAdapter: DisplayValue = null;
  public registerAdapterName: string = null;
  public user: DisplayValue = null;
  public userName: string = null;

  constructor(init?: Partial<ParameterValueLogModel>) {
    super(init);
    if (init) {
      this.key = init.key;
      this.oldValue = init.oldValue;
      this.newValue = init.newValue;
      this.editedTime = init.editedTime;

      if (init.registerAdapter) {
        this.registerAdapter = new DisplayValue(init.registerAdapter);
        this.registerAdapterName = this.registerAdapter.displayName;
      }

      if (init.user) {
        this.user = new DisplayValue(init.user);
        this.userName = this.user.displayName;
      }
    }
  }
}
