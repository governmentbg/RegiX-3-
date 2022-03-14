
import { Injectable, Injector } from '@angular/core';
import { OperationCallModel } from '../../models/dto/operation-call.model';
import { BaseOperationCallsService } from './base/base-operation-calls.service';

@Injectable({
  providedIn: 'root'
})
export class OperationCallsService extends BaseOperationCallsService<OperationCallModel> {
  
  constructor(injector: Injector) {
    super(injector,OperationCallModel,"operation-calls");
    
  }

  gridFilteringFields(): {
    [name: string]: string;
  } {
    return {
      adapterOperation: 'adapterOperation.displayName',
      assignedTo: 'assignedTo.displayName',
    };
  }
}