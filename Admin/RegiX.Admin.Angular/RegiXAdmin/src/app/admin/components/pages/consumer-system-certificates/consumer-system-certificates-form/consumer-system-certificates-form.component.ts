import { Component, ViewChild, Injector } from '@angular/core';
import { FormComponent } from '@tl/tl-common';
import { ConsumerSystemCertificatesModel } from 'src/app/core/models/dto/consumer-system-certificates.model';
import { ConsumerSystemCertificatesService } from 'src/app/core/services/rest/consumer-system-certificates.service';
import { IgxDialogComponent, IgxTreeGridComponent } from 'igniteui-angular';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { DisplayValue } from 'src/app/core/models/display-value.model';
import { ConsumerSystemCertificatesFilterComponent } from '../../filters/consumer-system-certificates-filter/consumer-system-certificates-filter.component';
import { DatеFormatService } from 'src/app/core/services/date-format.service';
import { ConsumerSystemCertificatesInModel } from 'src/app/core/models/dto/in/consumer-system-certificates.in.model';
import { ConsumerRoleModel } from 'src/app/core/models/dto/consumer-role.model';

@Component({
  selector: 'app-consumer-system-certificates-form',
  templateUrl: './consumer-system-certificates-form.component.html',
  styleUrls: ['./consumer-system-certificates-form.component.scss'],
})
export class ConsumerSystemCertificatesFormComponent extends FormComponent<
  ConsumerSystemCertificatesModel,
  ConsumerSystemCertificatesService
> {
  @ViewChild('consumerSystemCertificatesFilterDialog')
  consumerSystemCertificatesFilterDialog: IgxDialogComponent;
  @ViewChild('consumerSystemCertificatesFilter')
  consumerSystemCertificatesFilter: ConsumerSystemCertificatesFilterComponent;

  @ViewChild('treeGrid', { static: false })
  treeGrid: IgxTreeGridComponent;

  consumerRoles: ConsumerRoleModel[] = [];
  operationElements: any[] = [];
  consumerSystemCertificatesId: number;

  constructor(
    private formBuilder: FormBuilder,
    service: ConsumerSystemCertificatesService,
    injector: Injector,
    public dateFormatService: DatеFormatService
  ) {
    super(service, injector);
  }

  buildFormImpl(): FormGroup {
    return this.formBuilder.group({
      id: [{ value: '', disabled: true }],
      name: [{ value: '', disabled: true }],
      csr: [{ value: '', disabled: true }],
      content: [{ value: '', disabled: this.isShowForm() }],
      requestDate: [{ value: '', disabled: true }],
      environment: [{ value: '', disabled: true }],
      consumerCertificate: this.formBuilder.group({
        displayName: [{ value: '', disabled: this.isShowForm()},[Validators.required]],
        id: [{ value: '', disabled: this.isShowForm() }],
      }),
      consumerSystem: this.formBuilder.group({
        displayName: [{ value: ' ', disabled: true }],
        id: [{ value: '', disabled: true }],
      }),
    });
  }

  createInputObject(object: ConsumerSystemCertificatesModel): any {
    return new ConsumerSystemCertificatesInModel(object); //TODO: add in model if needed
  }

  ngOnInitImplementation() {
    this.isDataLoaded = true;
    this.isDataLoading = false;
  }

  openFile(event) {
    let input = event.target;
    for (var index = 0; index < input.files.length; index++) {
        let reader = new FileReader();
        reader.onload = () => {
            // this 'text' is the content of the file
            var text = reader.result.toString();
            this.formGroup.patchValue({
              content: text,
            });
        }
        reader.readAsText(input.files[index]);
    };
    this.formGroup.markAsTouched();
    this.formGroup.markAsDirty();
}

  protected buildForm() {
    this.formGroup = this.buildFormImpl();
    this.consumerSystemCertificatesId = this.formObject.id;
    if (this.formObject.consumerCertificate == null) {
      this.formObject.consumerCertificate = new DisplayValue();
      this.formObject.consumerCertificate.id = '';
      this.formObject.consumerCertificate.displayName = '';
    }
  }

  protected onBaseServiceLoaded() {
    // do nothing if in edit or create mode, let the additional operations
    // do their work and set the appropriate flags
    if (this.isShowForm()) {
      super.onBaseServiceLoaded();
    }
  }

  downloadCSR() {
    var fileText = this.formObject.csr;
    var fileName = 'CSR.txt';
    this.saveTextAsFile(fileText, fileName);
  }

  showConsumerSystemCertificates() {
    this.consumerSystemCertificatesFilterDialog.open();
    this.consumerSystemCertificatesFilter.loadFirstSection();
  }

  consumerSystemCertificatesSelected(
    selectedItems: { id: number; name: string; data: any; key: string }[]
  ) {
    this.consumerSystemCertificatesFilterDialog.close();
    const cnsDisplayValue = new DisplayValue({
      id: selectedItems[0].id,
      displayName: selectedItems[0].name,
    });
    this.patchConsumerSystemCertificates(cnsDisplayValue);
  }

  private patchConsumerSystemCertificates(admDisplayValue: DisplayValue) {
    this.formGroup.patchValue({
      consumerCertificate: admDisplayValue,
    });
    this.formGroup.markAsDirty();
  }

  private saveTextAsFile(data, filename) {
    if (!data) {
      console.error('Console.save: No data');
      return;
    }

    if (!filename) filename = 'console.json';

    var blob = new Blob([data], { type: 'text/plain' }),
      e = document.createEvent('MouseEvents'),
      a = document.createElement('a');
    // FOR IE:

    if (window.navigator && window.navigator.msSaveOrOpenBlob) {
      window.navigator.msSaveOrOpenBlob(blob, filename);
    } else {
      var e = document.createEvent('MouseEvents'),
        a = document.createElement('a');

      a.download = filename;
      a.href = window.URL.createObjectURL(blob);
      a.dataset.downloadurl = ['text/plain', a.download, a.href].join(':');
      e.initEvent('click', true, false);
      a.dispatchEvent(e);
    }
  }
}
