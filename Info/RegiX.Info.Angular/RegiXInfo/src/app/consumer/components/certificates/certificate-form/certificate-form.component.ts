import { ConsumerSystemsService } from './../../../services/consumer-systems.service';
import { EEnvironmentType } from './../../../enums/environment-type.enum';
import { Component, Injector, ViewChild } from '@angular/core';
import { FormComponent } from '@tl/tl-common';
import { CertificateModel } from 'src/app/consumer/models/certificate.model';
import { CertificateService } from 'src/app/consumer/services/certificate.service';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { IgxDialogComponent } from 'igniteui-angular';
import { ConsumerSystemsFilterComponent } from '../../filters/consumer-systems-filter/consumer-systems-filter.component';
import { DisplayValue } from 'src/app/consumer/models/display-value.model';
import { map } from 'rxjs/operators';

@Component({
  selector: 'app-certificate-form',
  templateUrl: './certificate-form.component.html',
  styleUrls: ['./certificate-form.component.scss'],
})
export class CertificateFormComponent extends FormComponent<
  CertificateModel,
  CertificateService
> {
  @ViewChild('consumerSystemsFilterDialog')
  consumerSystemsFilterDialog: IgxDialogComponent;
  @ViewChild('consumerSystemsFilter')
  consumerSystemsFilter: ConsumerSystemsFilterComponent;

  enviromentTypes: {  name: string }[] = [];
  selectedEnviroment: string;

  constructor(
    private formBuilder: FormBuilder,
    private consumerSystemsService: ConsumerSystemsService,
    service: CertificateService,
    injector: Injector
  ) {
    super(service, injector);
    this.enviromentTypes.push(
      {name: EEnvironmentType.PRODUCTION},
      {name: EEnvironmentType.TEST},
    )
  }

  ngOnInitImplementation() {
    this.isDataLoaded = true;
    this.isDataLoading = false;
    this.AddSystemIfPresent();
  }

  buildFormImpl(): FormGroup {
    return this.formBuilder.group({
      id: [{ value: '', disabled: true }],
      name: [
        { value: '', disabled: this.isShowForm() },
        [Validators.required, Validators.minLength(5)],
      ],
      csr: [{ value: '', disabled: this.isShowForm() }, [Validators.required]],
      environment: [{ value: '', disabled: this.isShowForm() }, [Validators.required]],
      content: [{ value: '', disabled: this.isShowForm() }],
      consumerSystem: this.formBuilder.group({
        displayName: [{ value: '', disabled: true }],
        id: [{ value: '', disabled: true }],
      })
    });
  }

  createInputObject(object: CertificateModel): any {
    let result = new CertificateModel(object);
    return result;
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
    this.selectedEnviroment = this.formObject.environment.toUpperCase();
  }

  showConsumerSystems() {
    this.consumerSystemsFilterDialog.open();
    this.consumerSystemsFilter.loadFirstSection();
  }

  consumerSystemsSelected(
    selectedItems: { id: number; name: string; data: any; key: string }[]
  ) {
    this.consumerSystemsFilterDialog.close();
    const admDisplayValue = new DisplayValue({
      id: selectedItems[0].id,
      displayName: selectedItems[0].name,
    });
    this.patchConsumerSystems(admDisplayValue);
  }

  private patchConsumerSystems(admDisplayValue: DisplayValue) {
    this.formGroup.patchValue({
      consumerSystem: admDisplayValue,
    });
    this.formGroup.markAsDirty();
  }

  private AddSystemIfPresent() {
    let param = this.activatedRoute.snapshot.params['SYS_ID'];
    if (!isNaN(param)) {
      this.getConsumerSystemById(+param);
    }
  }

  private getConsumerSystemById(param: number) {
     this.consumerSystemsService.find(param).pipe(
      map(item => {
        return {
          id: item.id,
          name: item.name,
          data: undefined,
          key:undefined
           };
        })
      ).subscribe(
        item => {
          let  selectedItems: { id: number; name: string; data: any; key: string }[] =[item];
          this.consumerSystemsSelected(selectedItems);
        }
      );
  
  }
}
