import { DisplayValue } from '../../display-value.model';

export class ConsumerCertificateOutDto extends DisplayValue {
  public description: string = null;

  constructor(init?: Partial<ConsumerCertificateOutDto>) {
    super(init)
    if (init) {
      this.description = init.description;
    }
  }
}