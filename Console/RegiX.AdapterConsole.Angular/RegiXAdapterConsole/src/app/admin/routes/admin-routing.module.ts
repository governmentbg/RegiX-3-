import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { LayoutComponent } from '../components/pages/layout/layout.component';
import { HomeComponent } from '../components/pages/home/home.component';
import { UsersComponent } from '../components/pages/users/users.component';
import { RolesComponent } from '../components/pages/roles/roles.component';
import { UserFormComponent } from '../components/pages/users/user-form/user-form.component';
import { RoleFormComponent } from '../components/pages/roles/role-form/role-form.component';
import { NgxPermissionsGuard } from 'ngx-permissions';
import { InsufficientPrivilegesComponent } from '../components/pages/insufficient-privileges/insufficient-privileges.component';
import { OperationCallsComponent } from '../components/pages/operation-calls/operation-calls.component';
import { OperationCallComponent } from '../components/pages/operation-calls/operation-call/operation-call.component';
import { AdapterOperationsFormComponent } from '../components/pages/adapter-operations/adapter-operations-form/adapter-operations-form.component';
import { AdapterOperationsComponent } from '../components/pages/adapter-operations/adapter-operations.component';
import { ReturnedCallsComponent } from '../components/pages/returned-calls/returned-calls.component';
import { ReturnedCallComponent } from '../components/pages/returned-calls/returned-call/returned-call.component';
import { MyOperationCallsComponent } from '../components/pages/my-operation-calls/my-operation-calls.component';
import { MyOperationCallComponent } from '../components/pages/my-operation-calls/my-operation-call/my-operation-call.component';
import { TLRoute, TLData, TLRoutingModule } from '@tl/tl-common';
import { ROUTES } from './static-routes';
import { OperationPersistanceComponent } from '../components/pages/operation-persistance/operation-persistance.component';

export const ADMIN_MODULE_PATH = 'admin';

const routes: Routes = [
  TLRoute('', LayoutComponent, TLData(ROUTES.HOME, 'Начало', 'home'), [
    TLRoute('', HomeComponent, TLData(undefined, 'Начало', 'home')),
    TLRoute('unauthorized', InsufficientPrivilegesComponent, TLData(ROUTES.UNAUTHORIZED, 'Нямате необходимите права')),
    TLRoute('operation-calls', undefined, TLData(ROUTES.OPERATION_CALLS, 'Чакащи услуги', 'schedule'), [
      TLRoute('', OperationCallsComponent, TLData(undefined, 'Чакащи услуги')),
      TLRoute('operation-call', OperationCallComponent, TLData(ROUTES.OPERATION_CALL, 'Чакаща услуга')),
      TLRoute('operation-call/:ID', OperationCallComponent, TLData(ROUTES.OPERATION_CALL_VIEW, 'Преглед', 'remove_red_eye', false)),
      TLRoute('operation-call/:ID/edit', OperationCallComponent, TLData(ROUTES.OPERATION_CALL_EDIT, 'Редакция', 'edit', true)),
    ]),
    TLRoute('my-operation-calls', undefined, TLData(ROUTES.MY_OPERATION_CALLS, 'Mоите услуги', 'receipt'), [
      TLRoute('', MyOperationCallsComponent, TLData(undefined, 'Mоите услуги')),
      TLRoute('my-operation-call', MyOperationCallComponent, TLData(ROUTES.MY_OPERATION_CALL, 'Нова услуга')),
      TLRoute('my-operation-call/:ID', MyOperationCallComponent, TLData(ROUTES.MY_OPERATION_CALL_VIEW, 'Преглед', 'remove_red_eye', false)),
      TLRoute('my-operation-call/:ID/edit', MyOperationCallComponent, TLData(ROUTES.MY_OPERATION_CALL_EDIT, 'Редакция', 'edit', true)),
    ]),
    TLRoute('adapter-operations', undefined, TLData(ROUTES.ADAPTER_OPERATIONS, 'Адаптер услуги'), [
      TLRoute('', AdapterOperationsComponent, TLData(undefined, 'Адаптер услуги')),
      TLRoute('adapter-operation', AdapterOperationsFormComponent, TLData(ROUTES.ADAPTER_OPERATION, 'Адаптер услуга')),
      TLRoute('adapter-operation/:ID', AdapterOperationsFormComponent, TLData(ROUTES.ADAPTER_OPERATION_VIEW, 'Адаптер услуга', undefined, false)),
      TLRoute('adapter-operation/:ID/edit', AdapterOperationsFormComponent, TLData(ROUTES.ADAPTER_OPERATION_EDIT, 'Адаптер услуга', undefined, true)),
    ]),
    TLRoute('users', undefined, TLData(ROUTES.USERS, 'Потребители', 'person'), [
      TLRoute('', UsersComponent, TLData(undefined, 'Потребители', 'person')),
      TLRoute('user', UserFormComponent, TLData(ROUTES.USER, 'Нова', 'add', undefined, undefined, undefined, 'Потребител')),
      TLRoute('user/:ID', UserFormComponent, TLData(ROUTES.USER_VIEW, 'Преглед', 'remove_red_eye', false, undefined, undefined, 'Потребител')),
      TLRoute('user/:ID/edit', UserFormComponent, TLData(ROUTES.USER_EDIT, 'Редакция', 'edit', true, undefined, undefined, 'Потребител')),
    ]),
    TLRoute('roles', undefined, TLData(ROUTES.ROLES, 'Роли', 'group'), [
      TLRoute('', RolesComponent, TLData(undefined, 'Роли')),
      TLRoute('role', RoleFormComponent, TLData(ROUTES.ROLE, 'Нова', 'add', undefined, undefined, undefined, 'Роля')),
      TLRoute('role/:ID', RoleFormComponent, TLData(ROUTES.ROLE_VIEW, 'Преглед', 'remove_red_eye', false, undefined, undefined, 'Роля')),
      TLRoute('role/:ID/edit', RoleFormComponent, TLData(ROUTES.ROLE_EDIT, 'Редакция', 'edit', true, undefined, undefined, 'Роля')),
    ]),
    TLRoute('returned-calls', undefined, TLData(ROUTES.RETURNED_CALLS, 'Приключени услуги', 'history'), [
      TLRoute('', ReturnedCallsComponent, TLData(undefined, 'Приключени услуги')),
      TLRoute('returned-call/:ID', ReturnedCallComponent, TLData(ROUTES.RETURNED_CALL, 'Преглед', 'remove_red_eye')),
      TLRoute('returned-call-by-call-id/:API_CALL_ID', ReturnedCallComponent, TLData(ROUTES.RETURNED_CALL_BY_CALL_ID, 'Преглед', 'remove_red_eye'))
    ]),
    TLRoute('settings', undefined, TLData(ROUTES.SETTINGS, 'Настройки', 'build')),
    TLRoute('operations-persistance', OperationPersistanceComponent, TLData(ROUTES.OPERATION_PERSISTANCE, 'Чакащи подпис', 'card_membership'))
  ]),
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
