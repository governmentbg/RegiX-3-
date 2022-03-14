import { CertificateConsumerRoleModel } from './../../../../../core/models/dto/certificate-consumer-role.model';
import { Component, Injector, ViewChild } from '@angular/core';
import { ConsumerCertificateModel } from 'src/app/core/models/dto/consumer-certificate.model';
import { ConsumerCertificatesService } from 'src/app/core/services/rest/consumer-certificates.service';
import { FormComponent, EActions } from '@tl/tl-common';
import { ConsumersService } from 'src/app/core/services/rest/consumers.service';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { ConsumerModel } from 'src/app/core/models/dto/consumer.model';
import { ConsumerCertificateInModel } from 'src/app/core/models/dto/in/consumer-certificate.in.model';
import { ConsumerRoleModel } from 'src/app/core/models/dto/consumer-role.model';
import { ConsumerRoleService } from 'src/app/core/services/rest/consumer-role.service';
import { IgxTreeGridComponent, IgxDialogComponent, IRowSelectionEventArgs, IgxGridCellComponent } from 'igniteui-angular';
import { OidcSecurityService } from 'angular-auth-oidc-client';
import { CertificateConsumerRoleService } from 'src/app/core/services/rest/certificate-consumer-role.service';
import { HttpParams } from '@angular/common/http';
import { map } from 'rxjs/operators';
import { onTreeRowClickChange } from '../access-edit-form/access-edit-form.component';
import { ConsumerFilterComponent } from '../../filters/consumer-filter/consumer-filter.component';
import { DisplayValue } from 'src/app/core/models/display-value.model';

@Component({
  selector: 'app-certificate-form',
  templateUrl: './certificate-form.component.html',
  styleUrls: ['./certificate-form.component.scss'],
})
export class CertificateFormComponent extends FormComponent<
  ConsumerCertificateModel,
  ConsumerCertificatesService
