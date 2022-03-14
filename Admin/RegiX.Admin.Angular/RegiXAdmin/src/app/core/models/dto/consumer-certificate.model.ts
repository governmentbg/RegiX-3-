import { ABaseCreatableModel } from './base-creatable.model';
import { DisplayValue } from '../display-value.model';

export class ServiceConsumerInfo extends DisplayValue {
  public oid: string = null;
  constructor(init?: Partial<ConsumerCertificateModel>) {
    super(init);
    if (init) {
      this.oid = init.oid;
    }
  }
}

export class ConsumerCertificateModel extends ABaseCreatableModel {
  public name: string = null;
  public description: string = null;
  public thumbprint: string = null;
  public content: string = null;
  public apiServiceConsumer: ServiceConsumerInfo = null;

  public issuedFrom: string = null;
  public issuedTo: string = null;
  public validFrom: Date = null;
  public validTo: Date = null;
  public active: boolean = null;
  public oid: string = null;

  constructor(init?: Partial<ConsumerCertificateModel>) {
    super(init);
    if (init) {
      this.name = init.name;
      this.description = init.description;
      this.thumbprint = init.thumbprint;
      this.content = init.content;

      this.issuedFrom = init.issuedFrom;
      this.issuedTo = init.issuedTo;
      this.validFrom = new Date(init.validFrom);
      this.validTo = new Date(init.validTo);
      this.active = init.active;
      this.oid = init.oid;

      if (init.apiServiceConsumer) {
        this.apiServiceConsumer = new ServiceConsumerInfo(
          init.apiServiceConsumer
        );
      }
    }
  }
}
