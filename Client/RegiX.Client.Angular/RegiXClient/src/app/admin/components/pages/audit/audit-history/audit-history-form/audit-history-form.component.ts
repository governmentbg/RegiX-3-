import { Component, OnInit, Injector } from '@angular/core';
import { AuditValueModel } from 'src/app/core/models/dto/audit-value.model';
import { AuditValuesService } from 'src/app/core/services/rest/audit-values.service';
import { FormComponent } from '@tl/tl-common';
import { FormBuilder, FormGroup } from '@angular/forms';
import { EActions } from 'src/app/admin/enums/actions.enum';

@Component({
  selector: 'app-audit-history-form',
  templateUrl: './audit-history-form.component.html',
  styleUrls: ['./audit-history-form.component.scss']
})
export class AuditHistoryFormComponent extends FormComponent<
  AuditValueModel,
  AuditValuesService
> {
  constructor(
    service: AuditValuesService,
    injector: Injector,
    private formBuilder: FormBuilder
  ) {
    super(service, injector);
  }

  buildFormImpl(): FormGroup {
    return this.formBuilder.group({
      id: [{ value: '', disabled: true }],
      auditTableId: [{ value: '', disabled: true }],
      columnName: [{ value: '', disabled: true }],
      oldValue: [{ value: '', disabled: true }],
      newValue: [{ value: '', disabled: true }],
      auditTableName: [{ value: '', disabled: true }],
      auditTable: [{ value: '', disabled: true }]
    });
  }

  createInputObject(object: AuditValueModel): any {
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
}
