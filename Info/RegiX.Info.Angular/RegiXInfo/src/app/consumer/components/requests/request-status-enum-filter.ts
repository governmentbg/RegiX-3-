import { IgxFilteringOperand } from 'igniteui-angular';

export class IgxRequestEnumFilteringOperand extends IgxFilteringOperand {
  protected constructor() {
    super();
    this.operations = [
      {
        name: 'Чернова',
        isUnary: true,
        iconName: 'filter_alt',
        logic: (target: number) => {
          return target === 0;
        },
      },
      {
        name: 'Нов',
        isUnary: true,
        iconName: 'filter_alt',
        logic: (target: number) => {
          return target === 1;
        },
      },
      {
        name: 'Отхвърлен',
        isUnary: true,
        iconName: 'filter_alt',
        logic: (target: number) => {
          return target === 2;
        },
      },
      {
        name: 'Одобрен',
        isUnary: true,
        iconName: 'filter_alt',
        logic: (target: number) => {
          return target === 3;
        },
      },
     
    ].concat(this.operations);
  }

  /**
   * Applies case sensitivity on strings if provided
   *
   * @memberof IgxStringFilteringOperand
   */
  public static applyIgnoreCase(a: string, ignoreCase: boolean): string {
    a = a || '';
    // bulletproof
    return ignoreCase ? ('' + a).toLowerCase() : a;
  }
}
