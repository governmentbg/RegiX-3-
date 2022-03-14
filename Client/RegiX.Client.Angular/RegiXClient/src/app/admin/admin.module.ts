import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { TempLayoutComponent } from './components/pages/layout/layout.component';
import { HomeComponent } from './components/pages/home/home.component';
import { AdminRoutingModule } from './routes/admin-routing.module';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';
import {
  IgxNavbarModule,
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
  IgxTimePickerModule,
  IgxNavigationDrawerModule,
  IgxProgressBarModule,
  IgxTreeGridModule,
  IgxHierarchicalGridModule,
  IgxListModule,
  IgxDividerModule,
  IgxAvatarModule
} from 'igniteui-angular';
import { LoggedUserComponent } from './components/ui/logged-user/logged-user.component';
import { BreadcrumpsComponent } from './components/ui/breadcrumps/breadcrumps.component';
import { UsersComponent } from './components/pages/users/users.component';
import { RolesComponent } from './components/pages/roles/roles.component';
import { AdministrationsComponent } from './components/pages/administrations/administrations.component';
import { AuditComponent } from './components/pages/audit/audit.component';
import { SystemErrorsComponent } from './components/pages/audit/system-errors/system-errors.component';
import { UserActionsComponent } from './components/pages/audit/user-actions/user-actions.component';
import { ReportsComponent } from './components/pages/reports/reports.component';
import { ReportLogsComponent } from './components/pages/reports/report-logs/report-logs.component';
import { ReportComponent } from './components/pages/reports/report/report.component';
import { GridPagerComponent } from './components/ui/grid-pager/grid-pager.component';
import { TitleBarComponent } from './components/ui/title-bar/title-bar.component';
import { AdministrationFormComponent } from './components/pages/administrations/administration-form/administration-form.component';
import { BasicFormComponent } from './components/ui/basic-form/basic-form.component';
import { SharedModule } from '../shared/shared.module';
import { RegistersComponent } from './components/pages/registers/registers.component';
import { RoleFormComponent } from './components/pages/roles/role-form/role-form.component';
import { UserFormComponent } from './components/pages/users/user-form/user-form.component';
import { RolesToReportComponent } from './components/ui/tables/readonly/roles-to-report/roles-to-report.component';
import { AuditHistoryComponent } from './components/pages/audit/audit-history/audit-history.component';
import { UserActionFormComponent } from './components/pages/audit/user-actions/user-action-form/user-action-form.component';
import { SystemErrorFormComponent } from './components/pages/audit/system-errors/system-error-form/system-error-form.component';
import { AuditHistoryFormComponent } from './components/pages/audit/audit-history/audit-history-form/audit-history-form.component';
import { ReportFormComponent } from './components/pages/reports/report-form/report-form.component';
import { UserToRolesComponent } from './components/ui/tables/readonly/user-to-roles/user-to-roles.component';
import { RolesSelectComponent } from './components/ui/tables/roles-select/roles-select.component';
import { UsersSelectComponent } from './components/ui/tables/users-select/users-select.component';
import { UserToReportsComponent } from './components/ui/tables/readonly/user-to-reports/user-to-reports.component';
import { ReportsSelectComponent } from './components/ui/tables/reports-select/reports-select.component';
import { FavouriteReportsComponent } from './components/pages/favourite-reports/favourite-reports.component';
import { ReportsForUserSelectComponent } from './components/ui/tables/reports-for-user-select/reports-for-user-select.component';
import { AuditValuesTableComponent } from './components/ui/tables/readonly/audit-values-table/audit-values-table.component';
import { EncapsulatedHtmlComponent } from './components/pages/encapsulated-html/encapsulated-html.component';
import { SafeHtmlPipe } from './pipes/safe.html.pipe';
import { ReportResultComponent } from './components/pages/reports/report-result/report-result.component';
import { ReportResultDisplayComponent } from './components/pages/reports/report-result-display/report-result-display.component';
import { NgxPermissionsModule } from 'ngx-permissions';
import { InsufficientPrivilegesComponent } from './components/pages/insufficient-privileges/insufficient-privileges.component';
import { AsyncReportsComponent } from './components/pages/async-reports/async-reports.component';
import { AsyncReportViewComponent } from './components/pages/async-reports/async-report-view/async-report-view.component';
import { ReportExecutionsComponent } from './components/pages/report-executions/report-executions.component';
import { ReportExecutionFormComponent } from './components/pages/report-executions/report-execution-form/report-execution-form.component';
import { AdapterOperationsComponent } from './components/pages/adapter-operations/adapter-operations.component';
import { TlCommonModule } from '@tl/tl-common';
import { PrimeAdministrationsComponent } from './components/pages/prime-administrations/prime-administrations.component';
import { SettingsComponent } from './components/settings/settings.component';
import { AuditHomeComponent } from './components/audit-home/audit-home.component';
import { UserToReportsGlobalAdminComponent } from './components/ui/tables/readonly/user-to-reports-global-admin/user-to-reports-global-admin.component';
import { UsersSelectGlobalAdminComponent } from './components/ui/tables/users-select-global-admin/users-select-global-admin.component';
import { RolesSelectGlobalAdminComponent } from './components/ui/tables/roles-select-global-admin/roles-select-global-admin.component';
import { ReportsSelectGlobalAdminComponent } from './components/ui/tables/reports-select-global-admin/reports-select-global-admin.component';
import { RgxModule, RgxParametersModule } from '@tl-rgx/rgx-common';
import { SearchResultsComponent } from './components/pages/search-results/search-results.component';
import { OperationsFilterComponent } from './components/pages/filters/operations-filter/operations-filter.component';
import { HelpComponent } from './components/help/help.component';
import { MyProfileComponent } from './components/pages/my-profile/my-profile.component';
@NgModule({
  declarations: [
    TempLayoutComponent,
    HomeComponent,
    LoggedUserComponent,
    BreadcrumpsComponent,
    UsersComponent,
    RolesComponent,
    AdministrationsComponent,
    AuditComponent,
    SystemErrorsComponent,
    UserActionsComponent,
    ReportsComponent,
    ReportLogsComponent,
    ReportComponent,
    GridPagerComponent,
    TitleBarComponent,
    AdministrationFormComponent,
    BasicFormComponent,
    RegistersComponent,
    RoleFormComponent,
    UserFormComponent,
    RolesToReportComponent,
    ReportsSelectComponent,
    AuditHistoryComponent,
    UserActionFormComponent,
    SystemErrorFormComponent,
    AuditHistoryFormComponent,
    ReportFormComponent,
    UserToRolesComponent,
    RolesSelectComponent,
    UsersSelectComponent,
    UserToReportsComponent,
    FavouriteReportsComponent,
    ReportsForUserSelectComponent,
    AuditValuesTableComponent,
    EncapsulatedHtmlComponent,
    SafeHtmlPipe,
    ReportResultComponent,
    ReportResultDisplayComponent,
    InsufficientPrivilegesComponent,
    AsyncReportsComponent,
    AsyncReportViewComponent,
    ReportExecutionsComponent,
    ReportExecutionFormComponent,
    AdapterOperationsComponent,
    PrimeAdministrationsComponent,
    SettingsComponent,
    AuditHomeComponent,
    OperationsFilterComponent,
    UserToReportsGlobalAdminComponent,
    UsersSelectGlobalAdminComponent,
    RolesSelectGlobalAdminComponent,
    ReportsSelectGlobalAdminComponent,
    SearchResultsComponent,
    HelpComponent,
    MyProfileComponent
  ],
  imports: [
    NgxPermissionsModule.forChild(),
    TlCommonModule,
    RgxParametersModule,
    SharedModule,
    CommonModule,
    AdminRoutingModule,
    FormsModule,
    ReactiveFormsModule,
    IgxNavbarModule,
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
    IgxListModule,
    IgxDividerModule,
    IgxToastModule,
    IgxDatePickerModule,
    IgxTimePickerModule,
    IgxNavigationDrawerModule,
    IgxProgressBarModule,
    IgxTreeGridModule,
    IgxAvatarModule,
    IgxHierarchicalGridModule,
    RgxModule
  ]
})
export class AdminModule {}
