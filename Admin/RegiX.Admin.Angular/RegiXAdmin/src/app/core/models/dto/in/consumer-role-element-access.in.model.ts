export class ConsumerRoleElementAccessInModel {
    public consumerRoleId: number = null;
    public registerObjectElementIds: number[] = null;
    public hasAccess: boolean = null;
    public adapterOperationId: number = null;
    public editAccessComment: string = null;
    public userId: number = null;
  
    constructor(init?: Partial<ConsumerRoleElementAccessInModel>) {
      if (init) {
        this.hasAccess = init.hasAccess;
        this.consumerRoleId = init.consumerRoleId;
        this.registerObjectElementIds = init.registerObjectElementIds;
        this.adapterOperationId = init.adapterOperationId;
        this.editAccessComment = init.editAccessComment;
        this.userId = init.userId;
      }
    }
  }