import { Component, Injector, OnInit, ViewChild } from '@angular/core';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { FormComponent } from '@tl/tl-common';
import { IgxDialogComponent, IgxSelectComponent } from 'igniteui-angular';
import { ConsumerProfilesStatus } from 'src/app/admin/enums/consumer-profiles-status.enum';
import { DisplayValue } from 'src/app/core/models/display-value.model';
import { ConsumerProfilesModel } from 'src/app/core/models/dto/consumer-profiles.model';
import { ConsumerProfilesInModel } from 'src/app/core/models/dto/in/consumer-profiles.in.model';
import { ConsumerProfilesService } from 'src/app/core/services/rest/consumer-profiles.service';
import { AdministrationsFilterComponent } from '../../filters/administrations-filter/administrations-filter.component';

@Component({
  selector: 'app-consumer-profiles-approval-form',
  templateUrl: './consumer-profiles-approval-form.component.html',
  styleUrls: ['./consumer-profiles-approval-form.component.scss'],
})
export class ConsumerProfilesApprovalFormComponent extends FormComponent<
  ConsumerProfilesModel,
  ConsumerProfilesService
> {
  @ViewChild('administraionsFilterDialog')
  administraionsFilterDialog: IgxDialogComponent;
  @ViewChild('administrationsFilter')
  administrationsFilter: AdministrationsFilterComponent;

  @ViewChild('statusSelectComponent', {
    read: IgxSelectComponent,
    static: true,
  })
  public statusSelectComponent: IgxSelectComponent;

  statusEnums: DisplayValue[] = [
    { id: 0, displayName: ConsumerProfilesStatus.NEW },
    { id: 1, displayName: ConsumerProfilesStatus.DECLINED },
    { id: 2, displayName: ConsumerProfilesStatus.ACCEPTED },
  ];

  startingStatus: number;
  currentStatus: number;
  isCommentDisabled: boolean = true;

  constructor(
    private formBuilder: FormBuilder,
    service: ConsumerProfilesService,
    injector: Injector
  ) {
    super(service, injector);
  }

  buildFormImpl(): FormGroup {
    return this.formBuilder.group({
      name: [{ value: '', disabled: this.isShowForm() }],
      id: [{ value: '', disabled: true }],
      identifier: [{ value: '', disabled: this.isShowForm() }],
      identifierType: [{ value: '', disabled: true }],
      address: [{ value: '', disabled: true }],
      status: [{ value: '', disabled: this.isShowForm() }],
      comment: [
        { value: '', disabled: this.isCommentDisabled },
        [Validators.required, Validators.minLength(2)],
      ],
      acceptedEula: [{ value: '', disabled: this.isShowForm() }],
      securityStamp: [{ value: '', disabled: this.isShowForm() }],
      documentNumber: [
        { value: '', disabled: this.isShowForm() },
        Validators.required,
      ],
      administration: this.formBuilder.group(
        {
          displayName: [{ value: '', disabled: this.isShowForm() }, Validators.required],
          id: [{ value: '', disabled: this.isShowForm() }, Validators.required],
        }
      ),
    });
  }

  createInputObject(object: ConsumerProfilesModel): any {
    return new ConsumerProfilesInModel(object);
  }

  ngOnInitImplementation() {
    this.isDataLoaded = true;
    this.isDataLoading = false;
  }

  protected buildForm() {
    this.formGroup = this.buildFormImpl();
    if (this.formObject.administration == null) {
      this.formObject.administration = new DisplayValue();
      this.formObject.administration.id = '';
      this.formObject.administration.displayName = '';
    }
    this.startingStatus = this.formObject.status;
    this.currentStatus = this.formObject.status;
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

  getCurrentValue() {
    if (this.currentStatus !== this.startingStatus) {
      this.isCommentDisabled = false;
      this.formGroup.controls['comment'].enable();
    } else {
      this.isCommentDisabled = true;
      this.formGroup.controls['comment'].disable();
    }
  }
}