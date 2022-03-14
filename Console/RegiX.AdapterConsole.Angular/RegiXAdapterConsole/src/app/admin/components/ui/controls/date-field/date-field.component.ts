import { Component, OnInit, Input, DebugElement } from '@angular/core';
import { ParameterComponent } from '../../../base/parameter-component';
import { IgxDatePickerComponent  } from 'igniteui-angular';

@Component({
  selector: 'app-date-field',
  templateUrl: './date-field.component.html',
  styleUrls: ['./date-field.component.scss']
})
export class DateFieldComponent extends ParameterComponent {
  constructor() {
    super();
  }

  @Input()
  isDisabled: boolean = false;

  ngOnInitImplementation() {
    if (this.parameter.parameterInfo.isRequired)
    {
      this.parameterLabel = this.parameterLabel + "*";
    }
  }

  public setToNull(igxSelect: IgxDatePickerComponent, formControlName: string) {
    console.log('setToNull', igxSelect, formControlName);
    igxSelect.value = null;
    this.formGroup.controls[formControlName].setValue(null);
  }
}
