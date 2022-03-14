import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { LayoutComponent } from './components/pages/layout/layout.component';
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
  IgxNavigationDrawerModule,
  IgxProgressBarModule,
  IgxTreeGridModule,
  IgxHierarchicalGridModule
} from 'igniteui-angular';
import { LoggedUserComponent } from './components/ui/logged-user/logged-user.component';
import { UsersComponent } from './components/pages/users/users.component';
import { RolesComponent } from './components/pages/roles/roles.component';
import { GridPagerComponent } from './components/ui/grid-pager/grid-pager.component';
import { TitleBarComponent } from './components/ui/title-bar/title-bar.component';
import { BasicFormComponent } from './components/ui/basic-form/basic-form.component';
import { SharedModule } from '../shared/shared.module';
import { TextFieldComponent } from './components/ui/controls/text-field/text-field.component';
import { DateFieldComponent } from './components/ui/controls/date-field/date-field.component';
import { BooleanFieldComponent } from './components/ui/controls/boolean-field/boolean-field.component';
import { EnumFieldComponent } from './components/ui/controls/enum-field/enum-field.component';
import { RoleFormComponent } from './components/pages/roles/role-form/role-form.component';
import { UserFormComponent } from './components/pages/users/user-form/user-form.component';
import { UserToRolesComponent } from './components/ui/tables/readonly/user-to-roles/user-to-roles.component';
import { UserToReportsComponent } from './components/ui/tables/readonly/user-to-reports/user-to-reports.component';
import { ReportsSelectComponent } from './components/ui/tables/reports-select/reports-select.component';
import { IntFieldComponent } from './components/ui/controls/int-field/int-field.component';
import { DecimalFieldComponent } from './components/ui/controls/decimal-field/decimal-field.component';
import { ParametersControlComponent } from './components/ui/parameters-control/parameters-control.component';
import { EncapsulatedHtmlComponent } from './components/pages/encapsulated-html/encapsulated-html.component';
import { SafeHtmlPipe } from './pipes/safe.html.pipe';
import { NgxPermissionsModule } from 'ngx-permissions';
import { InsufficientPrivilegesComponent } from './components/pages/insufficient-privileges/insufficient-privileges.component';
import { OperationCallsComponent } from './components/pages/operation-calls/operation-calls.component';
import { OperationCallComponent } from './components/pages/operation-calls/operation-call/operation-call.component';
import { MyOperationCallsComponent } from './components/pages/my-operation-calls/my-operation-calls.component';
import { MyOperationCallComponent } from './components/pages/my-operation-calls/my-operation-call/my-operation-call.component';
import { AdapterOperationsComponent } from './components/pages/adapter-operations/adapter-operations.component';
import { AdapterOperationsFormComponent } from './components/pages/adapter-operations/adapter-operations-form/adapter-operations-form.component';
import { ReturnedCallsComponent } from './components/pages/returned-calls/returned-calls.component';
import { ReturnedCallComponent } from './components/pages/returned-calls/returned-call/returned-call.component';
import { TlCommonModule } from '@tl/tl-common';
import { OperationPersistanceComponent } from './components/pages/operation-persistance/operation-persistance.component';
import { RgxModule } from '@tl-rgx/rgx-common';

@NgModule({
  declarations: [
    LayoutComponent,
    HomeComponent,
    LoggedUserComponent,
    UsersComponent,
    RolesComponent,
    GridPagerComponent,
    TitleBarComponent,
    BasicFormComponent,
    TextFieldComponent,
    DateFieldComponent,
    BooleanFieldComponent,
    EnumFieldComponent,
    RoleFormComponent,
    UserFormComponent,
    ReportsSelectComponent,
    UserToRolesComponent,
    UserToReportsComponent,
    IntFieldComponent,
    DecimalFieldComponent,
    ParametersControlComponent,
    EncapsulatedHtmlComponent,
    SafeHtmlPipe,
    InsufficientPrivilegesComponent,
    OperationCallsComponent,
    OperationCallComponent,
    MyOperationCallsComponent,
    MyOperationCallComponent,
    AdapterOperationsComponent,
    AdapterOperationsFormComponent,
    ReturnedCallsComponent,
    ReturnedCallComponent,
    BasicFormComponent,
    OperationPersistanceComponent
  ],
  imports: [
    NgxPermissionsModule.forChild(),
    SharedModule,
    CommonModule,
    TlCommonModule,
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
    IgxToastModule,
    IgxDatePickerModule,
    IgxNavigationDrawerModule,
    IgxProgressBarModule,
    IgxTreeGridModule,
    IgxHierarchicalGridModule,
    TlCommonModule,
    RgxModule
  ],
  exports: [
    BasicFormComponent
  ]
})
export class AdminModule {}
