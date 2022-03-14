import { ABaseCreatableModel } from './base-creatable.model';
import { AdapterOperationOutDto } from './out/adapter-operation-out-dto';
import { ConsumerCertificateOutDto } from './out/consumer-certificate-out-dto';

export class CertificateOperationModel extends ABaseCreatableModel {
  public adapterOperation: AdapterOperationOutDto = null;
  public adapterOperationName: string = null;
  public adapterOperationDescription: string = null;

  public consumerCertificate: ConsumerCertificateOutDto = null;
  public consumerCertificateName: string = null;
  public consumerCertificateDescription: string = null;

  public registerObjectId: number = null;

  public hasAccess: boolean = null;
  public editComment: string = null;

  constructor(init?: Partial<CertificateOperationModel>) {
    super(init);
    if (init) {
      this.editComment = init.editComment;
      if (init.adapterOperation) {
        this.adapterOperation = new AdapterOperationOutDto(init.adapterOperation);
        this.adapterOperationName = this.adapterOperation.displayName;
        this.adapterOperationDescription = this.adapterOperation.description;
      }
      if (init.consumerCertificate) {
        this.consumerCertificate = new ConsumerCertificateOutDto(init.consumerCertificate);
        this.consumerCertificateName = this.consumerCertificate.displayName;
        this.consumerCertificateDescription = this.consumerCertificate.description;
      }
      this.hasAccess = init.hasAccess;
      this.registerObjectId = init.registerObjectId;
    }
  }
}
