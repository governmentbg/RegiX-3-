import { DisplayValue } from '../../display-value.model';
import { ConsumerCertificateModel } from '../consumer-certificate.model';

export class ConsumerCertificateInModel {
  public name: string = null;
  public description: string = null;
  public content: string = null;
  public apiServiceConsumerId: number = null;
  public consumerRoleIds: DisplayValue[] = [];
  public active: boolean = null;
  public oid: string = null;

  constructor(init?: Partial<ConsumerCertificateModel>) {
    if (init) {
      this.name = init.name;
      this.description = init.description;
      this.content = init.content;
      this.active = init.active;
      this.oid = init.oid;

      if (init.apiServiceConsumer) {
        this.apiServiceConsumerId = init.apiServiceConsumer.id;
      }
    }
  }
}
