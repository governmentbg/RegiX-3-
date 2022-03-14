import { Component, Injector, ViewChild } from '@angular/core';
import { ParameterComponent } from '../parameter-component';
import { IgxTimePickerComponent, WEEKDAYS } from '@infragistics/igniteui-angular';

@Component({
  selector: 'rgx-date-time-field',
  templateUrl: './date-time-field.component.html',
  styleUrls: ['./date-time-field.component.scss']
})
export class DateTimeFieldComponent extends ParameterComponent {
  @ViewChild('timePicker', { read: IgxTimePickerComponent, static: false })
  public timePicker: IgxTimePickerComponent;

  WEEKDAYS = WEEKDAYS;

  constructor(injector: Injector) {
    super(injector);
  }

  ngOnInitImplementation() {
  }

  fillTime() {
    const paramValue: Date = this.formGroup.value[this.parameterName];
    this.timePicker.value = paramValue;
  }
}
