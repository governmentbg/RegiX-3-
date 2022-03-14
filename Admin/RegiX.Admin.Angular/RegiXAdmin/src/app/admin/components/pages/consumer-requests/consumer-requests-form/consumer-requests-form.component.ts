import { ConsumerRequestsModel } from './../../../../../core/models/dto/consumer-requests.model';
import { Component, OnInit, Injector } from '@angular/core';
import { FormComponent } from '@tl/tl-common';
import { ConsumerRequestsService } from 'src/app/core/services/rest/consumer-requests.service';
import { DisplayValue } from 'src/app/core/models/display-value.model';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { ROUTES } from 'src/app/admin/routes/static-routes';
import { ConsumerProfilesStatus } from 'src/app/admin/enums/consumer-profiles-status.enum';
import { ConsumerRequestsStatus } from 'src/app/admin/enums/consumer-requests-status.enum';
@Component({
  selector: 'app-consumer-requests-form',
  templateUrl: './consumer-requests-form.component.html',
  styleUrls: ['./consumer-requests-form.component.scss'],
})
export class ConsumerRequestsFormComponent extends FormComponent<
  ConsumerRequestsModel,
  ConsumerRequestsService
> {
  public routes = ROUTES;
  public currentStatus: number;

  statusEnums: DisplayValue[] = [
    { id: 0, displayName: ConsumerRequestsStatus.DRAFT },
    { id: 1, displayName: ConsumerRequestsStatus.NEW },
    { id: 2, displayName: ConsumerRequestsStatus.DECLINED },
    { id: 3, displayName: ConsumerRequestsStatus.ACCEPTED },
  ]; 

  constructor(
    private formBuilder: FormBuilder,
    service: ConsumerRequestsService,
    injector: Injector
  ) {
    super(service, injector);
  }

  buildFormImpl(): FormGroup {
    return this.formBuilder.group({
      name: [{ value: '', disabled: this.isShowForm() }],
      id: [{ value: '', disabled: true }],
      outDocumentNumber: [{ value: '', disabled: this.isShowForm() }],
      documentNumber: [{ value: '', disabled: this.isShowForm() }],
      status: [{ value: '', disabled: this.isShowForm() }],
      consumerProfile: this.formBuilder.group({
        displayName: [{ value: '', disabled: true }],
        id: [{ value: '', disabled: true }],
      }),
    });
  }

  createInputObject(object: ConsumerRequestsModel): any {
    return object;
  }

  ngOnInitImplementation() {}

  protected buildForm() {
    this.formGroup = this.buildFormImpl();
    this.currentStatus = +this.formObject.status;//fix status and add rest of the props in the html => Create consumer access requests..~
  }
}
