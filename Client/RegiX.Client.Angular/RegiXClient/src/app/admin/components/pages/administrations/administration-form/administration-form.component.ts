import { StoreNameEnum } from './../../../../enums/store-name.enum';
import { Component, Injector } from '@angular/core';
import { FormComponent } from '@tl/tl-common';
import { AdministrationModel } from 'src/app/core/models/dto/administration.model';
import { AdministrationsService } from 'src/app/core/services/rest/administration.service';
import { FormGroup, FormBuilder, Validators } from '@angular/forms';
import { DisplayValue } from 'src/app/core/models/display-value.model';
import { AdministrationInModel } from 'src/app/core/models/dto/in/administration.in.model';
import { ROUTES } from 'src/app/admin/routes/static-routes';

@Component({
  selector: 'app-administration-form',
  templateUrl: './administration-form.component.html',
  styleUrls: ['./administration-form.component.scss'],
})
export class AdministrationFormComponent extends FormComponent<
  AdministrationModel,
  AdministrationsService
> {
  administrations: DisplayValue[] = [];
  administrationIcon = ROUTES.ADMINISTRATIONS.icon;
  public storeNameEnums: { id: number; name: string }[] = [];

  selectedStoreNameEnum: string;

  constructor(
    private formBuilder: FormBuilder,
    service: AdministrationsService,
    injector: Injector
  ) {
    super(service, injector);
    this.storeNameEnums.push(
      { id: 1, name: StoreNameEnum.AddressBook },
      { id: 2, name: StoreNameEnum.AuthRoot },
      { id: 3, name: StoreNameEnum.CertificateAuthority },
      { id: 4, name: StoreNameEnum.Disallowed },
      { id: 5, name: StoreNameEnum.My },
      { id: 6, name: StoreNameEnum.Root },
      { id: 7, name: StoreNameEnum.TrustedPeople },
      { id: 8, name: StoreNameEnum.TrustedPublisher }
    );
  }

  buildFormImpl(): FormGroup {
    return this.formBuilder.group({
      name: [
        { value: '', disabled: this.isShowForm() },
        [Validators.required, Validators.minLength(5)],
      ],
      displayName: [
        { value: '', disabled: this.isShowForm() },
        [Validators.required, Validators.minLength(5)],
      ],
      id: [{ value: '', disabled: true }],
      code: [{ value: '', disabled: this.isShowForm() }, [Validators.required]],
      acronym: [
        { value: '', disabled: this.isShowForm() },
        [Validators.required],
      ],
      modifiedBy: [{ value: '', disabled: true }],
      modifiedOn: [{ value: '', disabled: true }],
      createdBy: [{ value: '', disabled: true }],
      oid: [{ value: '', disabled: this.isShowForm() }],
      certificateThumbprint: [{ value: '', disabled: this.isShowForm() }],
      certificateStore: [{ value: '', disabled: this.isShowForm() }],
      parentAuthorityName: [{ value: '', disabled: this.isShowForm() }],
      parentAuthority: [{ value: '', disabled: this.isShowForm() }],
      isMultitenantAuthority: [{ value: '', disabled: this.isShowForm() }],
    });
  }

  createInputObject(object: AdministrationModel): any {
    this.SetCertificateStoreId(object);
    return new AdministrationInModel(object);
  }

  ngOnInitImplementation() {
    this.isDataLoaded = true;
    this.isDataLoading = false;
  }

  protected onBaseServiceLoaded() {
    // do nothing if in edit or create mode, let the additional operations
    // do their work and set the appropriate flags
    if (this.isShowForm()) {
      super.onBaseServiceLoaded();
    }
  }

  protected afterObjectReady() {
    //setting value for ngModel
    if (this.formObject.certificateStore) {
      this.selectedStoreNameEnum = this.storeNameEnums[
        this.formObject.certificateStore - 1
      ].name;
    }
  }

  onCancel() {
    super.onCancel();
  }

  private SetCertificateStoreId(object: AdministrationModel) {
    if (object.certificateStore){
      let certificateStoreString = object.certificateStore.toString();
      this.storeNameEnums.forEach((element) => {
        if (element.name === certificateStoreString) {
          object.certificateStore = element.id;
        }
      });
    }
  }
}
