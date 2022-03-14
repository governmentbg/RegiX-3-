import { Component, OnInit, Input } from '@angular/core';
import { FormGroup } from '@angular/forms';
import { OperationParameterModel } from '../../../models/parameters/operation-parameter.model';
import { ArrayParameterComponent } from '../array-parameter/array-parameter.component';

@Component({
  selector: 'rgx-parameters-control',
  templateUrl: './parameters-control.component.html',
  styleUrls: ['./parameters-control.component.scss']
})
export class ParametersControlComponent implements OnInit {
  @Input()
  formGroup: FormGroup;

  @Input()
  operationParameters: OperationParameterModel[];

  @Input()
  arrayIndex: number = null;

  @Input()
  arrayParameterComponent: ArrayParameterComponent = null;

  @Input()
  isDisabled = false;

  constructor() {}

  ngOnInit() {}
}
