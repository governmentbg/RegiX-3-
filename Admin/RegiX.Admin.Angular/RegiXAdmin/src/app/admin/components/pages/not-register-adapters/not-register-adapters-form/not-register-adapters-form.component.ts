import { Component, Injector, ViewChild } from '@angular/core';
import { NotRegisterAdapterDataService } from 'src/app/core/services/rest/not-register-adapter-data.service';
import { NotRegisterAdapterInfoModel } from 'src/app/core/models/dto/not-register-adapter-form-models/not-register-adapter-info.model';
import { FormComponent } from '@tl/tl-common';
import { FormGroup, FormBuilder } from '@angular/forms';
import { NotRegisterAdapterDataModel } from 'src/app/core/models/dto/not-register-adapter-form-models/not-register-adapter-data.model';
import { ApiOperationsWithAdapterNameModel } from 'src/app/core/models/dto/not-register-adapter-form-models/api-operations-with-adapter-name.model';
import { RegistryService } from 'src/app/core/services/rest/registry.service';
import { DisplayValue } from 'src/app/core/models/display-value.model';
import { RegistryModel } from 'src/app/core/models/dto/registy.model';
import { map } from 'rxjs/operators';
import { IgxDialogComponent } from 'igniteui-angular';
import { AdministrationsFilterComponent } from '../../filters/administrations-filter/administrations-filter.component';
import { ROUTES } from 'src/app/admin/routes/static-routes';

@Component({
  selector: 'app-not-register-adapters-form',
  templateUrl: './not-register-adapters-form.component.html',
  styleUrls: ['./not-register-adapters-form.component.scss'],
})
export class NotRegisterAdaptersFormComponent extends FormComponent<
  NotRegisterAdapterDataModel,
  NotRegisterAdapterDataService
> {
  @ViewChild('registersFilterDialog')
  registersFilterDialog: IgxDialogComponent;
  @ViewChild('registersFilter')
  registersFilter: AdministrationsFilterComponent;

  title: string;
  registerIcon = ROUTES.REGISTRIES.icon;

  public objectName = 'нерегистриран адаптер';
  public adapterOparationsTitle = 'Адаптер операции';
  public registerObjectsTitle = 'Регистрирани обекти';
  public apiOperationsTitle = 'API операции';

  public apiOperationsWithAdapterName: ApiOperationsWithAdapterNameModel[] = [];
  public registries: DisplayValue[] = [];

  @ViewChild('grid')
  public grid: any;

  constructor(
    private formBuilder: FormBuilder,
    service: NotRegisterAdapterDataService,
    private registryService: RegistryService,
    injector: Injector
  ) {
    super(service, injector);
  }

  buildFormImpl(): FormGroup {
    return this.formBuilder.group({
      id: [{ value: '', disabled: true }],
      name: [{ value: '', disabled: true }],
      description: [{ value: '', disabled: true }],
      contract: [{ value: '', disabled: true }],
      adapterUrl: [{ value: '', disabled: this.isShowForm() }],
      assembly: [{ value: '', disabled: true }],
      bindingConfigName: [{ value: '', disabled: this.isShowForm() }],
      bindingType: [{ value: '', disabled: this.isShowForm() }],
      register: [{ value: '', disabled: true }],
      registerDisplay: [{ value: '', disabled: true }],
      registerObjects: [{ value: '', disabled: true }],
      adapterOperations: [{ value: '', disabled: true }],
    });
  }
  createInputObject(object: NotRegisterAdapterDataModel) {
    return new NotRegisterAdapterDataModel(object);
  }

  ngOnInitImplementation() {
    this.isDataLoaded = true;
    this.isDataLoading = false;
  }

  afterObjectReady() {
    this.prepareApiOperationsModel();
  }

  prepareShowObject(object: NotRegisterAdapterDataModel): any {
    return new NotRegisterAdapterInfoModel(object.notRegisterAdapterInfo);
  }
  prepareEditObject(object: NotRegisterAdapterDataModel): any {
    return new NotRegisterAdapterInfoModel(object.notRegisterAdapterInfo);
  }

  protected prepareForEdit(object: NotRegisterAdapterDataModel) {
    super.prepareForEdit(object);
    this.isDataLoading = true;
    const regId = this.activatedRoute.snapshot.params['REG_ID'];
    if (regId) {
      this.registryService.find(regId).subscribe(
        (reg) => {
          this.isDataLoading = false;
          this.patchRegister({
            id: regId,
            displayName: reg.name
          });
        },
        (error) => {
          this.isDataLoading = false;
        }
      );
    }
  }

  updateObject() {
    this.validateForm();
    if (this.formGroup.valid && this.formGroup.dirty) {
      this.isPending = true;
      const formData = this.formObject;
      formData.notRegisterAdapterInfo.adapterUrl = this.formGroup.get(
        'adapterUrl'
      ).value;
      formData.notRegisterAdapterInfo.bindingConfigName = this.formGroup.get(
        'bindingConfigName'
      ).value;
      formData.notRegisterAdapterInfo.bindingType = this.formGroup.get(
        'bindingType'
      ).value;
      //takes the id from DisplayValue
      formData.notRegisterAdapterInfo.register = this.formGroup.get(
        'register'
      ).value;
      const inputObject = this.createInputObject(formData);

      this.service.update(formData.id, inputObject).subscribe(
        (data) => {
          // this.updateRowInUI(data);
          this.logger.debug('object inserted, refresh form or redirect', data);
          this.formGroup.markAsPristine();
          this.formGroup.markAsUntouched();
          this.errorMessage = null;
          this.toastService.showMessage('Обектът е обновен успешно!');
          this.locationService.back();
          this.isPending = false;
        },
        (error) => {
          this.logger.debug('error', error);
          this.isPending = false;
          this.errorMessage = 'Грешка при обновяване на обект: ' + error.error;
        }
      );
    }
  }

  pagerChange(event) {
    this.grid.perPage = event.perPage;
    this.grid.page = event.page;
  }

  //filling data for API operations gird
  private prepareApiOperationsModel() {
    this.apiOperationsWithAdapterName = this.formObject.notRegisterApiService.apiServiceOperations.map(
      (x) => {
        return new ApiOperationsWithAdapterNameModel({
          code: x.code,
          description: x.description,
          name: x.name,
          adapterFullName: this.formObject.notRegisterApiServiceAdapterOperations.filter(
            (y) =>
              y.adapterFullName.substring(
                y.adapterFullName.lastIndexOf('.') + 1
              ) == x.name
          )[0].adapterFullName,
        });
      }
    );
  }

  showRegisters() {
    this.registersFilterDialog.open();
    this.registersFilter.loadFirstSection();
  }

  registerSelected(
    selectedItems: { id: number; name: string; data: any; key: string }[]
  ) {
    this.registersFilterDialog.close();
    const regDisplayValue = new DisplayValue({
      id: selectedItems[1].id,
      displayName: selectedItems[1].name,
    });
    this.patchRegister(regDisplayValue);
  }

  private patchRegister(regValue: DisplayValue) {
    this.formGroup.patchValue({
      register: regValue.id,
      registerDisplay: regValue.displayName,
    });
    this.formGroup.markAsDirty();
  }
}
