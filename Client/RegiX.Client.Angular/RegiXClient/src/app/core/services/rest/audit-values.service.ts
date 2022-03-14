import { CrudService } from '@tl/tl-common';
import { Injectable, Injector } from '@angular/core';
import { AuditValueModel } from '../../models/dto/audit-value.model';

@Injectable({
  providedIn: 'root'
})
export class AuditValuesService extends CrudService<AuditValueModel, number> {
  constructor(injector: Injector) {
    super(AuditValueModel, injector, 'audit-value');
  }

  gridFilteringFields(): {
    [name: string]: string;
  } {
    return {
      auditTable: 'auditTable.displayName'
    };
  }
}
