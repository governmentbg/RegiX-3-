import { ABaseModel } from './base.model';
import { DisplayValue } from '../display-value.model';

export class ConsumerRoleElementAccessModel extends ABaseModel {
  public hasAccess: boolean = null;
  public consumerRole: DisplayValue = null;
  public registerObjectElement: DisplayValue = null;

  constructor(init?: Partial<ConsumerRoleElementAccessModel>) {
    super(init);
    if (init) {
      this.hasAccess = init.hasAccess;
      if (init.consumerRole) {
        this.consumerRole = new DisplayValue(init.consumerRole);
      }
      if (init.registerObjectElement) {
        this.registerObjectElement = new DisplayValue(
          init.registerObjectElement
        );
      }
    }
  }
}