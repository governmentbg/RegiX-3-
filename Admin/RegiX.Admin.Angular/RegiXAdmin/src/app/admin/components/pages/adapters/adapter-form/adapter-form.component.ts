import { Component, OnInit, Injector } from '@angular/core';
import { FormComponent } from '@tl/tl-common';
import { FormGroup, FormBuilder, Validators } from '@angular/forms';
import { AdapterModel } from 'src/app/core/models/dto/adapters.model';
import { AdaptersService } from 'src/app/core/services/rest/adapters.service';
import { DisplayValue } from 'src/app/core/models/display-value.model';
import { map } from 'rxjs/operators';
import { RegistryService } from 'src/app/core/services/rest/registry.service';
import { RegistryModel } from 'src/app/core/models/dto/registy.model';
import { AdapterInModel } from 'src/app/core/models/dto/in/adapter.in.model';
import { AdapterOperationModel } from 'src/app/core/models/dto/adapter-operation.model';

@Component({
  selector: 'app-adapter-form',
  templateUrl: './adapter-form.component.html',
  styleUrls: ['./adapter-form.component.scss']
})
export class AdapterFormComponent extends FormComponent<
  AdapterModel,
  AdaptersService
> {
  registries: DisplayValue[] = [];
  adapterOperations: AdapterOperationModel[] = [];

  constructor(
    private formBuilder: FormBuilder,
    service: AdaptersService,
    private registryService: RegistryService,
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
      id: [{ value: '', disabled: true }],
      contract: [
        { value: '', disabled: this.isShowForm() },
        [Validators.required]
      ],
      register: this.formBuilder.group({
        displayName: [{ value: '', disabled: true }],
        id: [{ value: '', disabled: true }],
      }),
      description: [{ value: '', disabled: this.isShowForm() }],
      assembly: [{ value: '', disabled: this.isShowForm() }],
      adapterUrl: [{ value: '', disabled: this.isShowForm() }],
      bindingConfigName: [{ value: '', disabled: this.isShowForm() }],
      bindingType: [{ value: '', disabled: this.isShowForm() }],
      behaviour: [{ value: '', disabled: this.isShowForm() }],
      hostAvailability: [{value: '', disabled: true}],
      updatedOn: [{ value: '', disabled: true }],
      updatedBy: [{ value: '', disabled: true }],
      createdBy: [{ value: '', disabled: true }]
    });
  }

  createInputObject(object: AdapterModel): any {
    return new AdapterInModel(object);
  }

  ngOnInitImplementation() {
    this.isDataLoaded = true;
    this.isDataLoading = false;
  }

  protected onBaseServiceLoaded() {
    // do nothing if in edit or create mode, let the additional operations
    // do their work and set the appropriate flags
    if (this.isShowForm()) {
      super.onBaseServiceLoaded();
    }
  }
}
