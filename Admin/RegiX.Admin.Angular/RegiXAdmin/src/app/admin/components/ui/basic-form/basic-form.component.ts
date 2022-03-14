import { Component, OnInit, Input } from '@angular/core';
import { FormComponent } from '@tl/tl-common';
import { EActions} from '@tl/tl-common';
import { ABaseModel } from 'src/app/core/models/dto/base.model';

@Component({
  selector: 'app-basic-form',
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
