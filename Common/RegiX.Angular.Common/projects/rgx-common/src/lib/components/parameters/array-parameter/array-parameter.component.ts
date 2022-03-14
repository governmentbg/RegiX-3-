import { Component, OnInit, Input } from '@angular/core';
import { FormGroup, FormBuilder } from '@angular/forms';
import { OperationParameterModel } from '../../../models/parameters/operation-parameter.model';

@Component({
  selector: 'rgx-array-parameter',
  templateUrl: './array-parameter.component.html',
  styleUrls: ['./array-parameter.component.scss']
})
export class ArrayParameterComponent  implements OnInit {
  @Input()
  controlName: string;
  @Input()
  controlLabel: string;
  @Input()
  formGroup: FormGroup;
  formGroupInternal: FormGroup;
  @Input()
  operationParameters: OperationParameterModel[];
  @Input()
  isDisabled = false;

  public arrayItems = [];

  index = 0;

  constructor(
    private formBuilder: FormBuilder) {}

  ngOnInit() {
    this.formGroupInternal = this.formBuilder.group({});
    this.formGroup.addControl(this.controlName, this.formGroupInternal);
  }

  onAdd(event: any) {
    event.preventDefault();
    this.arrayItems.push(this.index);
    this.index++;
    console.log(this.formGroup.getRawValue());
  }

  onRemove(i: number) {
    console.log(i);
    console.log(this.formGroup.getRawValue());
    const index = this.arrayItems.indexOf(i, 0);
    if (index > -1) {
      this.arrayItems.splice(index, 1);
    }
  }
}
