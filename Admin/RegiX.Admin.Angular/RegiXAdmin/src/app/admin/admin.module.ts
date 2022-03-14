import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { AdminRoutingModule } from './routes/admin-routing.module';
import { TempLayoutComponent } from './components/layout/layout.component';
import { HomeComponent } from './components/pages/home/home.component';
import { AdministrationsComponent } from './components/pages/administrations/administrations.component';
import { RegistriesComponent } from './components/pages/registries/registries.component';
import { ConsumersComponent } from './components/pages/consumers/consumers.component';
import { ErrorsComponent } from './components/pages/errors/errors.component';
import { ErrorFormComponent } from './components/pages/errors/error-form/error-form.component';

import { UsersComponent } from './components/pages/users/users.component';
import { StatisticsComponent } from './components/pages/statistics/statistics.component';
import { HelpComponent } from './components/pages/help/help.component';
import { LogReviewComponent } from './components/pages/log-review/log-review.component';

import {
  IgxNavbarModule,
  IgxTabsModule,
  IgxCardModule,
  IgxLayoutModule,
  IgxDropDownModule,
  IgxButtonModule,
  IgxToggleModule,
  IgxIconModule,
  IgxDialogModule,
  IgxGridModule,
  IgxComboModule,
  IgxSelectModule,
  IgxToastModule,
  IgxDatePickerModule,
  IgxTreeGridModule,
  IgxHierarchicalGridModule,
  IgxNavigationDrawerModule,
  IgxListModule,
  IgxDividerModule,
  IgxCalendarModule,
  IgxAvatarModule,
  IgxTimePickerModule,
} from 'igniteui-angular';
import { AdaptersComponent } from './components/pages/adapters/adapters.component';
import { InterfacesComponent } from './components/pages/interfaces/interfaces.component';
import { HealthMonitoringComponent } from './components/pages/health-monitoring/health-monitoring.component';
import { AdaptersMonitoringComponent } from './components/pages/adapters-monitoring/adapters-monitoring.component';
import { AuditComponent } from './components/pages/audit/audit.component';
import { SystemErrorsComponent } from './components/pages/audit/system-errors/system-errors.component';
import { UserActionsComponent } from './components/pages/audit/user-actions/user-actions.component';
import { LoggedUserComponent } from './components/ui/logged-user/logged-user.component';
import { ManageUserProfileComponent } from './components/pages/manage-user-profile/manage-user-profile.component';
// import { GridPagerComponent } from './components/ui/grid-pager/grid-pager.component';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';
import { TitleBarComponent } from './components/ui/title-bar/title-bar.component';
import { AdministrationFormComponent } from './components/pages/administrations/administration-form/administration-form.component';
import { RegistryFormComponent } from './components/pages/registries/registry-form/registry-form.component';
import { UserFormComponent } from './components/pages/users/user-form/user-form.component';
import { ConsumerFormComponent } from './components/pages/consumers/consumer-form/consumer-form.component';
import { AdapterFormComponent } from './components/pages/adapters/adapter-form/adapter-form.component';
import { BasicFormComponent } from './components/ui/basic-form/basic-form.component';
import { SharedModule } from '../shared/shared.module';
import { InterfaceFormComponent } from './components/pages/interfaces/interface-form/interface-form.component';
import { LogFormComponent } from './components/pages/log-review/log-form/log-form.component';
import { UserActionFormComponent } from './components/pages/audit/user-actions/user-action-form/user-action-form.component';
import { SystemErrorsFormComponent } from './components/pages/audit/system-errors/system-errors-form/system-errors-form.component';
import { AuditFormComponent } from './components/pages/audit/audit-form/audit-form.component';
import { AuditHistoryComponent } from './components/pages/audit/audit-history/audit-history.component';
import { AuditHistoryFormComponent } from './components/pages/audit/audit-history/audit-history-form/audit-history-form.component';
import { OperationParametersComponent } from './components/pages/operations/operation-parameters/operation-parameters.component';
import { OperationParametersFormComponent } from './components/pages/operations/operation-parameters/operation-parameters-form/operation-parameters-form.component';
import { OperationParameterHistoryComponent } from './components/pages/operations/operation-parameter-history/operation-parameter-history.component';
import { ParametersHistoryFormComponent } from './components/pages/operations/operation-parameter-history/parameters-history-form/parameters-history-form.component';
import { OperationsComponent } from './components/pages/operations/operations.component';
import { OperationFormComponent } from './components/pages/operations/operation-form/operation-form.component';
import { CertificatesComponent } from './components/pages/certificates/certificates.component';
import { CertificateFormComponent } from './components/pages/certificates/certificate-form/certificate-form.component';
import { AccessFormComponent } from './components/pages/certificates/access-form/access-form.component';
import { CertificateOperationsComponent } from './components/pages/certificates/certificate-operations/certificate-operations.component';
import { CertificateOperationFormComponent } from './components/pages/certificates/certificate-operations/certificate-operation-form/certificate-operation-form.component';
import { ElementAccessComponent } from './components/pages/certificates/element-access/element-access.component';
import { UserEditFormComponent } from './components/pages/users/user-edit-form/user-edit-form.component';
import { UserShowFormComponent } from './components/pages/users/user-show-form/user-show-form.component';
import { AuditValuesTableComponent } from './components/ui/tables/audit-values-table/audit-values-table.component';
import { NotRegisterAdaptersComponent } from './components/pages/not-register-adapters/not-register-adapters.component';
import { NotRegisterAdaptersFormComponent } from './components/pages/not-register-adapters/not-register-adapters-form/not-register-adapters-form.component';
import { NgxPermissionsModule } from 'ngx-permissions';
import { AccessEditFormComponent } from './components/pages/certificates/access-edit-form/access-edit-form.component';
import { ConsumerOperationComponent } from './components/pages/consumers/consumer-operation/consumer-operation.component';
import { ConsumerOperationFormComponent } from './components/pages/consumers/consumer-operation/consumer-operation-form/consumer-operation-form.component';
import { ConsumerRolesComponent } from './components/pages/consumer-roles/consumer-roles.component';
import { ConsumerRolesFormComponent } from './components/pages/consumer-roles/consumer-roles-form/consumer-roles-form.component';
import { ConsumerRolesOperationsComponent } from './components/pages/consumer-roles/consumer-roles-operations/consumer-roles-operations.component';
import { ConsumerRolesOperationsFormComponent } from './components/pages/consumer-roles/consumer-roles-operations/consumer-roles-operations-form/consumer-roles-operations-form.component';
import { ConsumerAccessEditFormComponent } from './components/pages/consumer-roles/consumer-access-edit-form/consumer-access-edit-form.component';
import { ConsumerAccessFormComponent } from './components/pages/consumer-roles/consumer-access-form/consumer-access-form.component';
import { ConsumerElementAccessComponent } from './components/pages/consumer-roles/element-access/consumer-element-access.component';
import { TlCommonModule } from '@tl/tl-common';
import { AdministrationTypesComponent } from './components/pages/administration-types/administration-types.component';
import { AdministrationTypeFormComponent } from './components/pages/administration-types/administration-type-form/administration-type-form.component';
import { AccessReportNewComponent } from './components/pages/access-report-new/access-report-new.component';
import { LogReviewPrimaryFilterComponent } from './components/pages/filters/log-review-primary-filter/log-review-primary-filter.component';
import { LogReviewAdministrationFilterComponent } from './components/pages/filters/log-review-administration-filter/log-review-administration-filter.component';
import { ConsumerProfilesComponent } from './components/pages/consumer-profiles/consumer-profiles.component';
import { ConsumerProfilesFormComponent } from './components/pages/consumer-profiles/consumer-profiles-form/consumer-profiles-form.component';
import { ConsumerProfileUsersTableComponent } from './components/ui/tables/consumer-profile-users-table/consumer-profile-users-table.component';

