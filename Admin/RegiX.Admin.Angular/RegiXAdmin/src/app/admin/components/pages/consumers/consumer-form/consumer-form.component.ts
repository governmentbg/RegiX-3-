import { Component, OnInit, Injector, ViewChild } from '@angular/core';
import { FormComponent } from '@tl/tl-common';
import { AdministrationModel } from 'src/app/core/models/dto/administration.model';
import { AdministrationsService } from 'src/app/core/services/rest/administration.service';
import { FormGroup, FormBuilder, Validators } from '@angular/forms';
import { ConsumerModel } from 'src/app/core/models/dto/consumer.model';
import { ConsumersService } from 'src/app/core/services/rest/consumers.service';
import { DisplayValue } from 'src/app/core/models/display-value.model';
import { map } from 'rxjs/operators';
import { ConsumerInModel } from 'src/app/core/models/dto/in/consumer.in.model';
import { IgxDialogComponent } from 'igniteui-angular';
import { AdministrationsFilterComponent } from '../../filters/administrations-filter/administrations-filter.component';

@Component({
  selector: 'app-consumer-form',
  templateUrl: './consumer-form.component.html',
  styleUrls: ['./consumer-form.component.scss']
})
export class ConsumerFormComponent extends FormComponent<
  ConsumerModel,
  ConsumersService
> {
  @ViewChild('administraionsFilterDialog')
  administraionsFilterDialog: IgxDialogComponent;
  @ViewChild('administrationsFilter')
  administrationsFilter: AdministrationsFilterComponent;


  constructor(
    private formBuilder: FormBuilder,
    service: ConsumersService,
    private administrationService: AdministrationsService,
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
      oid: [{ value: '', disabled: this.isShowForm() }],
      updatedOn: [{ value: '', disabled: true }],
      updatedBy: [{ value: '', disabled: true }],
      createdBy: [{ value: '', disabled: true }],
      administration: this.formBuilder.group({
        displayName: [{ value: '', disabled: true }],
        id: [{ value: '', disabled: true }],
      }),
      description: [{ value: '', disabled: this.isShowForm() }]
    });
  }

  createInputObject(object: ConsumerModel): any {
    return new ConsumerInModel(object);
  }

  ngOnInitImplementation() {
    this.isDataLoaded = true;
    this.isDataLoading = false;
  }

  protected prepareForCreate() {
    super.prepareForCreate();
    this.isDataLoading = true;
    const admId = this.activatedRoute.snapshot.params['ADM_ID'];
    if (admId) {
      this.administrationService.find(admId).subscribe(
        (adm) => {
          this.isDataLoading = false;
          this.patchAdministration(
            new DisplayValue({ id: admId, displayName: adm.name })
          );
        },
        (error) => {
          this.isDataLoading = false;
        }
      );
    }
  }

  protected onBaseServiceLoaded() {
    // do nothing if in edit or create mode, let the additional operations
    // do their work and set the appropriate flags
    if (this.isShowForm()) {
      super.onBaseServiceLoaded();
    }
  }

  showAdministraions() {
    this.administraionsFilterDialog.open();
    this.administrationsFilter.loadFirstSection();
  }

  administraionSelected(
    selectedItems: { id: number; name: string; data: any; key: string }[]
  ) {
    this.administraionsFilterDialog.close();
    const admDisplayValue = new DisplayValue({
      id: selectedItems[0].id,
      displayName: selectedItems[0].name,
    });
    this.patchAdministration(admDisplayValue);
  }

  private patchAdministration(admDisplayValue: DisplayValue) {
    this.formGroup.patchValue({
      administration: admDisplayValue,
    });
    this.formGroup.markAsDirty();
  }
}
