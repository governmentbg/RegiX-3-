import { Component, NgZone } from "@angular/core";
import { OperationCallModel } from "src/app/core/models/dto/operation-call.model";
import { OperationCallsService } from "src/app/core/services/rest/operation-calls.service";
import { DisplayValue } from "src/app/core/models/display-value.model";
import { BaseOperationCallComponent } from "src/app/admin/components/base/base-operation-call";
import { OperationControlService } from "./operation-control-service.service";
import { ActivatedRoute } from "@angular/router";
import { Location, LocationStrategy } from "@angular/common";
import { AdapterOperationsService } from "src/app/core/services/rest/adapter-operations.service";
import { UsersService } from "src/app/core/services/rest/users.service";
import { FormBuilder } from "@angular/forms";
import { ToastService } from '@tl/tl-common'
import { OidcSecurityService } from "angular-auth-oidc-client";

@Component({
  selector: "app-operation-call",
  templateUrl: "./operation-call.component.html",
  styleUrls: ["./operation-call.component.scss"],
  providers: [OperationControlService]
})
export class OperationCallComponent extends BaseOperationCallComponent<
  OperationCallModel,
  OperationCallsService
> {
  currentUserId: number = null;
  currentUserName: string = null;
  isBrowserBackButtonPressed: boolean = false;

  constructor(
    activatedRoute: ActivatedRoute,
    operationCallsService: OperationCallsService,
    adapterOperationService: AdapterOperationsService,
    operationSubjectService: OperationControlService,
    userService: UsersService,
    locationService: Location,
    formBuilder: FormBuilder,
    toastService: ToastService,
    ngZone: NgZone,
    oidcSecurityService: OidcSecurityService,
    private location: LocationStrategy
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
    location.onPopState(() => {
      this.isBrowserBackButtonPressed = true;
      this.onCancel();

    });
  }

  public onCancel() {
    if (!this.isAdmin) {
      this.onClear(); // clear filled fields
      if (!this.formGroupResponse.valid && !this.formGroupResponse.touched) {
        this.operationCallsService
        .updateAssignedTo({
          operationId: this.operationCall.id,
          operationCallName: this.operationCall.adapterOperationName,
          assignedToId: null
        })
        .subscribe(() => {
          this.errorMessage = null;
        }, error => {
          console.log('error', error);
          this.errorMessage =
            'Грешка при обновяване на обект: ' + error.message;
        });
      }
    }
    if(!this.isBrowserBackButtonPressed){
      this.locationService.back();
    }

  }

  protected setSystemData() {
    if (this.isShowForm) {
      this.formGroupResponse.patchValue({
        assignedToName: this.operationCall.assignedToName,
        startTime: new Date(this.operationCall.startTime)
      });
    } else {
      this.formGroupResponse.patchValue({
        startTime: new Date(this.operationCall.startTime)
      });
      if (this.isAdmin) {
        this.readUsers();
      } else {
        // Add post to api to save assigned to so other users cant edit
        // is user accedently click edit and press back without editing shoud we clear Assigned to
        this.assignCurrentUserToOperation();
        // Sending current user to API so no other user can access the operation
        this.updateAssignedTo();
      }
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
      this.currentUserId = +userData.sub;
      this.currentUserName = userData.given_name;
    });
  }

  private updateAssignedTo() {
    this.operationCallsService
      .updateAssignedTo({
        operationId: this.operationCall.id,
        operationCallName: this.operationCall.adapterOperationName,
        assignedToId: this.assignedTo.id
      })
      .subscribe(
        () => {
          this.errorMessage = null;
        },
        error => {
          console.log("error", error);
          this.errorMessage =
            "Грешка при обновяване на обект: " + error.message;
        }
      );
  }

  private assignCurrentUserToOperation() {
    this.assignedTo = new DisplayValue();
    this.assignedTo.id = this.currentUserId;
    this.assignedTo.displayName = this.currentUserName;
    this.users = [this.assignedTo];
    this.operationCall.assignedTo = this.assignedTo;
  }
}
