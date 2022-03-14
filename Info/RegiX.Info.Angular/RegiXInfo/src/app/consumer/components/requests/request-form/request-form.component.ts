import { Component, Injector, ViewChild } from '@angular/core';
import { FormComponent } from '@tl/tl-common';
import { ConsumerRequestsModel } from 'src/app/consumer/models/consumer-requests.model';
import { ConsumerRequestsService } from 'src/app/consumer/services/consumer-requests.service';
import { CONSUMER_ROUTES } from 'src/app/consumer/routes/consumer-static-routes';
import { DisplayValue } from 'src/app/consumer/models/display-value.model';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { IgxDialogComponent } from 'igniteui-angular';
import { ConsumerSystemsFilterComponent } from '../../filters/consumer-systems-filter/consumer-systems-filter.component';
import { ConsumerSystemsService } from 'src/app/consumer/services/consumer-systems.service';
import { map } from 'rxjs/operators';
import { ConsumerRequestsInModel } from 'src/app/consumer/models/in/consumer-request.in.model';

@Component({
  selector: 'app-request-form',
  templateUrl: './request-form.component.html',
  styleUrls: ['./request-form.component.scss'],
})
export class RequestFormComponent extends FormComponent<
  ConsumerRequestsModel,
  ConsumerRequestsService
> {
  @ViewChild('consumerSystemsFilterDialog')
  consumerSystemsFilterDialog: IgxDialogComponent;
  @ViewChild('consumerSystemsFilter')
  consumerSystemsFilter: ConsumerSystemsFilterComponent;

  public routes = CONSUMER_ROUTES;
  public isSystemAdded: boolean = false;

  constructor(
    private formBuilder: FormBuilder,
    private consumerSystemsService: ConsumerSystemsService,
    service: ConsumerRequestsService,
    injector: Injector
  ) {
    super(service, injector);
  }

  buildFormImpl(): FormGroup {
    return this.formBuilder.group({
      name: [
        { value: '', disabled: this.isShowForm() },
        [Validators.required, Validators.minLength(3)],
      ],
      id: [{ value: '', disabled: true }],
      status: [{ value: '', disabled: true }],
      consumerSystem: this.formBuilder.group(
        {
          displayName: [{ value: '', disabled: true }, [Validators.required]],
          id: [{ value: '', disabled: true }, [Validators.required]],
        },
        { validator: Validators.compose([Validators.required]) }
      ),
    });
  }

  createInputObject(object: ConsumerRequestsModel): any {
    let result = new ConsumerRequestsInModel();
    result.name = object.name;
    result.status = object.status;
    result.consumerSystemId = object.consumerSystem.id;
    return result;
  }

  public isFormValid() {
    return this.formGroup.dirty && this.formGroup.valid && this.isSystemAdded;
  }

  protected prepareForCreate() {
    this.buildForm();
    this.operationName = 'Създаване на';
    this.formGroup.reset();
    this.formGroup.controls['status'].setValue(0);
  }

  ngOnInitImplementation() {
    this.isDataLoaded = true;
    this.isDataLoading = false;
    this.AddSystemIfPresent();
  }

  protected onBaseServiceLoaded() {
    // do nothing if in edit or create mode, let the additional operations
    // do their work and set the appropriate flags
    if (this.isShowForm()) {
      super.onBaseServiceLoaded();
    }
  }

  showConsumerSystems() {
    this.consumerSystemsFilterDialog.open();
    this.consumerSystemsFilter.loadFirstSection();
  }

  consumerSystemsSelected(
    selectedItems: { id: number; name: string; data: any; key: string }[]
  ) {
    this.consumerSystemsFilterDialog.close();
    // this.isFormGroupAdministrationsActive = false;
    const value = new DisplayValue({
      id: selectedItems[0].id,
      displayName: selectedItems[0].name,
    });
    this.patchConsumerSystems(value);
  }

  private patchConsumerSystems(value: DisplayValue) {
    this.isSystemAdded = true;
    this.formGroup.patchValue({
      consumerSystem: value,
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
