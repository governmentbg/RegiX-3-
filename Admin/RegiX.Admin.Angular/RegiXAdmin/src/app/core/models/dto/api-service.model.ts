import { DisplayValue } from '../display-value.model';
import { ABaseCreatableModel } from './base-creatable.model';

export class ApiServiceModel extends ABaseCreatableModel {
  public name: string = null;
  public code: string = null;
  public description: string = null;
  public administration: DisplayValue = null;
  public administrationName: string = null;

  public serviceUrl: string = null;

  public contract: string = null;
  public isComplex: boolean = null;
  public assembly: string = null;
  public enabled: boolean = null;
  public controlerName: string = null;

  constructor(init?: Partial<ApiServiceModel>) {
    super(init);
    if (init) {
      this.name = init.name;
      this.code = init.code;

      this.contract = init.contract;
      this.isComplex = init.isComplex;
      this.assembly = init.assembly;
      this.enabled = init.enabled;
      this.controlerName = init.controlerName;
      this.serviceUrl = init.serviceUrl;

      this.description = init.description;
      if (init.administration) {
        this.administration = new DisplayValue(init.administration);
        this.administrationName = init.administration.displayName;
      }
    }
  }
}
