import { EColumnType } from '@tl/tl-common';

export class TableFilter {
  public columnName: string = null;
  public columnValue: any = null;
  public columnType: EColumnType = null;

  constructor(init?: Partial<TableFilter>) {
    if (init) {
      this.columnName = init.columnName;
      this.columnValue = init.columnValue;
      this.columnType = init.columnType;
    }
  }
}
