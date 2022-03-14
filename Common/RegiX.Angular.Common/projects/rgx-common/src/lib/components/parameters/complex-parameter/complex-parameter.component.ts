import { Component, OnInit, Input } from '@angular/core';
import { FormGroup, FormBuilder } from '@angular/forms';
import { OperationParameterModel } from '../../../models/parameters/operation-parameter.model';
import { ArrayParameterComponent } from '../array-parameter/array-parameter.component';

@Component({
  selector: 'rgx-complex-parameter',
  templateUrl: './complex-parameter.component.html',
  styleUrls: ['./complex-parameter.component.scss']
})
export class ComplexParameterComponent implements OnInit {
  @Input()
  controlName: string;

  @Input()
  controlLabel: string;

  @Input()
  formGroup: FormGroup;

  @Input()
  arrayIndex: number = null;
  
  @Input()
  isDisabled = false;

  @Input()
  operationParameters: OperationParameterModel[];

  @Input()
  arrayParameterComponent: ArrayParameterComponent = null;

  formGroupInternal: FormGroup;

  constructor(
    private formBuilder: FormBuilder) {}

  ngOnInit() {
    this.formGroupInternal = this.formBuilder.group({});
    const controlNameWithSuffix = this.getControlName();
    this.formGroup.addControl(controlNameWithSuffix, this.formGroupInternal);
  }

  private getControlName() {
     const parameterNameSuffix = (this.arrayIndex != null) ? '_' + this.arrayIndex : '';
     return this.controlName + parameterNameSuffix;
  }

  onRemove(event: any) {
    event.preventDefault();
    this.formGroup.removeControl(this.getControlName());
    this.arrayParameterComponent.onRemove(this.arrayIndex);
  }
}
