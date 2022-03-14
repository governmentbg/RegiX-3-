import { BaseOperationCallsService } from './base/base-operation-calls.service';
import { Injectable, Injector } from '@angular/core';
import { OperationCallModel } from '../../models/dto/operation-call.model';


@Injectable({
  providedIn: 'root'
})
export class MyOperationCallsService extends BaseOperationCallsService<OperationCallModel> {
 
  constructor(injector: Injector) {
    super(injector,OperationCallModel,"my-operation-calls");
    
  }
}
