import { ABaseModel } from 'src/app/core/models/dto/base.model';
import { DisplayValue } from '../display-value.model';

export class LogReviewPrimaryFilterModel extends ABaseModel {
  public fromDate: Date = null;
  public toDate: Date = null;
  public administration: DisplayValue = null;
  public apiService: DisplayValue = null;
  public apiServiceOperation: DisplayValue = null;

  constructor(init?: Partial<LogReviewPrimaryFilterModel>) {
    super(init);
    if (init) {
      this.fromDate = init.fromDate;
      this.toDate = init.toDate;
      if (init.administration) {
        this.administration = new DisplayValue(
          init.administration
        );
      }
      if (init.apiService) {
        this.apiService = new DisplayValue(init.apiService);
      }
      if (init.apiServiceOperation) {
        this.apiServiceOperation = new DisplayValue(init.apiServiceOperation);
      }
    }
  }
}
