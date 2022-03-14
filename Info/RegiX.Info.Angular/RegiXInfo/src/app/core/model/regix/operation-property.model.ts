import { BaseModel } from './base.model';

export class OperationPropertyModel extends BaseModel {
  description: string;
  children: OperationPropertyModel[];

  constructor(init?: Partial<OperationPropertyModel>) {
    super(init);
    if (this.children == null) {
      this.children = [];
    }
    if (init) {
      this.description = init.description;
      if (init.children) {
        init.children.map(d =>
          this.children.push(new OperationPropertyModel(d))
        );
      }
    }
  }
}

