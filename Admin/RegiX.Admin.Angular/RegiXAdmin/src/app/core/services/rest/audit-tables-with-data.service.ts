import { CrudService} from '@tl/tl-common';
import { Injectable, Injector } from '@angular/core';
import { AuditTableWithDataModel } from '../../models/dto/audit-table-with-data.model';
import { HttpParams } from '@angular/common/http';
import { Observable } from 'rxjs';
import { map } from 'rxjs/operators';

@Injectable({
  providedIn: 'root'
})
export class AuditTablesWithDataService extends CrudService<AuditTableWithDataModel, number> {
  constructor(injector: Injector) {
    super(AuditTableWithDataModel, injector, 'audit-tables-with-data');
  }

}
