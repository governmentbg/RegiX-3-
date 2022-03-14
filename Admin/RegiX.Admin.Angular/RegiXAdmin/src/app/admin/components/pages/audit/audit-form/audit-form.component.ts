import { Component, OnInit, Injector, ViewChild } from '@angular/core';
import { AuditTableModel } from 'src/app/core/models/dto/audit-table.model';
import { AuditTablesService } from 'src/app/core/services/rest/audit-tables.service';
import { FormComponent } from '@tl/tl-common';
import { FormBuilder, FormGroup } from '@angular/forms';
import { EActions} from '@tl/tl-common';
import { AuditTableWithDataModel } from 'src/app/core/models/dto/audit-table-with-data.model';
import { AuditTablesWithDataService } from 'src/app/core/services/rest/audit-tables-with-data.service';

@Component({
  selector: 'app-audit-form',
  templateUrl: './audit-form.component.html',
  styleUrls: ['./audit-form.component.scss']
})
export class AuditFormComponent extends FormComponent<
  AuditTableWithDataModel,
  AuditTablesWithDataService
> {

  @ViewChild('grid')
  public grid: any;

  constructor(
    service: AuditTablesWithDataService,
    injector: Injector,
    private formBuilder: FormBuilder
  ) {
    super(service, injector);
  }

  buildFormImpl(): FormGroup {
    return this.formBuilder.group({
      id: [{ value: '', disabled: true }],
      userId: [{ value: '', disabled: true }],
      userName: [{ value: '', disabled: true }],
      auditDate: [{ value: '', disabled: true }],
      action: [{ value: '', disabled: true }],
      tableName: [{ value: '', disabled: true }],
      ipAddress: [{ value: '', disabled: true }],
      appName: [{ value: '', disabled: true }],
      tableId: [{ value: '', disabled: true }],
      description: [{ value: '', disabled: true }],
      auditValues: [{ value: '', disabled: true }]
    });
  }

  createInputObject(object: AuditTableModel): any {
    return null;
  }

  ngOnInitImplementation() {}

  prepareForm() {
    switch (this.currentAction) {
      case EActions.SHOW: {
        super.prepareForShow(this.formObject);
        break;
      }
    }
  }

  pagerChange(event) {
    this.grid.perPage = event.perPage;
    this.grid.page = event.page;
  }

}
