import { Component, Injector } from '@angular/core';
import { FormComponent } from '@tl/tl-common';
import { AdministrationTypeModel } from 'src/app/core/models/dto/administration-type.model';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { AdministrationTypeService } from 'src/app/core/services/rest/administration-type.service';

@Component({
  selector: 'app-administration-type-form',
  templateUrl: './administration-type-form.component.html',
  styleUrls: ['./administration-type-form.component.scss'],
})
export class AdministrationTypeFormComponent extends FormComponent<
  AdministrationTypeModel,
  AdministrationTypeService
> {
  constructor(
    private formBuilder: FormBuilder,
    service: AdministrationTypeService,
    injector: Injector
  ) {
    super(service, injector);
  }

  buildFormImpl(): FormGroup {
    return this.formBuilder.group({
      id: [{ value: '', disabled: this.isShowForm() }],
      name: [{ value: '', disabled: this.isShowForm() }, [Validators.required]],
      description: [{ value: '', disabled: this.isShowForm() }],
      publiclyVisible: [{ value: '', disabled: this.isShowForm() }],
    });
  }

  createInputObject(object: AdministrationTypeModel): any {
    return new AdministrationTypeModel(object);
  }

  ngOnInitImplementation() {}

  protected onBaseServiceLoaded() {
    // do nothing if in edit or create mode, let the additional operations
    // do their work and set the appropriate flags
    if (this.isShowForm()) {
      super.onBaseServiceLoaded();
    }
  }
}
