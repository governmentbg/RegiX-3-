import { CrudService } from '@tl/tl-common';
import { Injectable, Injector } from '@angular/core';
import { AuditTableModel } from '../../models/dto/audit-table.model';

@Injectable({
  providedIn: 'root'
})
export class AuditTableService extends CrudService<AuditTableModel, number> {
  constructor(injector: Injector) {
    super(AuditTableModel, injector, 'audit-table');
  }
}
