import { Component, OnInit, Input, AfterViewInit } from '@angular/core';
import { FormGroup } from '@angular/forms';
import { OperationParameterModel } from 'src/app/core/models/operations/operation-parameter.model';
import { OperationControlService } from '../../pages/operation-calls/operation-call/operation-control-service.service';

@Component({
  selector: 'app-parameters-control',
  templateUrl: './parameters-control.component.html',
  styleUrls: ['./parameters-control.component.scss']
})
export class ParametersControlComponent implements OnInit, AfterViewInit {
  @Input()
  formGroup: FormGroup;

  @Input()
  operationParameters: OperationParameterModel[];

  @Input()
  isDisabled?: boolean;
 
  constructor(
    private operationSubjectService: OperationControlService) {}

  ngOnInit() {
  }

  ngAfterViewInit(){
    console.log( 'ParametersControlComponent => AfterInit', this.formGroup);
    this.operationSubjectService.operationSubject.next(this.formGroup);
  }
}
