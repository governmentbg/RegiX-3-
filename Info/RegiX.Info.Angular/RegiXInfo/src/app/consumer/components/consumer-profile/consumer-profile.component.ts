import { Component, Injector } from '@angular/core';
import { FormComponent } from '@tl/tl-common';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { ConsumerProfileModel } from '../../models/consumer-profile.model';
import { ConsumerProfileService } from '../../services/consumer-profile.service';

@Component({
  selector: 'app-consumer-profile',
  templateUrl: './consumer-profile.component.html',
  styleUrls: ['./consumer-profile.component.scss'],
})
export class ConsumerProfileComponent extends FormComponent<
  ConsumerProfileModel,
  ConsumerProfileService
> {
  identifierTypes: { value: number; name: string }[] = [];
 
  constructor(
    private formBuilder: FormBuilder,
    service: ConsumerProfileService,
    injector: Injector
  ) {
    super(service, injector);
    this.identifierTypes.push(
      {name: 'ЕИК', value: 1},
      {name: 'ЕГН', value: 2},
      {name: 'БУЛСТАТ', value: 3},
      {name: 'ЛНЧ', value: 4}
    );
  }

  buildFormImpl(): FormGroup {
    return this.formBuilder.group({
      name: [
        { value: '', disabled: this.isShowForm() },
        [Validators.required, Validators.minLength(3)],
      ],
      id: [{ value: '', disabled: true }],
      identifier: [{ value: '', disabled: this.isShowForm() }],
      identifierType: [{ value: '', disabled: this.isShowForm() }],
      documentNumber: [{ value: '', disabled: this.isShowForm() }],
    });
  }

  createInputObject(object: ConsumerProfileModel): any {
    // return new ConsumerProfilesInModel(object); Add proper input model
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
