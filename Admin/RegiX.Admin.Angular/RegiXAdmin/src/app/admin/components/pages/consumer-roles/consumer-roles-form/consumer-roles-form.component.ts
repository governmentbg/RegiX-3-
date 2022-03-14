import { Component, OnInit, Injector } from '@angular/core';
import { FormComponent } from '@tl/tl-common';
import { ConsumerRoleModel } from 'src/app/core/models/dto/consumer-role.model';
import { ConsumerRoleService } from 'src/app/core/services/rest/consumer-role.service';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';

@Component({
  selector: 'app-consumer-roles-form',
  templateUrl: './consumer-roles-form.component.html',
  styleUrls: ['./consumer-roles-form.component.scss']
})
export class ConsumerRolesFormComponent  extends FormComponent<
ConsumerRoleModel,
ConsumerRoleService
> {

constructor(
  private formBuilder: FormBuilder,
  service: ConsumerRoleService,
  injector: Injector
) {
  super(service, injector);
}

buildFormImpl(): FormGroup {
  return this.formBuilder.group({
    name: [
      { value: '', disabled: this.isShowForm() },
      [Validators.required, Validators.minLength(5)]
    ],
    description: [{ value: '', disabled: this.isShowForm() }],
    id: [{ value: '', disabled: true }],
    updatedOn: [{ value: '', disabled: true }],
    updatedBy: [{ value: '', disabled: true }],
    createdBy: [{ value: '', disabled: true }]
  });
}

createInputObject(object: ConsumerRoleModel): any {
  return new ConsumerRoleModel(object);
}

ngOnInitImplementation() {
}

protected onBaseServiceLoaded() {
  // do nothing if in edit or create mode, let the additional operations
  // do their work and set the appropriate flags
  if (this.isShowForm()) {
    super.onBaseServiceLoaded();
  }
}

onCancel() {
  super.onCancel();
}
}
