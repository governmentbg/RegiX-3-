export class CertificateElementAccessInModel {
  public consumerCertificateId: number = null;
  public registerObjectElementIds: number[] = null;
  public hasAccess: boolean = null;
  public adapterOperationId: number = null;
  public editAccessComment: string = null;
  public userId: number = null;

  constructor(init?: Partial<CertificateElementAccessInModel>) {
    if (init) {
      this.hasAccess = init.hasAccess;
      this.consumerCertificateId = init.consumerCertificateId;
      this.registerObjectElementIds = init.registerObjectElementIds;
      this.adapterOperationId = init.adapterOperationId;
      this.editAccessComment = init.editAccessComment;
      this.userId = init.userId;
    }
  }
}
