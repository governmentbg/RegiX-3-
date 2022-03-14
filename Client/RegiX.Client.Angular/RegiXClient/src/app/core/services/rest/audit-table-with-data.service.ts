import { CrudService } from '@tl/tl-common';
import { Injectable, Injector } from '@angular/core';
import { AuditTableWithDataModel } from '../../models/dto/audit-table-with-data.model';

@Injectable({
  providedIn: 'root'
})
export class AuditTableWithDataService extends CrudService<AuditTableWithDataModel, number> {
  constructor(injector: Injector) {
    super(AuditTableWithDataModel, injector, 'audit-table-with-data');
  }

  gridFilteringFields(): {
    [name: string]: string;
  } {
    return {
      authority: 'authority.displayName',
      user: 'user.displayName',
    };
  }
}
