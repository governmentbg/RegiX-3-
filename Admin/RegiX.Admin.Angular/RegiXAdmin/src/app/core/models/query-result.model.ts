export class QueryResultModel<T> {
  public total: number = null;
  public perPage: number = null;
  public currentPage: number = null;
  public lastPage: number = null;
  public data: T[] = [];

  constructor(init?: Partial<QueryResultModel<T>>) {
    if (init) {
      this.total = init.total;
      this.perPage = init.perPage;
      this.currentPage = init.currentPage;
      this.lastPage = init.lastPage;
      if (init.data) {
        this.data = init.data;
      }
    }
  }
}
