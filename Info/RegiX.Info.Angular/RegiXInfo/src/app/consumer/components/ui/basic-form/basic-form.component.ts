import { Component, OnInit, Input } from '@angular/core';
import { FormComponent, ABaseModel, EActions } from '@tl/tl-common';

@Component({
  selector: 'app-basic-form',
  templateUrl: './basic-form.component.html',
  styleUrls: ['./basic-form.component.scss']
})
export class BasicFormComponent implements OnInit {

  readonly RESET_ACTION = EActions.RESET;

  @Input()
  baseForm: FormComponent<ABaseModel, any>;

  constructor() { }

  ngOnInit() {
  }

}
