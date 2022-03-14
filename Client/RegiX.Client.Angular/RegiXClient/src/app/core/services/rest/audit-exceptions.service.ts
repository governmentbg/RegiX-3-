import { CrudService } from '@tl/tl-common';
import { Injectable, Injector } from '@angular/core';
import { AuditExceptionModel } from '../../models/dto/audit-exception.model';

@Injectable({
  providedIn: 'root'
})
export class AuditExceptionsService extends CrudService<
  AuditExceptionModel,
  number
> {
  constructor(injector: Injector) {
    super(AuditExceptionModel, injector, 'audit-exceptions');
  }

  gridFilteringFields(): {
    [name: string]: string;
  } {
    return {
      authority: 'authority.displayName'
    };
  }
}
