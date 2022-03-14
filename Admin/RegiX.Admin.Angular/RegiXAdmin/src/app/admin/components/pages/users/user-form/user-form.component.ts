import { Component, OnInit, Injector, ViewChild } from '@angular/core';
import { FormComponent } from '@tl/tl-common';
import { UsersModel } from 'src/app/core/models/dto/users.model';
import { UserInModel } from 'src/app/core/models/dto/in/user.in.model';
import { UsersService } from 'src/app/core/services/rest/users.service';
import {
  FormGroup,
  FormBuilder,
  Validators,
  FormControl
} from '@angular/forms';
import { DisplayValue } from 'src/app/core/models/display-value.model';
import { AdministrationsService } from 'src/app/core/services/rest/administration.service';
import { EActions} from '@tl/tl-common';
import { AdministrationModel } from 'src/app/core/models/dto/administration.model';
import { map } from 'rxjs/operators';
import { IgxDialogComponent } from 'igniteui-angular';
import { AdministrationsFilterComponent } from '../../filters/administrations-filter/administrations-filter.component';

@Component({
  selector: 'app-user-form',
  templateUrl: './user-form.component.html',
  styleUrls: ['./user-form.component.scss']
})
export class UserFormComponent extends FormComponent<UsersModel, UsersService> {
  @ViewChild('administraionsFilterDialog')
  administraionsFilterDialog: IgxDialogComponent;
  @ViewChild('administrationsFilter')
  administrationsFilter: AdministrationsFilterComponent;

  constructor(
    private formBuilder: FormBuilder,
    service: UsersService,
    private administrationService: AdministrationsService,
    injector: Injector
  ) {
    super(service, injector);
  }

  buildFormImpl(): FormGroup {
    let formBuildObject: any;
    formBuildObject = {
      name: [{ value: '' }],
      userName: [{ value: '' }],
      id: [{ value: '', disabled: true }],
      active: new FormControl({ value: '' }),
      email: [{ value: '' }],
      isLockedOut: [{ value: '', disabled: true }],
      lastLoginDate: [{ value: '', disabled: true }],
      administration: this.formBuilder.group({
        displayName: [{ value: '', disabled: true }],
        id: [{ value: '', disabled: true }],
      }),
      administrationName: [{ value: '' }],
      updatedOn: [{ value: '', disabled: true }],
      updatedBy: [{ value: '', disabled: true }],
      createdBy: [{ value: '', disabled: true }],
      isAdmin: [{ value: ''}]
    };

    return this.formBuilder.group(formBuildObject);
  }

  createInputObject(object: UsersModel): any {
    return new UserInModel(object);
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

  isAdminChanged(event) {

    this.logger.debug("isAdmin changed", event);
    const newValue = event.newSelection;

    if (newValue && newValue.value) {
      const isAdmin = newValue.value.id;
    }
  }

  hasValue(formControlName: string) {
    return this.formGroup.controls[formControlName].value !== null;
  }

  hasValueTrue(formControlName: string) {
    return this.formGroup.controls[formControlName].value == true;
  }
}
