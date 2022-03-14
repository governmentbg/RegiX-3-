export class NotRegisterAdapterModel {
    id: string = null;
    adapterAssembly: string = null;
    adapterContract: string = null;
    adapterName: string = null;
    versionOfAdapter: string = null;

    constructor(init?: Partial<NotRegisterAdapterModel>) {
        if (init) {
          this.id = init.adapterName;
          this.adapterAssembly = init.adapterAssembly;
          this.adapterContract = init.adapterContract;
          this.adapterName = init.adapterName;
          this.versionOfAdapter = init.versionOfAdapter;
        }
      }
}
