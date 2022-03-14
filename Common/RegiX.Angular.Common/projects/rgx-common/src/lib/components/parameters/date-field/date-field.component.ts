import { Component, OnInit, Injector } from '@angular/core';
import { ParameterComponent } from '../parameter-component';
import { IgxDatePickerComponent, WEEKDAYS } from '@infragistics/igniteui-angular';

@Component({
  selector: 'rgx-date-field',
  templateUrl: './date-field.component.html',
  styleUrls: ['./date-field.component.scss']
})
export class DateFieldComponent extends ParameterComponent {
  WEEKDAYS = WEEKDAYS;

  constructor(injector: Injector) {
    super(injector);
  }

  ngOnInitImplementation() {}

  public setToNull(igxSelect: IgxDatePickerComponent, formControlName: string) {
    console.log('setToNull', igxSelect, formControlName);
    igxSelect.value = null;
    this.formGroup.controls[formControlName].setValue(null);
  }
}
