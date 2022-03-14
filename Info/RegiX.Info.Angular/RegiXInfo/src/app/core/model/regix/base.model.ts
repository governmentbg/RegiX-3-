import { OnInit } from '@angular/core';
export abstract class BaseModel {
  name: string;

  constructor(init?: Partial<BaseModel>) {
    if (init) {
      this.name = init.name;
    }
  }
}
