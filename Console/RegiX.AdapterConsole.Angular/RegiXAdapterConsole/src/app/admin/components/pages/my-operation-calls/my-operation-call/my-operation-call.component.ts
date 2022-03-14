import {
  Component,
  OnInit,
  OnDestroy,
  AfterViewInit,
  NgZone
} from "@angular/core";
import { OperationCallModel } from "src/app/core/models/dto/operation-call.model";
import { OperationParameterModel } from "src/app/core/models/operations/operation-parameter.model";
import { FormGroup, FormBuilder } from "@angular/forms";
import { AdapterOperationsService } from "src/app/core/services/rest/adapter-operations.service";
import { ActivatedRoute } from "@angular/router";
import { HttpParams } from "@angular/common/http";
import { Location } from "@angular/common";

import { Subscription } from "rxjs";
import { OperationParameterWithValueModel } from "src/app/core/models/operation-values/operation-parameter-with-value.model";
import { AdapterOperationModel } from "src/app/core/models/dto/adapter-operation.model";
import { ToastService } from '@tl/tl-common'
import { UsersService } from "src/app/core/services/rest/users.service";
import { UsersModel } from "src/app/core/models/dto/users.model";
import { DisplayValue } from "src/app/core/models/display-value.model";
import { map } from "rxjs/operators";
import { IgxSelectComponent } from "igniteui-angular";
import { OperationControlService } from "../../operation-calls/operation-call/operation-control-service.service";
import { MyOperationCallsService } from "src/app/core/services/rest/my-operation-calls.service";
import { OidcSecurityService } from "angular-auth-oidc-client";
import { BaseOperationCallComponent } from '../../../base/base-operation-call';

@Component({
  selector: "app-my-operation-call",
  templateUrl: "./my-operation-call.component.html",
  styleUrls: ["./my-operation-call.component.scss"],
  providers: [OperationControlService]
})
export class MyOperationCallComponent
extends BaseOperationCallComponent<
OperationCallModel,
MyOperationCallsService
> {

  constructor(
    activatedRoute: ActivatedRoute,
    operationCallsService: MyOperationCallsService,
    adapterOperationService: AdapterOperationsService,
    operationSubjectService: OperationControlService,
    userService: UsersService,
    locationService: Location,
    formBuilder: FormBuilder,
    toastService: ToastService,
    ngZone: NgZone,
    oidcSecurityService: OidcSecurityService
  ) {
    super(
      activatedRoute,
      operationCallsService,
      adapterOperationService,
      operationSubjectService,
      userService,
      locationService,
      formBuilder,
      toastService,
      ngZone,
      oidcSecurityService
    );
  }
  protected setSystemData() {
    if (this.isShowForm) {
      this.formGroupResponse.patchValue({
        assignedToName: this.operationCall.assignedToName,
        startTime: new Date(this.operationCall.startTime)
      });
    } else {
      this.readUsers();
      this.formGroupResponse.patchValue({
        startTime: new Date(this.operationCall.startTime)
      });
    }
  }
  protected SetCurrentUserData() {
    this.oidcSecurityService.userData$.subscribe(userData => {
      const mainRole = userData.role;
      if (mainRole === "Admin") {
        this.isAdmin = true;
      } else {
        this.isAdmin = false;
      }
    });
  }

}
