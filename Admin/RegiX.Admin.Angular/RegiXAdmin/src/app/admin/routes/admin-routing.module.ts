// tslint:disable:max-line-length
import { ConsumerRequestOperationsComponent } from './../components/pages/consumer-system-certificates/consumer-request-operations/consumer-request-operations.component';
import { ConsumerSystemCertificatesComponent } from './../components/pages/consumer-system-certificates/consumer-system-certificates.component';
import { ConsumerSystemsComponent } from './../components/pages/consumer-systems/consumer-systems.component';
import { ConsumerProfileUsersFormComponent } from './../components/pages/consumer-profile-users/consumer-profile-users-form/consumer-profile-users-form.component';
import { ConsumerProfilesComponent } from './../components/pages/consumer-profiles/consumer-profiles.component';
import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { AUTH_PATHS, TLData, TLRoute, TLRoutingModule } from '@tl/tl-common';
import { TempLayoutComponent } from '../components/layout/layout.component';
import { AdapterFormComponent } from '../components/pages/adapters/adapter-form/adapter-form.component';
import { AdaptersComponent } from '../components/pages/adapters/adapters.component';
import { AdministrationTypeFormComponent } from '../components/pages/administration-types/administration-type-form/administration-type-form.component';
import { AdministrationTypesComponent } from '../components/pages/administration-types/administration-types.component';
import { AdministrationFormComponent } from '../components/pages/administrations/administration-form/administration-form.component';
import { AdministrationsComponent } from '../components/pages/administrations/administrations.component';
import { AuditFormComponent } from '../components/pages/audit/audit-form/audit-form.component';
import { AuditHistoryFormComponent } from '../components/pages/audit/audit-history/audit-history-form/audit-history-form.component';
import { AuditHistoryComponent } from '../components/pages/audit/audit-history/audit-history.component';
import { AuditComponent } from '../components/pages/audit/audit.component';
import { SystemErrorsFormComponent } from '../components/pages/audit/system-errors/system-errors-form/system-errors-form.component';
import { SystemErrorsComponent } from '../components/pages/audit/system-errors/system-errors.component';
import { UserActionFormComponent } from '../components/pages/audit/user-actions/user-action-form/user-action-form.component';
import { UserActionsComponent } from '../components/pages/audit/user-actions/user-actions.component';
import { AccessEditFormComponent } from '../components/pages/certificates/access-edit-form/access-edit-form.component';
import { AccessFormComponent } from '../components/pages/certificates/access-form/access-form.component';
import { CertificateFormComponent } from '../components/pages/certificates/certificate-form/certificate-form.component';
import { CertificateOperationFormComponent } from '../components/pages/certificates/certificate-operations/certificate-operation-form/certificate-operation-form.component';
import { CertificateOperationsComponent } from '../components/pages/certificates/certificate-operations/certificate-operations.component';
import { CertificatesComponent } from '../components/pages/certificates/certificates.component';
import { ElementAccessComponent } from '../components/pages/certificates/element-access/element-access.component';
import { ConsumerAccessEditFormComponent } from '../components/pages/consumer-roles/consumer-access-edit-form/consumer-access-edit-form.component';
import { ConsumerAccessFormComponent } from '../components/pages/consumer-roles/consumer-access-form/consumer-access-form.component';
import { ConsumerRolesFormComponent } from '../components/pages/consumer-roles/consumer-roles-form/consumer-roles-form.component';
import { ConsumerRolesOperationsComponent } from '../components/pages/consumer-roles/consumer-roles-operations/consumer-roles-operations.component';
import { ConsumerRolesComponent } from '../components/pages/consumer-roles/consumer-roles.component';
import { ConsumerElementAccessComponent } from '../components/pages/consumer-roles/element-access/consumer-element-access.component';
import { ConsumerFormComponent } from '../components/pages/consumers/consumer-form/consumer-form.component';
import { ConsumerOperationComponent } from '../components/pages/consumers/consumer-operation/consumer-operation.component';
import { ConsumersComponent } from '../components/pages/consumers/consumers.component';
import { ErrorFormComponent } from '../components/pages/errors/error-form/error-form.component';
import { ErrorsComponent } from '../components/pages/errors/errors.component';
import { HealthMonitoringComponent } from '../components/pages/health-monitoring/health-monitoring.component';
import { HelpComponent } from '../components/pages/help/help.component';
import { HomeComponent } from '../components/pages/home/home.component';
import { InterfaceFormComponent } from '../components/pages/interfaces/interface-form/interface-form.component';
import { InterfacesComponent } from '../components/pages/interfaces/interfaces.component';
import { LogFormComponent } from '../components/pages/log-review/log-form/log-form.component';
import { LogReviewComponent } from '../components/pages/log-review/log-review.component';
import { ManageUserProfileComponent } from '../components/pages/manage-user-profile/manage-user-profile.component';
import { NotRegisterAdaptersFormComponent } from '../components/pages/not-register-adapters/not-register-adapters-form/not-register-adapters-form.component';
import { NotRegisterAdaptersComponent } from '../components/pages/not-register-adapters/not-register-adapters.component';
import { OperationFormComponent } from '../components/pages/operations/operation-form/operation-form.component';
import { OperationParameterHistoryComponent } from '../components/pages/operations/operation-parameter-history/operation-parameter-history.component';
import { ParametersHistoryFormComponent } from '../components/pages/operations/operation-parameter-history/parameters-history-form/parameters-history-form.component';
import { OperationParametersFormComponent } from '../components/pages/operations/operation-parameters/operation-parameters-form/operation-parameters-form.component';
import { OperationParametersComponent } from '../components/pages/operations/operation-parameters/operation-parameters.component';
import { OperationsComponent } from '../components/pages/operations/operations.component';
import { RegistriesComponent } from '../components/pages/registries/registries.component';
import { RegistryFormComponent } from '../components/pages/registries/registry-form/registry-form.component';
import { StatisticsComponent } from '../components/pages/statistics/statistics.component';
import { UserEditFormComponent } from '../components/pages/users/user-edit-form/user-edit-form.component';
import { UserShowFormComponent } from '../components/pages/users/user-show-form/user-show-form.component';
import { UsersComponent } from '../components/pages/users/users.component';
import { AdminPermissions } from '../permissions';
import { ROUTES } from './static-routes';
import { AccessReportNewComponent } from '../components/pages/access-report-new/access-report-new.component';
import { ConsumerProfilesFormComponent } from '../components/pages/consumer-profiles/consumer-profiles-form/consumer-profiles-form.component';
import { ConsumerSystemsFormComponent } from '../components/pages/consumer-systems/consumer-systems-form/consumer-systems-form.component';
import { ConsumerSystemCertificatesFormComponent } from '../components/pages/consumer-system-certificates/consumer-system-certificates-form/consumer-system-certificates-form.component';
import { ConsumerRequestOperationsFormComponent } from '../components/pages/consumer-system-certificates/consumer-request-operations/consumer-request-operations-form/consumer-request-operations-form.component';
import { ConsumerRequestsComponent } from '../components/pages/consumer-requests/consumer-requests.component';
import { ConsumerRequestsFormComponent } from '../components/pages/consumer-requests/consumer-requests-form/consumer-requests-form.component';
import { ConsumerAccessRequestsComponent } from '../components/pages/consumer-access-requests/consumer-access-requests.component';
import { ConsumerAccessRequestsFormComponent } from '../components/pages/consumer-access-requests/consumer-access-requests-form/consumer-access-requests-form.component';
import { ConsumerProfilesApprovalComponent } from '../components/pages/consumer-profiles-approval/consumer-profiles-approval.component';
import { ConsumerProfilesApprovalFormComponent } from '../components/pages/consumer-profiles-approval/consumer-profiles-approval-form/consumer-profiles-approval-form.component';
import { ConsumerRequestsApprovalComponent } from '../components/pages/consumer-requests-approval/consumer-requests-approval.component';
import { MyProfileComponent } from '../components/pages/my-profile/my-profile.component';