import { ConsumerProfileUsersFormComponent } from './components/pages/consumer-profile-users/consumer-profile-users-form/consumer-profile-users-form.component';
import { ConsumerProfileStatusTableComponent } from './components/ui/tables/consumer-profile-status-table/consumer-profile-status-table.component';
import { ConsumerSystemsComponent } from './components/pages/consumer-systems/consumer-systems.component';
import { ConsumerSystemsFormComponent } from './components/pages/consumer-systems/consumer-systems-form/consumer-systems-form.component';
import { ConsumerSystemCertificatesComponent } from './components/pages/consumer-system-certificates/consumer-system-certificates.component';
import { ConsumerSystemCertificatesFormComponent } from './components/pages/consumer-system-certificates/consumer-system-certificates-form/consumer-system-certificates-form.component';
import { ConsumerSystemCertificatesFilterComponent } from './components/pages/filters/consumer-system-certificates-filter/consumer-system-certificates-filter.component';
import { ConsumerRequestOperationsComponent } from './components/pages/consumer-system-certificates/consumer-request-operations/consumer-request-operations.component';
import { ConsumerRequestOperationsFormComponent } from './components/pages/consumer-system-certificates/consumer-request-operations/consumer-request-operations-form/consumer-request-operations-form.component';
import { AdministrationsFilterComponent } from './components/pages/filters/administrations-filter/administrations-filter.component';
import { CertificateFilterComponent } from './components/pages/filters/certificate-filter/certificate-filter.component';
import { OperationFilterComponent } from './components/pages/filters/operation-filter/operation-filter.component';
import { ConsumerFilterComponent } from './components/pages/filters/consumer-filter/consumer-filter.component';
import { PrimaryAdministrationFilterComponent } from './components/pages/filters/primary-administration-filter/primary-administration-filter.component';
import { RegisterFilterComponent } from './components/pages/filters/register-filter/register-filter.component';
import { ConsumerSystemsFilterComponent } from './components/pages/filters/consumer-systems-filter/consumer-systems-filter.component';
import { ConsumerAssessRequestStatusTableComponent } from './components/ui/tables/consumer-assess-request-status-table/consumer-assess-request-status-table.component';
import { ConsumerRequestsComponent } from './components/pages/consumer-requests/consumer-requests.component';
import { ConsumerRequestStatusTableComponent } from './components/ui/tables/consumer-request-status-table/consumer-request-status-table.component';
import { ConsumerRequestsFormComponent } from './components/pages/consumer-requests/consumer-requests-form/consumer-requests-form.component';
import { ConsumerAccessRequestsComponent } from './components/pages/consumer-access-requests/consumer-access-requests.component';
import { ConsumerAccessRequestsFormComponent } from './components/pages/consumer-access-requests/consumer-access-requests-form/consumer-access-requests-form.component';
import { ConsumerProfilesApprovalComponent } from './components/pages/consumer-profiles-approval/consumer-profiles-approval.component';
import { ConsumerProfilesApprovalFormComponent } from './components/pages/consumer-profiles-approval/consumer-profiles-approval-form/consumer-profiles-approval-form.component';
import { ConsumerRequestsApprovalComponent } from './components/pages/consumer-requests-approval/consumer-requests-approval.component';
import { CertificateSwapFilterComponent } from './components/pages/filters/certificate-swap-filter/certificate-swap-filter.component';
import { RgxModule } from '@tl-rgx/rgx-common';
import { MyProfileComponent } from './components/pages/my-profile/my-profile.component';
import { ElementFilterComponent } from './components/pages/filters/element-filter/element-filter.component';

