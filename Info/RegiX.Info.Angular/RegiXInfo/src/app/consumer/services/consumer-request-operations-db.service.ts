
import { CrudService} from '@tl/tl-common';
import { Injectable, Injector } from '@angular/core';
import { HierarchyModel } from '../models/hierarchy.model';

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