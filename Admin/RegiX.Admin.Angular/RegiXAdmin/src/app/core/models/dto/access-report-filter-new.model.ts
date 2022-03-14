import { ABaseModel } from 'src/app/core/models/dto/base.model';
import { DisplayValue } from '../display-value.model';

export class AccessReportFilterNewModel extends ABaseModel {
  public consumerAdministration: DisplayValue = null;
  public consumer: DisplayValue = null;
  public registerAdministration: DisplayValue = null;
  public register: DisplayValue = null;
  public adapter: DisplayValue = null;
  public certificate: DisplayValue = null;
  public adapterOperation: DisplayValue = null;

  constructor(init?: Partial<AccessReportFilterNewModel>) {
    super(init);
    if (init) {
      if (init.consumerAdministration) {
        this.consumerAdministration = new DisplayValue(
          init.consumerAdministration
        );
      }
      if (init.consumer) {
        this.consumer = new DisplayValue(init.consumer);
      }
      if (init.registerAdministration) {
        this.registerAdministration = new DisplayValue(
          init.registerAdministration
        );
      }
      if (init.register) {
        this.register = new DisplayValue(init.register);
      }
      if (init.certificate) {
        this.certificate = new DisplayValue(init.certificate);
      }
      if (init.adapter) {
        this.adapter = new DisplayValue(init.adapter);
      }
      if (init.adapterOperation) {
        this.adapterOperation = new DisplayValue(init.adapterOperation);
      }
    }
  }
}
