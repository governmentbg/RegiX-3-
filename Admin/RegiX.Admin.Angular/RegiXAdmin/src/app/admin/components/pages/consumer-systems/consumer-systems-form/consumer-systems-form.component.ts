
import { ConsumerSystemsService } from './../../../../../core/services/rest/consumer-systems.service';
import { ConsumerSystemsModel } from './../../../../../core/models/dto/consumer-systems.model';
import { Component, ViewChild, Injector } from '@angular/core';
import { FormComponent } from '@tl/tl-common';
import { IgxDialogComponent } from 'igniteui-angular';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { DisplayValue } from 'src/app/core/models/display-value.model';
import { ConsumerSystemsFilterComponent } from '../../filters/consumer-systems-filter/consumer-systems-filter.component';

@Component({
  selector: 'app-consumer-systems-form',
  templateUrl: './consumer-systems-form.component.html',
  styleUrls: ['./consumer-systems-form.component.scss'],
})
export class ConsumerSystemsFormComponent extends FormComponent<
  ConsumerSystemsModel,
  ConsumerSystemsService
> {
  @ViewChild('consumersFilterDialog')
  consumersFilterDialog: IgxDialogComponent;
  @ViewChild('consumersFilter')
  consumersFilter: ConsumerSystemsFilterComponent;

  constructor(
    private formBuilder: FormBuilder,
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
      description: [{ value: '', disabled: this.isShowForm() }],
      staticIP: [{ value: '', disabled: this.isShowForm() }],
      apiServiceConsumer: this.formBuilder.group({
        displayName: [{ value: '', disabled: true }],
        id: [{ value: '', disabled: true }],
      }),
      consumerProfile: this.formBuilder.group({
        displayName: [{ value: ' ', disabled: true }],
        id: [{ value: '', disabled: true }],
      }),
      consumerProfileName: [{ value: '', disabled: this.isShowForm() }],
    });
  }

  createInputObject(object: ConsumerSystemsModel): any {
    return new ConsumerSystemsModel(object); //TODO: add in model if needed
  }

  ngOnInitImplementation() {
    this.isDataLoaded = true;
    this.isDataLoading = false;
  }

  protected buildForm() {
    this.formGroup = this.buildFormImpl();
    if(this.formObject.apiServiceConsumer == null){
      this.formObject.apiServiceConsumer = new DisplayValue();
      this.formObject.apiServiceConsumer.id = '';
      this.formObject.apiServiceConsumer.displayName = '';
    }
  }

  protected onBaseServiceLoaded() {
    // do nothing if in edit or create mode, let the additional operations
    // do their work and set the appropriate flags
    if (this.isShowForm()) {
      super.onBaseServiceLoaded();
    }
  }

  showConsumers() {
    this.consumersFilterDialog.open();
    this.consumersFilter.loadFirstSection();
  }

  consumerSelected(
    selectedItems: { id: number; name: string; data: any; key: string }[]
  ) {
    this.consumersFilterDialog.close();
    const cnsDisplayValue = new DisplayValue({
      id: selectedItems[0].id,
      displayName: selectedItems[0].name,
    });
    this.patchConsumer(cnsDisplayValue);
  }

  private patchConsumer(admDisplayValue: DisplayValue) {
    this.formGroup.patchValue({
      apiServiceConsumer: admDisplayValue,
    });
    this.formGroup.markAsDirty();
  }
}