> {
  @ViewChild('consumerFilterDialog')
  consumerFilterDialog: IgxDialogComponent;
  @ViewChild('consumerFilter')
  consumerFilter: ConsumerFilterComponent;

  @ViewChild('treeGrid', { static: true })
  treeGrid: IgxTreeGridComponent;
  @ViewChild('dialog', { read: IgxDialogComponent, static: true })
  public dialog: IgxDialogComponent;

  consumers: ConsumerModel[] = [];
  consumerRoles: ConsumerRoleModel[] = [];
  operationElements: any[] = [];

  constructor(
    private formBuilder: FormBuilder,
    service: ConsumerCertificatesService,
    private consumerService: ConsumersService,
    private consumerRoleService: ConsumerRoleService, //roles
    injector: Injector,
    private oidcSecurityService: OidcSecurityService,
    private certificateConsumerRoleService: CertificateConsumerRoleService
  ) {
    super(service, injector);
  }

  buildFormImpl(): FormGroup {

    if (this.isShowForm()) {
      return this.formBuilder.group({
        name: [
          { value: '', disabled: this.isShowForm() },
          [Validators.required, Validators.minLength(5)],
        ],
        id: [{ value: '', disabled: true }],
        oid: [{ value: '', disabled: true }],
        updatedOn: [{ value: '', disabled: true }],
        updatedBy: [{ value: '', disabled: true }],
        createdBy: [{ value: '', disabled: true }],
        apiServiceConsumer: this.formBuilder.group({
          id: [{ value: '', disabled: true }],
          displayName: [{ value: '', disabled: true }],
          oid: [{ value: '', disabled: true }],
        }),
        description: [{ value: '', disabled: this.isShowForm() }, [Validators.required]],
        thumbprint: [{ value: '', disabled: this.isShowForm() }],
        content: [{ value: '', disabled: true }, [Validators.required]],
        issuedFrom: [{ value: '', disabled: this.isShowForm() }],
        issuedTo: [{ value: '', disabled: this.isShowForm() }],
        validFrom: [{ value: '', disabled: this.isShowForm() }],
        validTo: [{ value: '', disabled: this.isShowForm() }],
        active: [{ value: '', disabled: this.isShowForm() }]
      });
    } else {
      return this.formBuilder.group({
        name: [
          { value: '', disabled: this.isShowForm() },
          [Validators.required, Validators.minLength(5)],
        ],
        id: [{ value: '', disabled: true }],
        oid: [{ value: '', disabled: false }, [Validators.required]],
        filename: [{ value: '', disabled: true }],
        updatedOn: [{ value: '', disabled: true }],
        updatedBy: [{ value: '', disabled: true }],
        createdBy: [{ value: '', disabled: true }],
        apiServiceConsumer: this.formBuilder.group({
          id: [{ value: '', disabled: true }],
          displayName: [{ value: '', disabled: true }],
          oid: [{ value: '', disabled: true }],
        }),
        description: [{ value: '', disabled: this.isShowForm() }],
        content: [{ value: '', disabled: true }, [Validators.required]],
        active: [{ value: '', disabled: this.isShowForm() }],
      });
    }
  }

  protected prepareForCreate() {
    super.prepareForCreate();
    this.isDataLoading = true;
    this.formGroup.patchValue({
      active: true,
    });
    const conId = this.activatedRoute.snapshot.params['CON_ID'];
    if (conId) {
      this.consumerService.find(conId).subscribe(
        (con) => {
          this.isDataLoading = false;
          this.patchConsumer({
            id: conId,
            displayName: con.name,
            oid: con.oid,
          });
        },
        (error) => {
          this.isDataLoading = false;
        }
      );
    }
  }
  protected prepareEditObject(object: ConsumerCertificateModel): any {
    const obj = Object(object);
    delete obj.issuedFrom;
    delete obj.issuedTo;
    delete obj.validFrom;
    delete obj.validTo;

    delete obj.thumbprint;
    delete obj.apiServiceConsumerName;

    obj.filename = null;

    return obj;
  }

  createInputObject(object: ConsumerCertificateModel): any {
    return new ConsumerCertificateInModel(object);
  }

  public isFormValid() {
    return (
      this.formGroup && this.formGroup.dirty && this.formGroup.valid //&&
      // this.treeGrid.selectedRows().length > 0
    );
  }

  ngOnInitImplementation() {
      this.readConsumerRoles();

  }

  private readConsumerRoles() {
    this.isDataLoaded = false;
    this.isDataLoading = true;
    this.consumerRoleService.getAllNoWrap().subscribe(
      (data) => {
        this.consumerRoles = data;
        this.isDataLoaded = true;
        this.isDataLoading = false;
        this.buildConsumerRolesTree(this.consumerRoles);
        this.treeGrid.clearCellSelection();
        this.treeGrid.clearFilter();
        this.treeGrid.clearSearch();
        this.treeGrid.clearSort();
        this.treeGrid.deselectAllRows();
        this.getConsumerRoles();
      },
      () => {
        this.isDataLoaded = false;
        this.isDataLoading = false;
        this.errorMessage = 'Грешка при извличане на данни за консуматори.';
      }
    );
  }

  private getConsumerRoles() {
    if (this.currentAction !== EActions.CREATE) {
      let httpParameters = new HttpParams();
      const filteringParam = 'consumerCertificate.id eq ' + this.objectId;
      httpParameters = httpParameters.append('$filter', filteringParam);

      this.certificateConsumerRoleService
        .getAllNoWrap(httpParameters)
        .pipe(
          map((items: CertificateConsumerRoleModel[]) => {
            return items.map((item) => {
               console.log(this.operationElements);
               const foundItem = this.operationElements.find( oe => oe.id === item.consumerRole.id);
               if (foundItem) {
                  foundItem.comment =  item.editAccessComment;
               }
               return item.consumerRole.id;
            });
          })
        )
        .subscribe((data) => {
          this.treeGrid.selectRows(data, true);
        });
    }
  }

  private buildConsumerRolesTree(data: ConsumerRoleModel[]) {
    const objects: any[] = [];
    data.forEach((element) => {
      const object = Object(element);
      object.primaryKey = element.id;
      object.comment = '';
      object.foreignKey = -1;
      objects.push(object);
    });
    this.operationElements = objects;
  }

  onCommentError() {
    this.dialog.close();
  }

  checkComments(): boolean {
    const rows = this.treeGrid.selectedRows();
    let hasComment = true;
    rows.map(
      el => {
        const comment = this.operationElements.find( e => e.id === el).comment;
        hasComment = hasComment && (comment !== '');
      }
    );
    if (!hasComment) {
      this.dialog.open();

    }
    return hasComment;
  }

  createObject() {
    this.validateForm();
    if (this.formGroup.valid && this.formGroup.dirty && this.checkComments()) {
      this.isPending = true;
      const formData = this.formGroup.getRawValue();
      const inputObject = this.createInputObject(formData);
      const rows = this.treeGrid.selectedRows();
      inputObject.consumerRoleIds =
        rows.map(
          el => {
            const comment = this.operationElements.find( e => e.id === el).comment;
            return new DisplayValue({
                id: el,
                displayName: comment
              }
            );
          }
        );
      this.service.save(inputObject).subscribe(
        (data) => {
          // this.createRowInUI(data);
          this.logger.debug('object inserted, refresh form or redirect', data);
          this.formGroup.markAsPristine();
          this.formGroup.markAsUntouched();
          this.errorMessage = null;
          this.toastService.showMessage('Обектът е създаден успешно!');
          this.locationService.back();
          this.isPending = false;
        },
        (error) => {
          this.errorMessage = 'Грешка при създаване на обект: ' + error.error;
          this.isPending = false;
        }
      );
    }
  }

  protected updateObject() {
    this.validateForm();
    if (this.formGroup.valid && this.formGroup.dirty && this.checkComments()) {
      this.isPending = true;
      const formData = this.formGroup.getRawValue();
      this.logger.debug('formData', formData, this.formGroup.value);
      const inputObject = this.createInputObject(formData);
      const rows = this.treeGrid.selectedRows();
      inputObject.consumerRoleIds =
        rows.map(
          el => {
            const comment = this.operationElements.find( e => e.id === el).comment;
            return new DisplayValue({
                id: el,
                displayName: comment
              }
            );
          }
        );

      this.logger.debug('inputObject', inputObject);
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

  /**
   * Opens file chooser dialog
   */
  openFileChooserDialog() {
    const btn = document.getElementById(
      'fileChooserInput'
    ) as HTMLButtonElement;
    btn.click();
  }

  onFileSelectionChange() {
    const input = <HTMLInputElement>document.getElementById('fileChooserInput');
    // this.pickFiles(input.files);
    const numFiles = input.files ? input.files.length : 1;
    if (numFiles === 1) {
      this.pickFile(input.files);
    }
  }

  private pickFile(fileList: FileList) {
    const file = fileList[0];
    const extension = file.name.substring(file.name.lastIndexOf('.') + 1);
    if (extension.toUpperCase() === 'CER') {
      this.getBase64(file).then((data) => {
        const fileName = file.name;
        this.formGroup.get('content').patchValue(data);
        this.formGroup.get('filename').patchValue(fileName);
      });
    }
  }

  /**
   * Reads and converts file in Base64
   * @param file file to convert to Base64
   */
  private getBase64(file) {
    return new Promise((resolve, reject) => {
      const reader = new FileReader();
      reader.readAsDataURL(file);
      reader.onload = () => {
        // remove leading string
        const readerResult = '' + reader.result;
        const result = readerResult.substring(readerResult.indexOf(',') + 1);
        resolve(result);
      };
      reader.onerror = (error) => reject(error);
    });
  }

  onCancel() {
    super.onCancel();
  }

  onClearOID() {
    this.formGroup.controls['oid'].setValue(null);
  }

  onFillOID() {
    if (this.formGroup.controls['apiServiceConsumer'].value) {
      const oid = this.formGroup.controls['apiServiceConsumer'].value.oid;
      this.formGroup.controls['oid'].setValue(oid);
    }
  }

  resetForm() {
    this.treeGrid.deselectAllRows();
    this.formGroup.markAsPristine();
    this.formGroup.markAsUntouched();
    this.errorMessage = null;
  }

  onConsumerSelectionChanged($event) {
    // clear OID
    // this.formGroup.controls['oid'].setValue(null);
  }
  showConsumers() {
    this.consumerFilterDialog.open();
    this.consumerFilter.loadFirstSection();
  }

  consumerSelected(
    selectedItems: { id: number; name: string; data: any; key: string }[]
  ) {
    this.consumerFilterDialog.close();
    const conDisplayValue = {
      id: selectedItems[1].id,
      displayName: selectedItems[1].name,
      oid: selectedItems[1].data,
    };
    this.patchConsumer(conDisplayValue);
  }

  private patchConsumer(conDisplayValue: {
    id: number;
    displayName: string;
    oid: string;
  }) {
    this.formGroup.patchValue({
      apiServiceConsumer: conDisplayValue,
    });
    this.formGroup.markAsDirty();
  }

  onRowClickChange(e: IRowSelectionEventArgs) {
    e.cancel = true;
    if (!this.isShowForm() &&
        e.event.target['tagName'] !== 'IGX-TREE-GRID-CELL' &&
        e.event.target['tagName'] !== 'IGX-GRID-CELL' &&
        e.event.target['tagName'] !== 'INPUT' &&
        e.event.target['tagName'] !== 'IGX-INPUT-GROUP' &&
        e.event.target['tagName'] !== 'IGX-DISPLAY-CONTAINER') {
          console.log(e.event.target['tagName']);
      // Only change checked status on check box click
      // Gives the ability to save the form only by editing Roles table
      this.formGroup.markAsDirty();
      onTreeRowClickChange(this.operationElements, e, this.treeGrid);
    }
  }
}
