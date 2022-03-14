export class EnumValueModel {
  public value?: string = null;
  public displayText?: string = null;
  public identifierType?: string = null;

  constructor(init?: Partial<EnumValueModel>) {
    if (init) {
      this.displayText = init.displayText;
      this.identifierType = init.identifierType;
      this.value = init.value;
    }
  }
}
