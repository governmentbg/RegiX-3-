import { Component, OnInit, Injector } from '@angular/core';
import { ApiServiceModel } from 'src/app/core/models/dto/api-service.model';
import { ApiServiceService } from 'src/app/core/services/rest/api-service.service';
import { FormComponent } from '@tl/tl-common';
import { DisplayValue } from 'src/app/core/models/display-value.model';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { ApiServiceInModel } from 'src/app/core/models/dto/in/api-service.in.model';
import { AdministrationsService } from 'src/app/core/services/rest/administration.service';
import { AdministrationModel } from 'src/app/core/models/dto/administration.model';
import { map } from 'rxjs/operators';

@Component({
  selector: 'app-interface-form',
  templateUrl: './interface-form.component.html',
  styleUrls: ['./interface-form.component.scss']
})
export class InterfaceFormComponent extends FormComponent<
  ApiServiceModel,
  ApiServiceService
> {
  administrations: DisplayValue[] = [];

  constructor(
    private formBuilder: FormBuilder,
    service: ApiServiceService,
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
      code: [{ value: '', disabled: true }],
      updatedOn: [{ value: '', disabled: true }],
      updatedBy: [{ value: '', disabled: true }],
      createdBy: [{ value: '', disabled: true }],
      serviceUrl: [{ value: '', disabled: this.isShowForm() }],
      contract: [{ value: '', disabled: true }],
      isComplex: [{ value: '', disabled: true }],
      assembly: [{ value: '', disabled: true }],
      enabled: [{ value: '', disabled: this.isShowForm() }],
      controlerName: [{ value: '', disabled: true }],
      description: [{ value: '', disabled: this.isShowForm() }],
      administration: [{ value: '', disabled: true }],
      administrationName: [{ value: '', disabled: true }],
    });
  }

  createInputObject(object: ApiServiceModel): any {
    return new ApiServiceInModel(object);
  }

  ngOnInitImplementation() {
    if (!this.isShowForm()) {
      this.readAdministrations();
    }
  }

  private readAdministrations() {
    this.isDataLoaded = false;
    this.isDataLoading = true;
    this.administrationService
      .getAllNoWrap()
      .pipe(
        map((items: AdministrationModel[]) => {
          return items.map(item => {
            return new DisplayValue({ id: item.id, displayName: item.name });
          });
        })
      )
      .subscribe(
        data => {
          this.administrations = data;
          this.isDataLoaded = true;
          this.isDataLoading = false;
        },
        error => {
          this.isDataLoaded = false;
          this.isDataLoading = false;
          this.errorMessage = 'Грешка при извличане на данни за администрации.';
        }
      );
  }

  protected onBaseServiceLoaded() {
    // do nothing if in edit or create mode, let the additional operations
    // do their work and set the appropriate flags
    if (this.isShowForm()) {
      super.onBaseServiceLoaded();
    }
  }

  onCancel() {
    super.onCancel();
  }
}
