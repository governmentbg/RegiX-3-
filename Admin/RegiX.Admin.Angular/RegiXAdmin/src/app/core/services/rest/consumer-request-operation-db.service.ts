import { HierarchyModel } from './../../models/hierarchy.model';
import { CrudService} from '@tl/tl-common';
import { Injectable, Injector } from '@angular/core';

@Injectable({
  providedIn: 'root'
})
export class ConsumerRequestOperationsDbService extends CrudService<
HierarchyModel,
  number
> {
  constructor(injector: Injector) {
    super(HierarchyModel, injector, 'consumer-request-operation-db');
  }
}