const routes: Routes = [
  TLRoute('', TempLayoutComponent, TLData(ROUTES.HOME, 'Начало', 'home'), [
    TLRoute('', HomeComponent, TLData(undefined, 'Начало', 'home', undefined, undefined, undefined, undefined, undefined, 'HomePage.md')),
    TLRoute(':ADM_TYPE/administrations', undefined, TLData(ROUTES.ADMINISTRATIONS, 'Администрации', 'account_balance', undefined, undefined, true, undefined, undefined, 'AdministrationsGrid.md'), [
      TLRoute('', AdministrationsComponent, TLData(undefined, 'Администрации', 'account_balance', undefined, undefined, undefined, undefined, undefined, 'AdministrationsGrid.md')),
      TLRoute('administration', AdministrationFormComponent, TLData(ROUTES.ADMINISTRATION_NEW, 'Нова', 'add', undefined, undefined, undefined, 'Администрация', undefined, 'AdministrationNew.md'), [], AdminPermissions.GLOBAL_ADMIN),
      TLRoute('administration/:ID', AdministrationFormComponent, TLData(ROUTES.ADMINISTRATION_SHOW, 'Преглед', 'remove_red_eye', false, undefined, undefined, 'Администрация', undefined, 'AdministrationView.md')),
      TLRoute('administration/:ID/edit', AdministrationFormComponent, TLData(ROUTES.ADMINISTRATION_EDIT, 'Редакция', 'edit', true, undefined, undefined, 'Администрация', undefined, 'AdministrationEdit.md'), [], AdminPermissions.GLOBAL_ADMIN),
      TLRoute(':ADM_ID/registries', undefined, TLData(ROUTES.REGISTRIES, 'Регистри', 'dashboard', undefined, undefined, true, undefined, undefined, 'RegistriesGrid.md'), [
        TLRoute('', RegistriesComponent, TLData(undefined, 'Регистри', 'dashboard', undefined, undefined, undefined, undefined, undefined, 'RegistriesGrid.md')),
        TLRoute('registry', RegistryFormComponent, TLData(ROUTES.REGISTER_NEW, 'Нов', 'add', undefined, undefined, undefined, 'Регистър', undefined, 'RegisterNew.md')),
        TLRoute('registry/:ID', RegistryFormComponent, TLData(ROUTES.REGISTER_SHOW, 'Преглед', 'remove_red_eye', false, undefined, undefined, 'Регистър', undefined, 'RegisterView.md')),
        TLRoute('registry/:ID/edit', RegistryFormComponent, TLData(ROUTES.REGISTER_EDIT, 'Редакция', 'edit', true, undefined, undefined, 'Регистър', undefined, 'RegisterEdit.md')),
        TLRoute(':REG_ID/adapters', undefined, TLData(ROUTES.ADAPTERS, 'Адаптери', 'developer_board', undefined, undefined, true, undefined, undefined, 'AdaptersGrid.md'), [
          TLRoute('', AdaptersComponent, TLData(undefined, 'Адаптери', 'developer_board', undefined, undefined, undefined, undefined, undefined, 'AdaptersGrid.md')),
          TLRoute('adapter/:ID', AdapterFormComponent, TLData(ROUTES.ADAPTER_SHOW, 'Преглед', 'remove_red_eye', false, undefined, undefined, 'Адаптер', undefined, 'AdapterView.md')),
          TLRoute('adapter/:ID/edit', AdapterFormComponent, TLData(ROUTES.ADAPTER_EDIT, 'Редакция', 'edit', true, undefined, undefined, 'Адаптер', undefined, 'AdapterEdit.md')),
          TLRoute('notRegisteredAdapters', NotRegisterAdaptersComponent, TLData(ROUTES.ADAPTERS_UNREGISTERED, 'Нерегистрирани aдаптери', 'refresh', undefined, undefined, undefined, undefined, undefined, 'AdapterRegistrationGrid.md'), [], AdminPermissions.GLOBAL_ADMIN),
          TLRoute('notRegisteredAdaptersForm/:ID', NotRegisterAdaptersFormComponent, TLData(ROUTES.ADAPTERS_UNREGISTERED_SHOW, 'Нерегистриран aдаптер - Преглед', 'remove_red_eye', false, undefined, undefined, undefined, undefined, 'AdapterRegistrationView.md'), [], AdminPermissions.GLOBAL_ADMIN),
          TLRoute('notRegisteredAdaptersForm/:ID/edit', NotRegisterAdaptersFormComponent, TLData(ROUTES.ADAPTERS_UNREGISTERED_EDIT, 'Нерегистриран aдаптер - Редакция', 'edit', true, undefined, undefined, undefined, undefined, 'AdapterRegistrationEdit.md'), [], AdminPermissions.GLOBAL_ADMIN),
          TLRoute('parametersFilter/:FILTER_FIELD', OperationParametersComponent, TLData(undefined, 'Параметри')),
          TLRoute(':ADA_ID/parameters', undefined, TLData(ROUTES.PARAMETERS, 'Параметри'), [
            TLRoute('', OperationParametersComponent, TLData(undefined, 'Параметри')),
            TLRoute('parameter/:ID', OperationParametersFormComponent, TLData(ROUTES.PARAMETERS_SHOW, 'Преглед', 'remove_red_eye', false)),
            TLRoute('parameter/:ID/edit', OperationParametersFormComponent, TLData(ROUTES.PARAMETERS_EDIT, 'Редакция', 'edit', true)),
          ]),
          TLRoute('parameterHistoryFilter/:FILTER_FIELD', OperationParameterHistoryComponent, TLData(undefined, 'История на параметри')),
          TLRoute('parameterHistory', undefined, TLData(ROUTES.ADAPTERS_PARAMETER_HISTORY, 'История на параметри'), [
            TLRoute('', OperationParameterHistoryComponent, TLData(undefined, 'История на параметри')),
            TLRoute('history/:ID', ParametersHistoryFormComponent, TLData(ROUTES.ADAPTERS_PARAMETER_HISTORY_HISTORY, 'История на параметър', undefined, false))
          ]),
          TLRoute(':ADA_ID/operations', undefined, TLData(ROUTES.OPERATIONS, 'Операции', 'receipt', undefined, undefined, true, undefined, undefined, 'OperationsGrid.md'), [
            TLRoute('', OperationsComponent, TLData(undefined, 'Операции', 'receipt', undefined, undefined, undefined, undefined, undefined, 'OperationsGrid.md')),
            TLRoute('operation/:ID', OperationFormComponent, TLData(ROUTES.OPERATION_SHOW, 'Преглед', 'remove_red_eye', false, undefined, undefined, 'Операция', undefined, 'OperationsView.md')),
            TLRoute(':OPER_ID/certificates', CertificateOperationsComponent, TLData(ROUTES.OPERATION_CERTIFICATES, 'Сертификати', 'card_membership', undefined, 'AdapterOperationId', true, undefined, undefined, 'OperationCertificates.md'))
          ]),
        ])
      ]),
      TLRoute(':ADM_ID/consumers', undefined, TLData(ROUTES.CONSUMERS, 'Консуматори', 'dns', undefined, undefined, true, undefined, undefined, 'ConsumersGrid.md'), [
        TLRoute('', ConsumersComponent, TLData(undefined, 'Консуматори', undefined, undefined, undefined, undefined, undefined, undefined, 'ConsumersGrid.md')),
        TLRoute('consumer', ConsumerFormComponent, TLData(ROUTES.CONSUMER_NEW, 'Нов', 'add', undefined, undefined, undefined, 'Консуматор', undefined, 'ConsumerNew.md'), [], AdminPermissions.GLOBAL_ADMIN),
        TLRoute('consumer/:ID', undefined, TLData(ROUTES.CONSUMER_SHOW, 'Преглед', 'remove_red_eye', undefined, undefined, undefined, undefined, undefined, 'ConsumerView.md'), [
          TLRoute('', ConsumerFormComponent, TLData(undefined, 'Преглед', 'remove_red_eye', false, undefined, undefined, 'Консуматор', undefined, 'ConsumerView.md')),
          TLRoute('operations', ConsumerOperationComponent, TLData(undefined, 'Операции', undefined, false, undefined, undefined, 'Консуматор', undefined, 'OperationCertificates.md')),
        ]),
        TLRoute('consumer/:ID/edit', ConsumerFormComponent, TLData(ROUTES.CONSUMER_EDIT, 'Редакция', 'edit', true, undefined, undefined, 'Консуматор', undefined, 'ConsumerEdit.md'), [], AdminPermissions.GLOBAL_ADMIN),
        TLRoute(':CON_ID/certificates', undefined, TLData(ROUTES.CERTIFICATES, 'Сертификати', 'card_membership', undefined, undefined, true, undefined, undefined, 'CertificatesGrid.md'), [
          TLRoute('', CertificatesComponent, TLData(undefined, 'Сертификати', undefined, undefined, undefined, undefined, undefined, undefined, 'CertificatesGrid.md')),
          TLRoute('certificate', CertificateFormComponent, TLData(ROUTES.CERTIFICATE_NEW, 'Нов', 'add', undefined, undefined, undefined, 'Сертификат', undefined, 'CertificateNew.md'), [], AdminPermissions.GLOBAL_ADMIN),
          TLRoute('certificate/:ID', CertificateFormComponent, TLData(ROUTES.CERTIFICATE_SHOW, 'Преглед', 'remove_red_eye', false, undefined, undefined, 'Сертификат', undefined, 'CertificateView.md')),
          TLRoute('certificate/:ID/edit', CertificateFormComponent, TLData(ROUTES.CERTIFICATE_EDIT, 'Редакция', 'edit', true, undefined, undefined, 'Сертификат', undefined, 'CertificateEdit.md'), [], AdminPermissions.GLOBAL_ADMIN),
          TLRoute(':CER_ID/operations', undefined, TLData(ROUTES.CERTIFICATE_OPERATIONS, 'Операции на сертификат', 'receipt', undefined, undefined, true, undefined, undefined, 'OperationCertificates.md'), [
            TLRoute('', CertificateOperationsComponent, TLData(undefined, 'Операции на сертификат', 'receipt', undefined, undefined, undefined, undefined, undefined, 'OperationCertificates.md')),
            TLRoute('operation/:ID', CertificateOperationFormComponent, TLData(ROUTES.CERTIFICATE_OPERATION_SHOW, 'Преглед', 'remove_red_eye', false, undefined, undefined, 'Операция на сертификат', undefined, 'CeritifcateOperationView.md')),
            TLRoute('access/:ID', AccessFormComponent, TLData(ROUTES.CERTIFICATE_OPERATION_ACCESS, 'Добавяне на достъп', 'add', undefined, undefined, undefined, undefined, undefined, 'CeritifcateOperationNew.md')),
            TLRoute('access/:ID/:CertificeteId', AccessEditFormComponent, TLData(ROUTES.CERTIFICATE_OPERATION_ACCESS_EDIT, 'Редактиране на достъп', 'edit', undefined, undefined, undefined, undefined, undefined, 'CeritifcateOperationEdit.md')),
            TLRoute(':FILTER_FIELD/elementsAccessFilter', ElementAccessComponent, TLData(ROUTES.CERTIFICATE_OPERATION_ELEMENTS_ACCESS_FILTER, 'Елементи на операция', 'horizontal_split', undefined, undefined, undefined, undefined, undefined, 'CeritifcateOperationElementAccessGrid.md')),
            TLRoute('elementsAccess', undefined, TLData(ROUTES.CERTIFICATE_OPERATION_ELEMENTS_ACCESS, 'Елементи на операция', 'horizontal_split', undefined, undefined, undefined, undefined, undefined, 'CeritifcateOperationElementAccessGrid.md'), [
              TLRoute('', ElementAccessComponent, TLData(undefined, 'Елементи на операция', undefined, undefined, undefined, undefined, undefined, undefined, 'CeritifcateOperationElementAccessGrid.md')),
            ]),
          ]),
        ]),
      ]),
      TLRoute(':ADM_ID/users', undefined, TLData(ROUTES.USERS, 'Потребители', 'supervised_user_circle', undefined, undefined, true, undefined, undefined, 'UsersGrid.md'), [
        TLRoute('', UsersComponent, TLData(undefined, 'Потребители', undefined, undefined, undefined, undefined, undefined, undefined, 'UsersGrid.md')),
        TLRoute('user/:ID', UserShowFormComponent, TLData(ROUTES.USER_SHOW, 'Преглед', 'remove_red_eye', false, undefined, undefined, 'Потребител', undefined, 'UserView.md')),
        TLRoute('user/:ID/edit', UserEditFormComponent, TLData(ROUTES.USER_EDIT, 'Редакция', 'edit', true, undefined, undefined, 'Потребител', undefined, 'UserEdit.md')),
      ], AdminPermissions.GLOBAL_ADMIN),
      TLRoute(':ADM_ID/interfaces', undefined, TLData(ROUTES.INTERFACES, 'Интерфейси', 'usb', undefined, undefined, true, undefined, undefined, 'InterfacesGrid.md'), [
        TLRoute('', InterfacesComponent, TLData(undefined, 'Интерфейси', undefined, undefined, undefined, undefined, undefined, undefined, 'InterfacesGrid.md')),
        TLRoute('interface/:ID', InterfaceFormComponent, TLData(ROUTES.INTERFACES_SHOW, 'Преглед', 'remove_red_eye', false, undefined, undefined, 'Интерфейс', undefined, 'InterfacesView.md')),
        TLRoute('interface/:ID/edit', InterfaceFormComponent, TLData(ROUTES.INTERFACES_EDIT, 'Редакция', 'edit', true, undefined, undefined, 'Интерфейс', undefined, 'InterfacesEdit.md'))
      ])
    ]),
    TLRoute('settings', undefined, TLData(ROUTES.SETTINGS, 'Настройки', 'build', undefined, undefined, undefined, undefined, undefined, undefined, true), [
      TLRoute('logs', undefined, TLData(ROUTES.LOGS, 'Журнал', 'history', undefined, undefined, undefined, undefined, undefined, 'Logs.md'), [
        TLRoute('', LogReviewComponent, TLData(undefined, 'Журнал', 'history', undefined, undefined, undefined, undefined, undefined, 'Logs.md')),
        TLRoute('log/:ID', LogFormComponent, TLData(ROUTES.LOG_VIEW, 'Журнал', 'remove_red_eye', false, undefined, undefined, undefined, undefined, 'LogsView.md'))
      ], AdminPermissions.GLOBAL_ADMIN),
      TLRoute('administration-types', undefined, TLData(ROUTES.ADMINISTRATIONS_TYPES, 'Типове администрации', 'label', undefined, undefined, undefined, undefined, undefined, 'AdministrationTypesGrid.md'), [
        TLRoute('', AdministrationTypesComponent, TLData(undefined, 'Типове администрации', 'label', undefined, undefined, undefined, undefined, undefined, 'AdministrationTypesGrid.md')),
        TLRoute('administration-type', AdministrationTypeFormComponent , TLData(ROUTES.ADMINISTRATIONS_TYPES_NEW, 'Нов', 'add', undefined, undefined, undefined, 'Тип администрация', undefined, 'AdministrationTypeNew.md')),
        TLRoute('administration-type/:ID', AdministrationTypeFormComponent, TLData(ROUTES.ADMINISTRATIONS_TYPES_SHOW, 'Преглед', 'remove_red_eye', false, undefined, undefined, 'Тип администрация', undefined, 'AdministrationTypeView.md')),
        TLRoute('administration-type/:ID/edit', AdministrationTypeFormComponent, TLData(ROUTES.ADMINISTRATIONS_TYPES_EDIT, 'Редакция', 'edit', true, undefined, undefined, 'Тип администрация', undefined, 'AdministrationTypeEdit.md'))
      ], AdminPermissions.GLOBAL_ADMIN),
      TLRoute('auditFilter/:FILTER_FIELD', AuditComponent, TLData(ROUTES.AUDIT_FILTER, 'Одит', 'menu_book')),
      TLRoute(':TABLE_NAME/audit', undefined, TLData(ROUTES.AUDIT, 'Одит', 'menu_book', undefined, undefined, true, undefined, undefined, 'Audit.md'), [
        TLRoute('', AuditComponent, TLData(undefined, 'Одит', undefined, undefined, undefined, undefined, undefined, undefined, 'Audit.md')),
        TLRoute('audit/:ID', AuditFormComponent, TLData(ROUTES.AUDIT_VIEW, 'Преглед', 'remove_red_eye', false, undefined, undefined, 'Одит на таблица', undefined, 'Audit.md')),
        TLRoute('historyFilter/:FILTER_FIELD', AuditHistoryComponent, TLData(ROUTES.AUDIT_HISTORY_FILTER, 'История на таблици', 'history')),
        TLRoute('history', undefined, TLData(ROUTES.AUDIT_HISTORY, 'История на таблици', 'library_books'), [
          TLRoute('', AuditHistoryComponent, TLData(undefined, 'История на таблици')),
          TLRoute('history/:ID', AuditHistoryFormComponent, TLData(ROUTES.AUDIT_HISTORY_SHOW, 'История на таблица', 'remove_red_eye', false)),
        ]),
        TLRoute('healthMonitoring', HealthMonitoringComponent, TLData(undefined, 'Мониторинг'))
      ], AdminPermissions.GLOBAL_ADMIN),
      TLRoute('systemErrors', undefined, TLData(ROUTES.SYSTEM_ERRORS, 'Системни грешки'), [
        TLRoute('', SystemErrorsComponent, TLData(undefined, 'Системни грешки')),
        TLRoute('systemError/:ID', SystemErrorsFormComponent, TLData(ROUTES.SYSTEM_ERROR_SHOW, 'Системна грешка', 'remove_red_eye', false)),
      ]),
      TLRoute('userActions', undefined, TLData(ROUTES.USER_ACTIONS, 'Потребителски действия', 'folder_shared'), [
        TLRoute('', UserActionsComponent, TLData(undefined, 'Потребителски действия')),
        TLRoute('userAction/:ID', UserActionFormComponent, TLData(ROUTES.USER_ACTION_VIEW, 'Потребителско действие', 'remove_red_eye', false)),
      ])
    ], AdminPermissions.GLOBAL_ADMIN),
    TLRoute('consumer-roles', undefined, TLData(ROUTES.CONSUMER_ROLES, 'Роли на консуматори', 'ballot', undefined, undefined, undefined, undefined, undefined, 'ConsumerRolesGrid.md'), [
      TLRoute('', ConsumerRolesComponent, TLData(undefined, 'Роли на консуматори', undefined, undefined, undefined, undefined, undefined, undefined, 'ConsumerRolesGrid.md')),
      TLRoute('consumer-role', ConsumerRolesFormComponent, TLData(ROUTES.CONSUMER_ROLE_NEW, 'Нова', 'add', undefined, undefined, undefined, 'Роля на консуматор', undefined, 'ConsumerRoleNew.md')),
      TLRoute('consumer-role/:ID', ConsumerRolesFormComponent, TLData(ROUTES.CONSUMER_ROLE_SHOW, 'Преглед', 'remove_red_eye', false, undefined, undefined, 'Роля на консуматор', undefined, 'ConsumerRoleView.md')),
      TLRoute('consumer-role/:ID/edit', ConsumerRolesFormComponent, TLData(ROUTES.CONSUMER_ROLE_EDIT, 'Редакция', 'edit', true, undefined, undefined, 'Роля на консуматор', undefined, 'ConsumerRoleEdit.md')),
      TLRoute(':ROLE_ID/operations', undefined, TLData(ROUTES.CONSUMER_ROLES_CONSUMER_ROLE_OPERATIONS, 'Операции за роля', 'receipt', undefined, undefined, undefined, undefined, undefined, 'ConsumerRoleOperationsGrid.md'), [
        TLRoute('', ConsumerRolesOperationsComponent, TLData(undefined, 'Роля на консуматор', undefined, false, undefined, undefined, undefined, undefined, 'ConsumerRoleOperationsGrid.md')),
        TLRoute('elementsAccess', undefined, TLData(ROUTES.CONSUMER_ROLE_OPERATIONS_ELEMENTS_ACCESS, 'Елементи на операция'), [
          TLRoute('', ConsumerElementAccessComponent, TLData(undefined, 'Елементи на операция')),
        ]),
        TLRoute('access', ConsumerAccessFormComponent, TLData(ROUTES.CONSUMER_ROLE_ACCESS_ROLEID, 'Достъп до операция', 'add', true, undefined, undefined, undefined, undefined, 'ConsumerRoleOperationNew.md')),
        TLRoute('access/:ID/edit', ConsumerAccessEditFormComponent, TLData(ROUTES.CONSUMER_ROLE_ACCESS_ID_ROLEID, 'Достъп до операция', 'edit', true, undefined, undefined, undefined, undefined, 'ConsumerRoleOperationEdit.md')),
      ])
    ], AdminPermissions.GLOBAL_ADMIN),
    TLRoute('errors', undefined, TLData(ROUTES.ERRORS, 'Грешки', 'error_outline'), [
      TLRoute('', ErrorsComponent, TLData(undefined, 'Грешки', 'error_outline')),
      TLRoute('error/:ID', ErrorFormComponent, TLData(ROUTES.ERROR_VIEW, 'Грешка', 'remove_red_eye', false , undefined, undefined, 'Грешка'))
    ]),
    TLRoute('accessReport', AccessReportNewComponent, TLData(ROUTES.ACCESS_REPORT, 'Справка за достъп', 'business', undefined, undefined, undefined, undefined, undefined, 'AccessReport.md')),
    TLRoute('manageUser', ManageUserProfileComponent, TLData(ROUTES.USER_PROFILE, 'Настройки на профил', 'build')),
    TLRoute('statistics', StatisticsComponent, TLData(ROUTES.STATISTICS, 'Статистика', 'bar_chart', undefined, undefined, undefined, undefined, undefined, 'Statistics.md')),
    TLRoute('help/:MARKED', HelpComponent, TLData(ROUTES.HELP, 'Помощ', 'help')),
    TLRoute('consumer-systems', undefined, TLData(ROUTES.CONSUMER_SYSTEMS, 'Заявки на системи', 'system_update_alt', undefined, undefined, undefined, undefined, undefined, 'ConsumerSystemsGrid.md'), [
      TLRoute('', ConsumerSystemsComponent, TLData(undefined, 'Заявки на системи', undefined, undefined, undefined, undefined, undefined, undefined, 'ConsumerSystemsGrid.md')),
      TLRoute('consumer-system/:ID', ConsumerSystemsFormComponent, TLData(ROUTES.CONSUMER_SYSTEMS_SHOW, 'Заявкa на системa', 'remove_red_eye', false , undefined, undefined, 'Заявкa на системa', undefined, 'ConsumerSystemView.md')),
      TLRoute('consumer-system/:ID/edit', ConsumerSystemsFormComponent, TLData(ROUTES.CONSUMER_SYSTEMS_EDIT, 'Заявкa на системa', 'edit', true , undefined, undefined, 'Заявкa на системa', undefined, 'ConsumerSystemEdit.md')),
      TLRoute(':CON_SYS_ID/consumer-system-certificates', undefined, TLData(ROUTES.CONSUMER_SYSTEM_CERTIFICATE, 'Сертификати', 'card_membership', undefined, undefined, true, undefined, undefined, 'ConsumerSystemCertificatesGrid.md'), [
        TLRoute('', ConsumerSystemCertificatesComponent, TLData(undefined, 'Сертификати', 'card_membership', undefined, undefined, undefined, undefined, undefined, 'ConsumerSystemCertificatesGrid.md')), // todo: change show edit
        TLRoute('consumer-system-certificate/:ID', ConsumerSystemCertificatesFormComponent, TLData(ROUTES.CONSUMER_SYSTEM_CERTIFICATES_SHOW, 'Преглед', 'remove_red_eye', false, undefined, undefined, 'Сертификат', undefined, 'ConsumerSystemCertificateView.md')),
        TLRoute('consumer-system-certificate/:ID/edit', ConsumerSystemCertificatesFormComponent, TLData(ROUTES.CONSUMER_SYSTEM_CERTIFICATES_EDIT, 'Редакция', 'edit', true, undefined, undefined, 'Сертификат', undefined, 'ConsumerSystemCertificateEdit.md')),
        TLRoute(':CON_REQ_ID/consumer-request-operations', undefined, TLData(ROUTES.CONSUMER_REQUEST_OPERATIONS, 'Операции', 'receipt', undefined, undefined, true), [
          TLRoute('', ConsumerRequestOperationsComponent, TLData(undefined, 'Операции', 'receipt')), // todo: change show edit
            TLRoute('consumer-request-operation/:ID', ConsumerRequestOperationsFormComponent, TLData(ROUTES.CONSUMER_REQUEST_OPERATIONS_SHOW, 'Преглед', 'remove_red_eye', false, undefined, undefined, 'Заявка за операция')),
            TLRoute('consumer-request-operation/:ID/edit', ConsumerRequestOperationsFormComponent, TLData(ROUTES.CONSUMER_REQUEST_OPERATIONS_EDIT, 'Редакция', 'edit', true , undefined, undefined, 'Заявка за операция'))
        ]),
      ]),
    ]),
    TLRoute('consumer-profiles-users', undefined, TLData(ROUTES.CONSUMER_PROFILES_USERS, 'Представители', 'text_snippet', undefined, undefined, undefined, undefined, undefined, 'ConsumerProfilesGrid.md'), [
      TLRoute('', ConsumerProfilesComponent, TLData(undefined, 'Заявки от консуматори', undefined, undefined, undefined, undefined, undefined, undefined, 'ConsumerProfilesGrid.md')),
      TLRoute('consumer-profiles-user/:ID', ConsumerProfileUsersFormComponent, TLData(ROUTES.CONSUMER_PROFILES_USERS_SHOW, 'Представител', 'remove_red_eye', false , undefined, undefined, 'Представител', undefined, 'ConsumerProfileView.md')),
      TLRoute('consumer-profiles-user/:ID/edit', ConsumerProfileUsersFormComponent, TLData(ROUTES.CONSUMER_PROFILES_USERS_EDIT, 'Представител', 'edit', true , undefined, undefined, 'Представител', undefined, 'ConsumerProfileEdit.md'), [], AdminPermissions.GLOBAL_ADMIN),
    ]),
    TLRoute('consumer-profiles-approval', undefined, TLData(ROUTES.CONSUMER_PROFILES_APPROVAL, 'Профили за одобрение', 'how_to_reg', undefined, undefined, undefined, undefined, undefined, 'NewConsumerProfilesGrid.md'), [
      TLRoute('', ConsumerProfilesApprovalComponent, TLData(undefined, 'Профили за одобрение', undefined, undefined, undefined, undefined, undefined, undefined, 'NewConsumerProfilesGrid.md')),
      TLRoute('consumer-profile-approval/:ID', ConsumerProfilesApprovalFormComponent, TLData(ROUTES.CONSUMER_PROFILES_APPROVAL_SHOW, 'Профил консуматор за одобрение', 'remove_red_eye', false , undefined, undefined, 'Профил консуматор')),
      TLRoute('consumer-profile-approval/:ID/edit', ConsumerProfilesApprovalFormComponent, TLData(ROUTES.CONSUMER_PROFILES_APPROVAL_EDIT, 'Профил консуматор за одобрение', 'edit', true , undefined, undefined, 'Профил консуматор'), [], AdminPermissions.ADMIN),
  ], AdminPermissions.GLOBAL_ADMIN),
  TLRoute('consumer-requests-approval', undefined, TLData(ROUTES.CONSUMER_REQUEST_APPROVAL, 'Заявки за одобрение', 'text_snippet', undefined, undefined, undefined, undefined, undefined, 'NewConsumerRequestsGrid.md'), [
    TLRoute('', ConsumerRequestsApprovalComponent, TLData(undefined, 'Заявки за одобрение', undefined, undefined, undefined, undefined, undefined, undefined, 'NewConsumerRequestsGrid.md')),
    TLRoute('consumer-requests-approval/:ID', ConsumerProfilesApprovalFormComponent, TLData(ROUTES.CONSUMER_PROFILES_APPROVAL_SHOW, 'Профил консуматор за одобрение', 'remove_red_eye', false , undefined, undefined, 'Профил консуматор')),
    TLRoute('consumer-requests-approval/:ID/edit', ConsumerProfilesApprovalFormComponent, TLData(ROUTES.CONSUMER_PROFILES_APPROVAL_EDIT, 'Профил консуматор за одобрение', 'edit', true , undefined, undefined, 'Профил консуматор'), [], AdminPermissions.ADMIN),
  ]),
  TLRoute('consumer-profiles', undefined, TLData(ROUTES.CONSUMER_PROFILES, 'Профили на консуматори', 'account_circle', undefined, undefined, undefined, undefined, undefined, 'ConsumerProfilesGrid.md'), [
    TLRoute('', ConsumerProfilesComponent, TLData(undefined, 'Профили на консуматори', undefined, undefined, undefined, undefined, undefined, undefined, 'ConsumerProfilesGrid.md')),
    TLRoute('consumer-profile/:ID', ConsumerProfilesFormComponent, TLData(ROUTES.CONSUMER_PROFILES_SHOW, 'Профил консуматор', 'remove_red_eye', false , undefined, undefined, 'Профил консуматор')),
    TLRoute('consumer-profile/:ID/edit', ConsumerProfilesFormComponent, TLData(ROUTES.CONSUMER_PROFILES_EDIT, 'Профил консуматор', 'edit', true , undefined, undefined, 'Профил консуматор'), [], AdminPermissions.GLOBAL_ADMIN),
    TLRoute(':CON_PROF_ID/consumer-requests', undefined, TLData(ROUTES.CONSUMER_REQUEST, 'Заявки', 'text_snippet', undefined, undefined, true, undefined, undefined, 'ConsumerRequestsGrid.md'), [
      TLRoute('', ConsumerRequestsComponent, TLData(undefined, 'Заявки', 'receipt', undefined, undefined, undefined, undefined, undefined, 'ConsumerRequestsGrid.md')), // todo: change show edit
        TLRoute('consumer-requests/:ID', ConsumerRequestsFormComponent, TLData(ROUTES.CONSUMER_REQUESTS_SHOW, 'Преглед', 'remove_red_eye', false, undefined, undefined, 'Заявка', undefined, 'ConsumerRequestView.md')),
        TLRoute('consumer-requests/:ID/edit', ConsumerRequestsFormComponent, TLData(ROUTES.CONSUMER_REQUESTS_EDIT, 'Редакция', 'edit', true , undefined, undefined, 'Заявка', undefined, 'ConsumerRequestEdit.md')),
        TLRoute(':CON_ACC_ID/consumer-access-requests', undefined, TLData(ROUTES.CONSUMER_ACCESS_REQUESTS, 'Заявки за операции', 'receipt', undefined, undefined, true, undefined, undefined, 'ConsumerRequestOperationsGrid.md'), [
          TLRoute('', ConsumerAccessRequestsComponent, TLData(undefined, 'Заявки операции', 'receipt', undefined, undefined, undefined, undefined, undefined, 'ConsumerRequestOperationsGrid.md')), // todo: change show edit
            TLRoute('consumer-request-operation/:ID', ConsumerAccessRequestsFormComponent, TLData(ROUTES.CONSUMER_ACCESS_REQUESTS_SHOW, 'Преглед', 'remove_red_eye', false, undefined, undefined, 'Заявка за операция', undefined, 'ConsumerRequestOperationView.md')),
            TLRoute('consumer-request-operation/:ID/edit', ConsumerAccessRequestsFormComponent, TLData(ROUTES.CONSUMER_ACCESS_REQUESTS_EDIT, 'Редакция', 'edit', true , undefined, undefined, 'Заявка за операция', undefined, 'ConsumerRequestOperationEdit.md'))
        ]),
    ]),
  ], AdminPermissions.ADMIN),
  TLRoute('my-profile', undefined, TLData(ROUTES.MYPROFILE, 'Моят профил', 'person'), [
    TLRoute('', MyProfileComponent, TLData(undefined, 'Моят профил', 'person')),
  ]),
    // TLRoute('userAction/:ID', UserActionFormComponent, TLData(ROUTES.USER_ACTION_VIEW, 'Потребителско действие', 'remove_red_eye', false)),
  ])
];

@NgModule({
  imports: [RouterModule.forChild(routes)],
  exports: [RouterModule],
})
export class AdminRoutingModule extends TLRoutingModule {

  constructor() {
    super(routes, AUTH_PATHS.AUTHENTICATED);
  }
}
