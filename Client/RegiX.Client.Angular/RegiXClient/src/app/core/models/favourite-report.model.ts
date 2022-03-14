import { DisplayValue } from './display-value.model';

export class FavouriteReportModel extends DisplayValue {
  public favourite = false;

  constructor(init?: Partial<FavouriteReportModel>) {
    super(init);
    if (init) {
      this.favourite = init.favourite;
    }
  }
}
