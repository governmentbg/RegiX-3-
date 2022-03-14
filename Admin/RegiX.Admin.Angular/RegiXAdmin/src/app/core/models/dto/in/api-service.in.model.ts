import { ApiServiceModel } from '../api-service.model';

export class ApiServiceInModel {
  public name: string = null;
  public code: string = null;
  public description: string = null;
  public administrationId: number = null;

  public serviceUrl: string = null;

  public contract: string = null;
  public isComplex: boolean = null;
  public assembly: string = null;
  public enabled: boolean = null;
  public controlerName: string = null;

  constructor(init?: Partial<ApiServiceModel>) {
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
        this.administrationId = init.administration.id;
      }
    }
  }
}
