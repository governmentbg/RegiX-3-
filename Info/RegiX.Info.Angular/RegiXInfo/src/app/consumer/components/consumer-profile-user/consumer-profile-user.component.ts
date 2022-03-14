import { Component, Injector } from '@angular/core';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { FormComponent } from '@tl/tl-common';
import { ConsumerProfileUsersModel } from '../../models/consumer-profile-user.model';
import { ConsumerProfileUsersService } from '../../services/consumer-profile-users.service';

@Component({
  selector: 'app-consumer-profile-user',
  templateUrl: './consumer-profile-user.component.html',
  styleUrls: ['./consumer-profile-user.component.scss'],
})
export class ConsumerProfileUserComponent  extends FormComponent<
  ConsumerProfileUsersModel,
  ConsumerProfileUsersService
> {
  constructor(
    private formBuilder: FormBuilder,
    service: ConsumerProfileUsersService,
    injector: Injector
  ) {
    super(service, injector);
  }

  buildFormImpl(): FormGroup {
    return this.formBuilder.group({
      name: [
        { value: '', disabled: this.isShowForm() },
        [Validators.required, Validators.minLength(3)],
      ],
      id: [{ value: '', disabled: true }],
      email: [{ value: '', disabled: this.isShowForm() },[Validators.email]],
      phoneNumber: [{ value: '', disabled: this.isShowForm() }],
      position: [{ value: '', disabled: this.isShowForm() }],
    });
  }

  createInputObject(object: ConsumerProfileUsersModel): any {
     return new ConsumerProfileUsersModel(object);
  }

  ngOnInitImplementation() {
  }

}
