export class OperationParameterWithValueModel {
    public name: string = null;
    public value: any = null;

    constructor(init?: Partial<OperationParameterWithValueModel>) {
      if (init) {
        this.name = init.name;
        this.value = init.value;     
      }
    }
  }

 