import { Component, OnInit, Injector, ViewChild } from '@angular/core';
import { FormComponent } from '@tl/tl-common';
import { RegistryModel } from 'src/app/core/models/dto/registy.model';
import { RegistryService } from 'src/app/core/services/rest/registry.service';
import { AdministrationsService } from 'src/app/core/services/rest/administration.service';
import { FormBuilder, Validators, FormGroup } from '@angular/forms';
import { DisplayValue } from 'src/app/core/models/display-value.model';
import { AdministrationModel } from 'src/app/core/models/dto/administration.model';
import { map } from 'rxjs/operators';
import { RegistryInModel } from 'src/app/core/models/dto/in/registry.in.model';
import { ROUTES } from 'src/app/admin/routes/static-routes';
import { IgxDialogComponent } from 'igniteui-angular';
import { AdministrationsFilterComponent } from '../../filters/administrations-filter/administrations-filter.component';

@Component({
  selector: 'app-registry-form',
  templateUrl: './registry-form.component.html',
  styleUrls: ['./registry-form.component.scss'],
})
export class RegistryFormComponent extends FormComponent<
  RegistryModel,
  RegistryService
> {
  @ViewChild('administraionsFilterDialog')
  administraionsFilterDialog: IgxDialogComponent;
  @ViewChild('administrationsFilter')
  administrationsFilter: AdministrationsFilterComponent;

  constructor(
    private formBuilder: FormBuilder,
    service: RegistryService,
    private administrationService: AdministrationsService,
    injector: Injector
  ) {
    super(service, injector);
  }

  buildFormImpl(): FormGroup {
    return this.formBuilder.group({
      name: [
        { value: '', disabled: this.isShowForm() },
        [Validators.required, Validators.minLength(5)],
      ],
      id: [{ value: '', disabled: true }],
      code: [{ value: '', disabled: this.isShowForm() }],
      updatedOn: [{ value: '', disabled: true }],
      updatedBy: [{ value: '', disabled: true }],
      createdBy: [{ value: '', disabled: true }],
      administration: this.formBuilder.group({
        displayName: [{ value: '', disabled: true }],
        id: [{ value: '', disabled: true }],
      }),
      description: [{ value: '', disabled: this.isShowForm() }],
    });
  }

  createInputObject(object: RegistryModel): any {
    return new RegistryInModel(object);
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
