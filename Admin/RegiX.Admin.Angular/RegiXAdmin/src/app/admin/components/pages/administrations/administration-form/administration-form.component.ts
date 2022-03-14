import { Component, Injector } from '@angular/core';
import { FormComponent } from '@tl/tl-common';
import { AdministrationModel } from 'src/app/core/models/dto/administration.model';
import { AdministrationsService } from 'src/app/core/services/rest/administration.service';
import { FormGroup, FormBuilder, Validators } from '@angular/forms';
import { map } from 'rxjs/operators';
import { DisplayValue } from 'src/app/core/models/display-value.model';
import { AdministrationInModel } from 'src/app/core/models/dto/in/administration.in.model';
import { AdministrationTypeService } from 'src/app/core/services/rest/administration-type.service';
import { AdministrationTypeModel } from 'src/app/core/models/dto/administration-type.model';

@Component({
  selector: 'app-administration-form',
  templateUrl: './administration-form.component.html',
  styleUrls: ['./administration-form.component.scss']
})
export class AdministrationFormComponent extends FormComponent<
  AdministrationModel,
  AdministrationsService
> {
  administrations: DisplayValue[] = [];
  administrationTypes: DisplayValue[] = [];

  constructor(
    private formBuilder: FormBuilder,
    service: AdministrationsService,
    private typesService: AdministrationTypeService,
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
      code: [{ value: '', disabled: this.isShowForm() }, [Validators.required]],
      acronym: [{ value: '', disabled: this.isShowForm() }],
      updatedOn: [{ value: '', disabled: true }],
      updatedBy: [{ value: '', disabled: true }],
      createdBy: [{ value: '', disabled: true }],
      administrationTypeName: [{ value: '', disabled: this.isShowForm() }],
      administrationType: [{ value: '', disabled: this.isShowForm() }],
      parentAuthorityName: [{ value: '', disabled: this.isShowForm() }],
      parentAuthority: [{ value: '', disabled: this.isShowForm() }],
      description: [{ value: '', disabled: this.isShowForm() }]
    });
  }

  createInputObject(object: AdministrationModel): any {
    return new AdministrationInModel(object);
  }

  ngOnInitImplementation() {
    if (!this.isShowForm()) {
      this.readAdministrationTypes();
    }
  }

  protected onBaseServiceLoaded() {
    // do nothing if in edit or create mode, let the additional operations
    // do their work and set the appropriate flags
    if (this.isShowForm()) {
      super.onBaseServiceLoaded();
    }
  }

  private readAdministrationTypes() {
    // Administration types
    this.typesService
      .getAllNoWrap()
      .pipe(
        map((items: AdministrationTypeModel[]) => {
          return items.map(item => {
            return new DisplayValue({ id: item.id, displayName: item.name });
          });
        })
      )
      .subscribe(
        data => {
          this.administrationTypes = data;
          this.isDataLoaded = true;
          this.isDataLoading = false;
        },
        error => {
          this.isDataLoaded = false;
          this.isDataLoading = false;
          this.errorMessage =
            'Грешка при извличане на данни за типове администрации.';
        }
      );
  }

  onCancel() {
    super.onCancel();
  }
}