@NgModule({
  declarations: [
    TempLayoutComponent,
    HomeComponent,
    AdministrationsComponent,
    RegistriesComponent,
    ConsumersComponent,
    ErrorsComponent,
    UsersComponent,
    StatisticsComponent,
    HelpComponent,
    LogReviewComponent,
    AdaptersComponent,
    InterfacesComponent,
    HealthMonitoringComponent,
    AdaptersMonitoringComponent,
    AuditComponent,
    SystemErrorsComponent,
    UserActionsComponent,
    LoggedUserComponent,
    ManageUserProfileComponent,
    // GridPagerComponent,
    TitleBarComponent,
    AdministrationFormComponent,
    RegistryFormComponent,
    UserFormComponent,
    ConsumerFormComponent,
    AdapterFormComponent,
    BasicFormComponent,
    InterfaceFormComponent,
    ErrorFormComponent,
    LogFormComponent,
    UserActionFormComponent,
    SystemErrorsFormComponent,
    AuditFormComponent,
    AuditHistoryComponent,
    AuditHistoryFormComponent,
    OperationParametersComponent,
    OperationParametersFormComponent,
    OperationParameterHistoryComponent,
    ParametersHistoryFormComponent,
    OperationsComponent,
    OperationFormComponent,
    CertificatesComponent,
    CertificateFormComponent,
    AccessFormComponent,
    AccessEditFormComponent,
    CertificateOperationsComponent,
    CertificateOperationFormComponent,
    ElementAccessComponent,
    UserEditFormComponent,
    UserShowFormComponent,
    AuditValuesTableComponent,
    NotRegisterAdaptersComponent,
    NotRegisterAdaptersFormComponent,
    ConsumerOperationComponent,
    ConsumerOperationFormComponent,
    ConsumerRolesComponent,
    ConsumerRolesFormComponent,
    ConsumerRolesOperationsComponent,
    ConsumerRolesOperationsFormComponent,
    ConsumerAccessEditFormComponent,
    ConsumerAccessFormComponent,
    ConsumerElementAccessComponent,
    AdministrationTypesComponent,
    AdministrationTypeFormComponent,
    OperationFilterComponent,
    ConsumerFilterComponent,
    AdministrationsFilterComponent,
    PrimaryAdministrationFilterComponent,
    AccessReportNewComponent,
    RegisterFilterComponent,
    CertificateFilterComponent,
    LogReviewPrimaryFilterComponent,
    LogReviewAdministrationFilterComponent,
    ConsumerProfilesComponent,
    ConsumerProfilesFormComponent,
    ConsumerProfileUsersTableComponent,
    ConsumerProfileStatusTableComponent,
    ConsumerProfileUsersFormComponent,
    ConsumerSystemsComponent,
    ConsumerSystemsFormComponent,
    ConsumerSystemsFilterComponent,
    ConsumerSystemCertificatesComponent,
    ConsumerSystemCertificatesFormComponent,
    ConsumerSystemCertificatesFilterComponent,
    ConsumerRequestOperationsComponent,
    ConsumerRequestOperationsFormComponent,
    ConsumerAssessRequestStatusTableComponent,
    ConsumerRequestsComponent,
    ConsumerRequestStatusTableComponent,
    ConsumerRequestsFormComponent,
    ConsumerAccessRequestsComponent,
    ConsumerAccessRequestsFormComponent,
    ConsumerProfilesApprovalComponent,
    ConsumerProfilesApprovalFormComponent,
    ConsumerRequestsApprovalComponent,
    CertificateSwapFilterComponent,
    MyProfileComponent,
    ElementFilterComponent,
  ],
  imports: [
    SharedModule,
    CommonModule,
    TlCommonModule,
    AdminRoutingModule,
    FormsModule,
    ReactiveFormsModule,
    IgxNavbarModule,
    IgxNavigationDrawerModule,
    IgxTabsModule,
    IgxCardModule,
    IgxLayoutModule,
    IgxButtonModule,
    IgxToggleModule,
    IgxIconModule,
    IgxDropDownModule,
    IgxDialogModule,
    IgxGridModule,
    IgxComboModule,
    IgxSelectModule,
    IgxToastModule,
    IgxDatePickerModule,
    IgxTreeGridModule,
    IgxHierarchicalGridModule,
    IgxDividerModule,
    IgxListModule,
    IgxAvatarModule,
    IgxCalendarModule,
    IgxTimePickerModule,
    RgxModule,
    NgxPermissionsModule.forChild(),
  ],
  exports: [NgxPermissionsModule],
  providers: [],
})
export class AdminModule {}
