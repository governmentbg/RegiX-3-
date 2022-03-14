export class SearchResult {
  displayName: string;
  type: string;
  arguments: string[];
  public constructor(init?: Partial<SearchResult>) {
      if (init) {
        this.displayName = init.displayName;
        this.type = init.type;
        this.arguments = init.arguments;
      }
    }
}
