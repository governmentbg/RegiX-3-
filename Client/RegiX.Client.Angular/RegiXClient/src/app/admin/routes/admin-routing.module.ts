// tslint:disable: max-line-length
import { MyProfileComponent } from './../components/pages/my-profile/my-profile.component';
import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { TempLayoutComponent } from '../components/pages/layout/layout.component';
import { HomeComponent } from '../components/pages/home/home.component';
import { AdministrationsComponent } from '../components/pages/administrations/administrations.component';
import { UsersComponent } from '../components/pages/users/users.component';
import { RolesComponent } from '../components/pages/roles/roles.component';
import { AuditComponent } from '../components/pages/audit/audit.component';
import { SystemErrorsComponent } from '../components/pages/audit/system-errors/system-errors.component';
import { UserActionsComponent } from '../components/pages/audit/user-actions/user-actions.component';
import { ReportLogsComponent } from '../components/pages/reports/report-logs/report-logs.component';
import { ReportComponent } from '../components/pages/reports/report/report.component';
import { AdministrationFormComponent } from '../components/pages/administrations/administration-form/administration-form.component';
import { RegistersComponent } from '../components/pages/registers/registers.component';
import { UserFormComponent } from '../components/pages/users/user-form/user-form.component';
import { RoleFormComponent } from '../components/pages/roles/role-form/role-form.component';
import { AuditHistoryComponent } from '../components/pages/audit/audit-history/audit-history.component';
import { UserActionFormComponent } from '../components/pages/audit/user-actions/user-action-form/user-action-form.component';
import { SystemErrorFormComponent } from '../components/pages/audit/system-errors/system-error-form/system-error-form.component';
import { AuditHistoryFormComponent } from '../components/pages/audit/audit-history/audit-history-form/audit-history-form.component';
import { ReportsComponent } from '../components/pages/reports/reports.component';
import { ReportFormComponent } from '../components/pages/reports/report-form/report-form.component';
import { FavouriteReportsComponent } from '../components/pages/favourite-reports/favourite-reports.component';
import { NgxPermissionsGuard } from 'ngx-permissions';
import { InsufficientPrivilegesComponent } from '../components/pages/insufficient-privileges/insufficient-privileges.component';
import { AsyncReportsComponent } from '../components/pages/async-reports/async-reports.component';
import { AsyncReportViewComponent } from '../components/pages/async-reports/async-report-view/async-report-view.component';
import { ReportExecutionsComponent } from '../components/pages/report-executions/report-executions.component';
import { ReportExecutionFormComponent } from '../components/pages/report-executions/report-execution-form/report-execution-form.component';
import { AdapterOperationsComponent } from '../components/pages/adapter-operations/adapter-operations.component';
import { ROUTES } from './static-routes';
import { TLRoute, TLData, TLRoutingModule } from '@tl/tl-common';
import { PrimeAdministrationsComponent } from '../components/pages/prime-administrations/prime-administrations.component';
import { SettingsComponent } from '../components/settings/settings.component';
import { AuditHomeComponent } from '../components/audit-home/audit-home.component';
import { ClientPermissions } from '../permissions';
import { SearchResultsComponent } from '../components/pages/search-results/search-results.component';
import { HelpComponent } from '../components/help/help.component';

export const ADMIN_MODULE_PATH = 'admin';

