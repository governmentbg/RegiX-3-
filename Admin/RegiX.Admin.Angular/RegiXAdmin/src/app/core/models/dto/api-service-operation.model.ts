
import { ABaseCreatableModel } from './base-creatable.model';
import { DisplayValue } from '../display-value.model';

export class ApiServiceOperationModel extends ABaseCreatableModel {
  public name: string = null;
  public code: string = null;
  public description: string = null;
  public resourceName: string = null;

  public apiService: DisplayValue = null;


  constructor(init?: Partial<ApiServiceOperationModel>) {
    super(init);
    if (init) {
      this.name = init.name;
      this.code = init.code;
      this.description = init.description;

      if (init.apiService) {
        this.apiService = new DisplayValue(init.apiService);
      }
    }
  }
}
