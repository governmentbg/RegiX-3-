import { DisplayValue } from '../display-value.model';

export class AdapterOpetationsToRoleModel {
  public id: number = null;
  public adapterOperation: DisplayValue = null;
  public adapterOperationName: string = null;
  public role: DisplayValue = null;
  public roleName: string = null;

  constructor(init?: Partial<AdapterOpetationsToRoleModel>) {
    
    if (init) {
      this.id = init.id;
      if (init.adapterOperation) {
        this.adapterOperation = new DisplayValue(init.adapterOperation);
        this.adapterOperationName = this.adapterOperation.displayName;
      }
      if (init.role) {
        this.role = new DisplayValue(init.role);
        this.roleName = this.role.displayName;
      }
    }
  }
}
