import { Component, OnInit, Input } from '@angular/core';
import { ParameterComponent } from '../../../base/parameter-component';

@Component({
  selector: 'app-text-field',
  templateUrl: './text-field.component.html',
  styleUrls: ['./text-field.component.scss']
})
export class TextFieldComponent extends ParameterComponent {
  constructor() {
    super();
  }

  @Input()
  isDisabled: boolean = false;

  ngOnInitImplementation() {}
}
