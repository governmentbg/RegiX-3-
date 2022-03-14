import { Component, Injector } from '@angular/core';
import { FormComponent } from '@tl/tl-common';
import { ConsumerSystemsModel } from 'src/app/consumer/models/consumer-systems.model';
import { ConsumerSystemsService } from 'src/app/consumer/services/consumer-systems.service';
import { Validators, FormGroup, FormBuilder } from '@angular/forms';
import { ConsumerSystemsInModel } from 'src/app/consumer/models/in/consumer-systems.in.model';
import { LoginService } from 'src/app/consumer/services/login.service';

@Component({
  selector: 'app-system-form',
  templateUrl: './system-form.component.html',
  styleUrls: ['./system-form.component.scss'],
})
export class SystemFormComponent extends FormComponent<
  ConsumerSystemsModel,
  ConsumerSystemsService
> {
  constructor(
    private formBuilder: FormBuilder,
    private loginService: LoginService,
    service: ConsumerSystemsService,
    injector: Injector
  ) {
    super(service, injector);
  }

  buildFormImpl(): FormGroup {
    return this.formBuilder.group({
      id: [{ value: '', disabled: true }],
      name: [
        { value: '', disabled: this.isShowForm() },
        [Validators.required, Validators.minLength(5)],
      ],
      description: [
        { value: '', disabled: this.isShowForm() },
        [Validators.required],
      ],
      staticIP: [
        { value: '', disabled: this.isShowForm() }
      ],
    });
  }

  createInputObject(object: ConsumerSystemsModel): any {
    let result = new ConsumerSystemsInModel(object);
    result.consumerProfileId = this.loginService.getConsumerProfileId();
    return result;
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
