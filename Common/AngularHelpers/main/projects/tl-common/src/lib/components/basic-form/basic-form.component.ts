import { Component, OnInit, Input } from '@angular/core';
import { EActions } from '../../enums/actions.enum';
import { FormComponent } from '../base-forms/form-component';
import { ABaseModel } from '../../models/base.model';

@Component({
  selector: 'tl-basic-form',
  templateUrl: './basic-form.component.html',
  styleUrls: ['./basic-form.component.scss']
})
export class BasicFormComponent implements OnInit {

  readonly RESET_ACTION = EActions.RESET;

  @Input()
  title: string;

  @Input()
  baseForm: FormComponent<ABaseModel, any>;

  constructor() { }

  ngOnInit() {
  }

}
