import { CrudService} from '@tl/tl-common';
import { Injectable, Injector } from '@angular/core';
import { ExceptionModel } from '../../models/dto/exception.model';

@Injectable({
  providedIn: 'root'
})
export class ExceptionsService extends CrudService<ExceptionModel, number> {
  constructor(injector: Injector) {
    super(ExceptionModel, injector, 'audit-exceptions');
  }
}
