import { Component, OnInit, Injector } from '@angular/core';
import { CertificateOperationModel } from 'src/app/core/models/dto/certificate-operation.model';
import { CertificateOperationsService } from 'src/app/core/services/rest/certificate-operations.service';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { FormComponent } from '@tl/tl-common';

@Component({
  selector: 'app-certificate-operation-form',
  templateUrl: './certificate-operation-form.component.html',
  styleUrls: ['./certificate-operation-form.component.scss']
})
export class CertificateOperationFormComponent extends FormComponent<
  CertificateOperationModel,
  CertificateOperationsService
> {

  constructor(
    private formBuilder: FormBuilder,
    service: CertificateOperationsService,
    injector: Injector
  ) {
    super(service, injector);
  }

  buildFormImpl(): FormGroup {
    return this.formBuilder.group({
      id: [{ value: '', disabled: true }],
      updatedOn: [{ value: '', disabled: true }],
      updatedBy: [{ value: '', disabled: true }],
      createdBy: [{ value: '', disabled: true }],
      adapterOperation: [{ value: '', disabled: this.isShowForm() }],
      adapterOperationName: [{ value: '', disabled: this.isShowForm() }],
      adapterOperationDescription: [{ value: '', disabled: this.isShowForm() }],
      consumerCertificate: [{ value: '', disabled: this.isShowForm() }],
      consumerCertificateName: [{ value: '', disabled: this.isShowForm() }],
      consumerCertificateDescription: [{ value: '', disabled: this.isShowForm() }],
      editComment: [{ value: '', disabled: true }],
      hasAccess: [{ value: '', disabled: this.isShowForm() }],
      registerObjectId: [{value: '', disabled: true}]
    });
  }

  createInputObject(object: CertificateOperationModel): any {
    return new CertificateOperationModel(object);
  }

  ngOnInitImplementation() {
  }

  onCancel() {
    super.onCancel();
  }
}
