import { Component, OnInit, Injector } from '@angular/core';
import { AdaptersService } from 'src/app/core/services/rest/adapters.service';
import { AdapterParametersService } from 'src/app/core/services/rest/adapter-parameters.service';
import { Router, ActivatedRoute } from '@angular/router';
import { AdapterParametersModel } from 'src/app/core/models/dto/adapter-parameters.model';
import { FormGroup, FormBuilder } from '@angular/forms';
import { Location } from '@angular/common';
import { ToastService } from '@tl/tl-common';

@Component({
  selector: 'app-operation-parameters',
  templateUrl: './operation-parameters.component.html',
  styleUrls: ['./operation-parameters.component.scss']
})
export class OperationParametersComponent implements OnInit {
  isDataLoading = false;
  items$: AdapterParametersModel[] = [];
  formGroup: FormGroup;
  adapterId: number;
  private locationService: Location;

  constructor(
    private formBuilder: FormBuilder,
    private adapterService: AdapterParametersService,
    private router: Router,
    protected activatedRoute: ActivatedRoute,
    protected toastService: ToastService,
    injector: Injector) {
      this.locationService = injector.get<Location>(Location as any);
  }
  buildFormGroup(params: AdapterParametersModel[]): FormGroup {
    const groupArgument = {};
    params.forEach(element => {
      groupArgument[element.key] = [ {value: element.value}];
    });
    return this.formBuilder.group(groupArgument);
  }

 // protected g

  ngOnInit() {
    this.isDataLoading = true;
    this.activatedRoute.params.subscribe(params => {
     this.adapterId = params['ADA_ID'];
     this.adapterService.get(this.adapterId).subscribe(res => {
       this.formGroup = this.buildFormGroup(res);
       this.items$ = res;

       const itemValues = {};
       res.forEach(element => {
          itemValues[element.key] = element.value;
        });
       this.formGroup.setValue(itemValues);
       this.isDataLoading = false;
     },
     error => {
       this.isDataLoading = false;
     }
     );
    });
  }

  public onCancel() {
    this.locationService.back();
  }

  onSubmit(event) {
    const modifiedParams = [];
    this.items$.forEach( i => {
      if (this.formGroup.value[i.key] !== i.value){
        const ap = new AdapterParametersModel();
        ap.key = i.key;
        ap.value = this.formGroup.value[i.key];
        modifiedParams.push(ap);
      }
    });
    this.adapterService.post(
      this.adapterId, modifiedParams).subscribe(
       () => {
           this.formGroup.markAsPristine();
           this.toastService.showMessage('Параметрите са обновени успешно!');
        },
        () => {
          this.formGroup.markAsPristine();
          this.toastService.showMessage('Възникна грешка при обновяване на параметри!');
        }
    );
  }

  public isFormValid() {
    return this.formGroup && this.formGroup.dirty && this.formGroup.valid;
  }
}
