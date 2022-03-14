import { Subject } from 'rxjs';
import { FormGroup } from '@angular/forms';
import { Injectable } from '@angular/core';


@Injectable()
export class OperationControlService {
    operationSubject : Subject<FormGroup> = new Subject<FormGroup>();

    public OperationControlService() {
    }
}