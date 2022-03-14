import { Injector, Injectable } from '@angular/core';
import { OperationPersistanceModel } from '../../models/dto/operation-persistance.model';
import { CrudService } from '@tl/tl-common';
import { Observable } from 'rxjs';


@Injectable({
  providedIn: 'root'
})
export class OperationPersistanceService extends CrudService<OperationPersistanceModel, number> {
  constructor(injector: Injector) {
    super(OperationPersistanceModel, injector, 'operations-persistance');
  }
}
