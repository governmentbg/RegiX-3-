export class DisplayValue {
  public id: number;
  public displayName: string;

  constructor(init?: Partial<DisplayValue>) {
    if (init) {
      this.id = init.id;
      this.displayName = init.displayName;
    }
  }
}
