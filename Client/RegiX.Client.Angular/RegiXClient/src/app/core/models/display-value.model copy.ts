export class IdentificatorType {
  public name: string;
  public displayName: string;

  constructor(init?: Partial<IdentificatorType>) {
    if (init) {
      this.name = init.name;
      this.displayName = init.displayName;
    }
  }
}
