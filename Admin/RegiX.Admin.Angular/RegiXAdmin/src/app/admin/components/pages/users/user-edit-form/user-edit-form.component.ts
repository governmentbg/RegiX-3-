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
import { UserEditModel } from 'src/app/core/models/dto/user-edit.model';
import { UserEditService } from 'src/app/core/services/rest/user-edit.service';
import { IgxSelectComponent, IgxDialogComponent } from 'igniteui-angular';
import { AdministrationsFilterComponent } from '../../filters/administrations-filter/administrations-filter.component';

@Component({
  selector: 'app-user-edit-form',
  templateUrl: './user-edit-form.component.html',
  styleUrls: ['./user-edit-form.component.scss']
})
export class UserEditFormComponent extends FormComponent<UserEditModel, UserEditService> {

  @ViewChild('administraionsFilterDialog')
  administraionsFilterDialog: IgxDialogComponent;
  @ViewChild('administrationsFilter')
  administrationsFilter: AdministrationsFilterComponent;

  isAdmin = false;
  constructor(
    private formBuilder: FormBuilder,
    service: UserEditService,
    private administrationService: AdministrationsService,
    injector: Injector
  ) {
    super(service, injector);
  }
  buildFormImpl(): FormGroup {
    let formBuildObject: any;
    formBuildObject = {
      name: [{ value: '', disabled: this.isShowForm() }],
      userName: [{ value: '', disabled: this.isShowForm() }],
      id: [{ value: '', disabled: true }],
      active: new FormControl({ value: '', disabled: this.isShowForm() }),
      email: [{ value: '', disabled: this.isShowForm() }],
      //isLockedOut: [{ value: '', disabled: true }],
      //lastLoginDate: [{ value: '', disabled: true }],
      administration: this.formBuilder.group({
        displayName: [{ value: '', disabled: true }],
        id: [{ value: '', disabled: true }],
      }),
      administrationName: [{ value: '', disabled: this.isShowForm() }],
      updatedOn: [{ value: '', disabled: true }],
      updatedBy: [{ value: '', disabled: true }],
      createdBy: [{ value: '', disabled: true }],
      isAdmin: [{ value: '', disabled: this.isShowForm() }]
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

  administrationChanged(event) {
    this.logger.debug("administration changed", event);
    const newValue = event.newSelection;

    if (newValue && newValue.value) {
      const administrationId = newValue.value.id;

    }
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
  clearAdministration() {
    this.formGroup.patchValue({
      administration: {displayName: undefined, id: undefined},
      administrationName: undefined,
      isAdmin: true
    });
    this.formGroup.markAsDirty();
  }

  private patchAdministration(admDisplayValue: DisplayValue) {
    this.formGroup.patchValue({
      administration: admDisplayValue,
      isAdmin: false
    });
    this.formGroup.markAsDirty();
  }
}

