export class MarkdownModel  {
  public id: number;
  public title: string;
  public fileName: string;
  public subMarkdowns?: MarkdownModel[] = [];
  public isSubMarkdownsActive;

  constructor(init?: Partial<MarkdownModel>) {
    if (init) {
      this.id = init.id;
      this.title = init.title;
      this.fileName = init.fileName;
      this.subMarkdowns = init.subMarkdowns;
      this.isSubMarkdownsActive = init.isSubMarkdownsActive;
    }
  }
}