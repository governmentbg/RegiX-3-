export class NotRegisterApiServiceAdapterOperationModel {
    public adapterFullName: string = null;
    public apiServiceFullName: string = null;

    constructor(init?: Partial<NotRegisterApiServiceAdapterOperationModel>) {
        if (init) {
            this.adapterFullName = init.adapterFullName;
            this.apiServiceFullName = init.apiServiceFullName;
        }
    }

}
