import { ABaseModel } from 'src/app/core/models/dto/base.model';
import { DisplayValue } from '../display-value.model';

export class LogReviewFilterModel extends ABaseModel {
  
  public administration: DisplayValue = null;
  public consumers: DisplayValue = null;
  public certificates: DisplayValue = null;

  constructor(init?: Partial<LogReviewFilterModel>) {
    super(init);
    if (init) {
      if (init.administration) {
        this.administration = new DisplayValue(
          init.administration
        );
      }
      if (init.consumers) {
        this.consumers = new DisplayValue(init.consumers);
      }
      if (init.certificates) {
        this.certificates = new DisplayValue(init.certificates);
      }
    }
  }
}