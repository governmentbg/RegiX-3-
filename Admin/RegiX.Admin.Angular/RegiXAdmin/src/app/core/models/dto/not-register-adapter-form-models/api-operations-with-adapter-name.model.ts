export class ApiOperationsWithAdapterNameModel {
  public name: string = null;
  public code: string = null;
  public description: string = null;
  public adapterFullName: string = null;

  constructor(init?: Partial<ApiOperationsWithAdapterNameModel>) {
        if (init) {
            this.name = init.name;
            this.code = init.code;
            this.description = init.description;
            this.adapterFullName = init.adapterFullName;   
        }
    }
}