const routes: Routes = [
  TLRoute('', TempLayoutComponent, TLData(ROUTES.HOME, 'Начало', 'home'), [
    TLRoute('', HomeComponent, TLData(undefined, 'Начало', 'home')),
    TLRoute('unauthorized', InsufficientPrivilegesComponent, TLData(ROUTES.UNAUTHORIZED, 'Отказан достъп', 'error')),
    TLRoute('my-profile', undefined, TLData(ROUTES.MYPROFILE, 'Моят профил', 'person'), [
      TLRoute('', MyProfileComponent, TLData(undefined, 'Моят профил', 'person')),
      TLRoute('view/:ID', AsyncReportViewComponent, TLData(ROUTES.ASYNC_VIEW, 'Преглед на резултат', 'remove_red_eye'))
    ]),
    TLRoute('async', undefined, TLData(ROUTES.ASYNC, 'Чакащи услуги', 'schedule'), [
      TLRoute('', AsyncReportsComponent, TLData(undefined, 'Чакащи услуги', 'schedule')),
      TLRoute('view/:ID', AsyncReportViewComponent, TLData(ROUTES.ASYNC_VIEW, 'Преглед на резултат', 'remove_red_eye'))
    ]),
    TLRoute('settings-home', SettingsComponent, TLData(ROUTES.SETTINGS, 'Настройки', 'build'), [], ClientPermissions.ADMIN),
    TLRoute('reports', undefined, TLData(ROUTES.REPORTS, 'Услуги', 'receipt'), [
      TLRoute('', ReportsComponent, TLData(undefined, 'Услуги', 'receipt')),
      TLRoute('report', ReportFormComponent, TLData(ROUTES.REPORT_NEW, 'Нова', 'add', undefined, undefined, undefined, 'Услуга')),
      TLRoute('report/:ID', ReportFormComponent, TLData(ROUTES.REPORT_VIEW, 'Преглед', 'remove_red_eye', false, undefined, undefined, 'Услуга')),
      TLRoute('report/:ID/edit', ReportFormComponent, TLData(ROUTES.REPORT_EDIT, 'Редакция', 'edit', true, undefined, undefined, 'Услуга'))
    ], ClientPermissions.ADMIN),
    TLRoute('administrations', undefined, TLData(ROUTES.ADMINISTRATIONS, 'Администрации', 'account_balance'), [
      TLRoute('', AdministrationsComponent, TLData(undefined, 'Администрации', 'account_balance')),
      TLRoute('administration', AdministrationFormComponent, TLData(ROUTES.ADMINISTRATION_NEW, 'Нова', 'add', undefined, undefined, undefined, 'Администрация')),
      TLRoute('administration/:ID', AdministrationFormComponent, TLData(ROUTES.ADMINISTRATION_VIEW, 'Преглед', 'remove_red_eye', false, undefined, undefined, 'Администрация')),
      TLRoute('administration/:ID/edit', AdministrationFormComponent, TLData(ROUTES.ADMINISTRATION_EDIT, 'Редакция', 'edit', true, undefined, undefined, 'Администрация')),
    ], ClientPermissions.GLOBAL_ADMIN),
    TLRoute('users', undefined, TLData(ROUTES.USERS, 'Потребители', 'person'), [
      TLRoute('', UsersComponent, TLData(undefined, 'Потребители', 'person')),
      TLRoute('user', UserFormComponent, TLData(ROUTES.USER_NEW, 'Нов', 'add', undefined, undefined, undefined, 'Потребител')),
      TLRoute('user/:ID', UserFormComponent, TLData(ROUTES.USER_VIEW, 'Преглед', 'remove_red_eye', false, undefined, undefined, 'Потребител')),
      TLRoute('user/:ID/edit', UserFormComponent, TLData(ROUTES.USER_EDIT, 'Редакция', 'edit', true, undefined, undefined, 'Потребител'))
    ], ClientPermissions.ADMIN),
    TLRoute('roles', undefined, TLData(ROUTES.ROLES, 'Роли', 'supervised_user_circle'), [
      TLRoute('', RolesComponent, TLData(undefined, 'Роли', 'supervised_user_circle')),
      TLRoute('role', RoleFormComponent, TLData(ROUTES.ROLE_NEW, 'Нова', 'add', undefined, undefined, undefined, 'Роля')),
      TLRoute('role/:ID', RoleFormComponent, TLData(ROUTES.ROLE_VIEW, 'Преглед', 'remove_red_eye', false, undefined, undefined, 'Роля')),
      TLRoute('role/:ID/edit', RoleFormComponent, TLData(ROUTES.ROLE_EDIT, 'Редакция', 'edit', true, undefined, undefined, 'Роля'))
    ], ClientPermissions.ADMIN),
    TLRoute('favouriteReports', FavouriteReportsComponent, TLData(ROUTES.FAVOURITES, 'Предпочитани услуги', 'star'), [], ClientPermissions.ALL),
    TLRoute('adapter-operations', AdapterOperationsComponent, TLData(ROUTES.ADAPTER_OPERATIONS, 'Адаптер операции', 'receipt')),
    TLRoute('audit-home', AuditHomeComponent, TLData(ROUTES.AUDIT, 'Журнал', 'menu_book'), [ ], ClientPermissions.ALL),
    TLRoute('audit', AuditComponent, TLData(ROUTES.AUDIT_DATA, 'Данни от одит', 'pageview'), [], ClientPermissions.ADMIN),
    TLRoute('historyFilter/:FILTER_FIELD', AuditHistoryComponent, TLData(ROUTES.AUDIT_HISTORY, 'История на таблици', 'rotate_left', false)),
    TLRoute('history/:ID', AuditHistoryFormComponent, TLData(ROUTES.AUDIT_HISTORY_VIEW, 'История на таблица', '', false)),
    TLRoute('systemErrors', undefined, TLData(ROUTES.SYSTEM_ERRORS, 'Системни грешки', 'memory'), [
      TLRoute('', SystemErrorsComponent, TLData(undefined, 'Системни грешки', 'memory')),
      TLRoute('systemError/:ID', SystemErrorFormComponent, TLData(ROUTES.SYSTEM_ERROR_VIEW, 'Системна грешка', 'remove_red_eye', false)),
    ], ClientPermissions.ADMIN),
    TLRoute('userActions', undefined, TLData(ROUTES.USER_ACTIONS, 'Потребителски действия', 'supervised_user_circle'), [
      TLRoute('', UserActionsComponent, TLData(undefined, 'Потребителски действия')),
      TLRoute('userAction/:ID', UserActionFormComponent, TLData(ROUTES.USER_ACTION_VIEW, 'Преглед', 'remove_red_eye', false))
    ], ClientPermissions.ADMIN),
    TLRoute('reportExecutions', undefined, TLData(ROUTES.REPORT_EXECUTIONS, 'Извършени услуги', 'history'), [
      TLRoute('', ReportExecutionsComponent, TLData(undefined, 'Извършени услуги')),
      TLRoute('reportExecution/:ID', ReportExecutionFormComponent, TLData(ROUTES.REPORT_EXECUTION_VIEW, 'Извършена услуга', 'receipt', false))
    ], ClientPermissions.ALL),
    TLRoute('reportLogs', ReportLogsComponent, TLData(ROUTES.REPORT_LOGS, 'Журнал за услуги')),
    TLRoute('search-results/:TERM', SearchResultsComponent, TLData(ROUTES.SEARCH_RESULTS, 'Търсене', 'search')),
    TLRoute(':ADM_ID/administrations', undefined, TLData(ROUTES.PRIME_ADMINISTRATIONS, 'Администрации', 'account_balance', undefined, undefined, true), [
      TLRoute('', PrimeAdministrationsComponent, TLData(undefined, 'Администрации', 'account_balance  ', undefined, undefined, true)),
      TLRoute(':REG_ID/registers', undefined, TLData(ROUTES.REGISTERS, 'Регистри', 'dashboard', undefined, undefined, true), [
        TLRoute('', RegistersComponent, TLData(undefined, 'Регистри', 'dashboard', undefined, undefined, true)),
        TLRoute(':REPORT_ID', ReportComponent, TLData(ROUTES.OPERATION, 'Услуги', 'receipt'))
      ])
    ]),
    TLRoute('help/:MARKED', HelpComponent, TLData(ROUTES.HELP, 'Помощ', 'help'), [ ], ClientPermissions.ALL),
  ])
];

@NgModule({
  imports: [RouterModule.forChild(routes)],
  exports: [RouterModule]
})
export class AdminRoutingModule extends TLRoutingModule {
  constructor() {
    super(routes, ADMIN_MODULE_PATH);
  }
}
