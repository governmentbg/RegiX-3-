export class UserFavouriteReportInModel {
  public reportIds: number[] = [];

  constructor(init?: Partial<UserFavouriteReportInModel>) {
    if (init) {
      this.reportIds = init.reportIds;
    }
  }
}
