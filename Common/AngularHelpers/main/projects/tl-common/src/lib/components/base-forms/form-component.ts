import { OnInit, Injector, OnDestroy } from '@angular/core';
import { FormGroup } from '@angular/forms';
import { Router, ActivatedRoute } from '@angular/router';
import { IgxSelectComponent } from 'igniteui-angular';
import { Location } from '@angular/common';
import { CrudService } from '../../services/crud.service';
import { EActions } from '../../enums/actions.enum';
import { ToastService } from '../../services/toast.service';
import { ABaseModel } from '../../models/base.model';
import { NGXLogger } from 'ngx-logger';

export abstract class FormComponent<
  T extends ABaseModel,
  CS extends CrudService<T, any>
> implements OnInit, OnDestroy {
  formGroup: FormGroup;
  formObject: T;
  objectId: any = null;

  isDataLoading = false;
  isDataLoaded = false;

  isPending = false;

  currentAction: EActions;

  operationName: string;
  objectName: string;
  name: string;
  icon: string;

  errorMessage: string = null;

  protected router: Router;
  protected activatedRoute: ActivatedRoute;
  protected toastService: ToastService;
  protected locationService: Location;
  protected logger: NGXLogger;

  constructor(public service: CS, protected injector: Injector) {
    this.router = this.injector.get<Router>(Router as any);
    this.locationService = this.injector.get<Location>(Location as any);
    this.activatedRoute = this.injector.get<ActivatedRoute>(
      ActivatedRoute as any
    );
    this.toastService = this.injector.get<ToastService>(ToastService as any);
    this.logger = this.injector.get<NGXLogger>(NGXLogger);
  }

  ngOnInit() {
    this.objectName = this.activatedRoute.snapshot.data.objectName;
    this.name = this.activatedRoute.snapshot.data.name;
    this.icon = this.activatedRoute.snapshot.data.icon;
    
    this.activatedRoute.params.subscribe((params) => {
      this.objectId = params['ID'];
      if (!this.objectId) {
        this.currentAction = EActions.CREATE;
        this.prepareForm();
      } else {
        const editParam = this.activatedRoute.snapshot.data['edit'];
        if (editParam === true) {
          this.currentAction = EActions.EDIT;
        } else if (editParam === false) {
          this.currentAction = EActions.SHOW;
        }
        this.readObjectDetails();
      }
    });

    this.ngOnInitImplementation();
  }

  ngOnDestroy() {}

  protected readObjectDetails() {
    this.isDataLoading = true;
    this.service.find(this.objectId).subscribe(
      (data) => {
        this.formObject = data;
        this.onBaseServiceLoaded();
        this.prepareForm();
        this.afterObjectReady();
      },
      (error) => {
        this.onBaseServiceError();
      }
    );
  }

  protected onBaseServiceLoaded() {
    this.isDataLoading = false;
    this.isDataLoaded = true;
    this.errorMessage = null;
  }

  protected onBaseServiceError() {
    this.isDataLoading = false;
    this.isDataLoaded = false;
    this.errorMessage = 'Грешка при извличане на данни за обект!';
    this.toastService.showMessage('Грешка при извличане на данни за обект!');
    this.locationService.back();
  }

  protected afterObjectReady() {}

  abstract ngOnInitImplementation();

  abstract buildFormImpl(): FormGroup;

  protected buildForm() {
    this.formGroup = this.buildFormImpl();
  }

  resetForm() {
    this.formGroup.markAsPristine();
    this.formGroup.markAsUntouched();
    this.errorMessage = null;
    this.formGroup.reset();
  }

  onSubmit(event) {
    if (!event) {
      event = this.currentAction;
    }
    if (EActions.CREATE === event) {
      this.createObject();
    } else if (EActions.EDIT === event) {
      this.updateObject();
    } else if (EActions.RESET === event) {
      this.resetForm();
    }
  }

  createObject() {
    this.validateForm();
    if (this.formGroup.valid && this.formGroup.dirty) {
      this.isPending = true;
      const formData = this.formGroup.getRawValue();
      const inputObject = this.createInputObject(formData);
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
    if (this.formGroup.valid && this.formGroup.dirty) {
      this.isPending = true;
      const formData = this.formGroup.getRawValue();
      this.logger.debug('formData', formData, this.formGroup.value);
      const inputObject = this.createInputObject(formData);
      this.logger.debug('inputObject', inputObject);

      this.service.update(formData.id, inputObject).subscribe(
        (data) => {
          // this.updateRowInUI(data);
          this.logger.debug('object updated, refresh form or redirect', data);
          this.formGroup.markAsPristine();
          this.formGroup.markAsUntouched();
          this.errorMessage = null;
          this.toastService.showMessage('Обектът е обновен успешно!');
          this.locationService.back();
          this.isPending = false;
        },
        (error) => {
          this.logger.error(error);
          this.isPending = false;
          this.errorMessage = 'Грешка при обновяване на обект: ' + error.error;
        }
      );
    }
  }

  abstract createInputObject(object: T);

  prepareForm() {
    switch (this.currentAction) {
      case EActions.SHOW: {
        this.prepareForShow(this.formObject);
        break;
      }
      case EActions.CREATE: {
        this.prepareForCreate();
        break;
      }
      case EActions.EDIT: {
        this.prepareForEdit(this.formObject);
        break;
      }
    }
  }

  protected prepareForEdit(object: T) {
    this.buildForm();
    const theObject = this.prepareEditObject(object);
    this.operationName = 'Редакция на';
    this.formGroup.setValue(theObject);
    this.logger.debug('prepareForEdit', this.formGroup.getRawValue());
  }

  protected prepareEditObject(object: T): any {
    return Object(object);
  }

  protected prepareShowObject(object: T): any {
    return Object(object);
  }

  protected prepareForCreate() {
    this.buildForm();
    this.operationName = 'Създаване на';
    this.formGroup.reset();
  }

  protected prepareForShow(object: T) {
    this.buildForm();
    const theObject = this.prepareShowObject(object);
    this.operationName = 'Преглед на';
    this.formGroup.setValue(theObject);
  }

  public isEditForm() {
    return this.currentAction === EActions.EDIT;
  }

  public isShowForm() {
    return this.currentAction === EActions.SHOW;
  }

  public isCreateForm() {
    return this.currentAction === EActions.CREATE;
  }

  public isFormValid() {
    return this.formGroup.dirty && this.formGroup.valid;
  }

  public isFormDirty() {
    return this.isPending || this.formGroup.dirty;
  }

  public isFormPending() {
    return this.isPending;
  }

  validateForm() {
    if (this.formGroup.invalid) {
      throw Error(
        'Формата не е валидна. Не е нормално да се вика този метод, ако формата не е валидна.'
      );
    }
  }

  public onCancel() {
    this.locationService.back();
  }

  public setToNull(igxSelect: IgxSelectComponent, formControlName: string) {
    this.logger.debug('setToNull', igxSelect, formControlName);
    igxSelect.value = null;
    this.formGroup.controls[formControlName].setValue(null);
  }
}
