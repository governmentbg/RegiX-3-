import { ConsumerProfilesUsersApprovedComponent } from './../components/consumer-profiles-users-approved/consumer-profiles-users-approved.component';
import { ConsumerProfileComponent } from './../components/consumer-profile/consumer-profile.component';
import { NgModule } from '@angular/core';
import { TLRoute, TLData, TLRoutingModule } from '@tl/tl-common';
import { Routes, RouterModule } from '@angular/router';
import { CONSUMER_ROUTES } from './consumer-static-routes';
import { ProfileComponent } from '../components/profile/profile.component';
import { SystemsComponent } from '../components/systems/systems.component';
import { ConsumerLayoutComponent } from '../components/consumer-layout/consumer-layout.component';
import { SystemFormComponent } from '../components/systems/system-form/system-form.component';
import { CertificatesComponent } from '../components/certificates/certificates.component';
import { CertificateFormComponent } from '../components/certificates/certificate-form/certificate-form.component';
import { RequestsComponent } from '../components/requests/requests.component';
import { AccessRequestsComponent } from '../components/access-requests/access-requests.component';
import { AccessRequestsFormComponent } from '../components/access-requests/access-requests-form/access-requests-form.component';
import { RequestFormComponent } from '../components/requests/request-form/request-form.component';
import { CertificateOperationAccessComponent } from '../components/certificate-operation-access/certificate-operation-access.component';
import { ConsumerProfileUserComponent } from '../components/consumer-profile-user/consumer-profile-user.component';
import { ConsumerProfilesUsersApprovedFormComponent } from '../components/consumer-profiles-users-approved/consumer-profiles-users-approved-form/consumer-profiles-users-approved-form.component';


const routes: Routes = [
  TLRoute('', ConsumerLayoutComponent, TLData(undefined, 'Профил на консуматор', 'person'), [
    TLRoute('', ProfileComponent, TLData(CONSUMER_ROUTES.HOME, 'Профил на консуматор', 'person')),
    TLRoute('profile', ProfileComponent, TLData(CONSUMER_ROUTES.PROFILE, 'Консуматор', 'dns'), [
    ]),

    TLRoute('systems', undefined, TLData(CONSUMER_ROUTES.SYSTEMS, 'Системи', 'dns'), [
      TLRoute('', SystemsComponent, TLData(undefined, 'Системи', 'dns')),
      TLRoute('system', SystemFormComponent, TLData(CONSUMER_ROUTES.SYSTEM_NEW, 'Нова', 'add', undefined, undefined, undefined, 'Система')),
      TLRoute('system/:ID', SystemFormComponent, TLData(CONSUMER_ROUTES.SYSTEM_SHOW, 'Преглед', 'remove_red_eye', false, undefined, undefined, 'Система')),
      //TLRoute('system/:ID/edit', SystemFormComponent, TLData(CONSUMER_ROUTES.SYSTEM_EDIT, 'Редакция', 'edit', true, undefined, undefined, 'Система')),
      TLRoute(':SYS_ID/certificates', undefined, TLData(CONSUMER_ROUTES.CERTIFICATES, 'Сертификати', 'card_membership', undefined, undefined, true), [
          TLRoute('', CertificatesComponent, TLData(undefined, 'Сертификати', 'dns')),
          TLRoute('certificate', CertificateFormComponent, TLData(CONSUMER_ROUTES.CERTIFICATE_NEW, 'Нов', 'add', undefined, undefined, undefined, 'Сертификат')),
          TLRoute('certificate/:ID', CertificateFormComponent, TLData(CONSUMER_ROUTES.CERTIFICATE_SHOW, 'Преглед', 'remove_red_eye', false, undefined, undefined, 'Сертификат')),
          //TLRoute('certificate/:ID/edit', CertificateFormComponent, TLData(CONSUMER_ROUTES.CERTIFICATE_EDIT, 'Редакция', 'edit', true, undefined, undefined, 'Сертификат'))
          TLRoute(':CER_ID/access-requests', undefined, TLData(CONSUMER_ROUTES.ACCESS_REQUESTS_CERT, 'Операции', 'receipt', undefined, undefined, true), [
            TLRoute('', AccessRequestsComponent, TLData(undefined, 'Операции', 'receipt')),
            TLRoute('request-operation', AccessRequestsFormComponent, TLData(CONSUMER_ROUTES.ACCESS_REQUESTS_NEW, 'Нова', 'add', false, undefined, undefined, 'Операция')),
            TLRoute('request-operation/:ID', AccessRequestsFormComponent, TLData(CONSUMER_ROUTES.ACCESS_REQUESTS_SHOW, 'Преглед', 'remove_red_eye', false, undefined, undefined, 'Операция')),
            TLRoute('request-operation/:ID/edit', AccessRequestsFormComponent, TLData(CONSUMER_ROUTES.ACCESS_REQUESTS_EDIT, 'Редакция', 'edit', true , undefined, undefined, 'Операция'))
          ]),
          TLRoute(':CER_ID/certificate-operation-access', undefined, TLData(CONSUMER_ROUTES.CERTIFICATE_OPERATION_ACCCESS, 'Операции с получен достъп', 'receipt', undefined, undefined, true,undefined,true), [
            TLRoute('', CertificateOperationAccessComponent, TLData(undefined, 'Операции', 'receipt')),
            TLRoute('certificate-operation-access/:ID', AccessRequestsFormComponent, TLData(CONSUMER_ROUTES.CERTIFICATE_OPERATION_ACCCESS_SHOW, 'Преглед', 'remove_red_eye', false, undefined, undefined, 'Операция')),
            //todo fix view component
          ])
        ]),
      TLRoute(':SYS_ID/requests', undefined, TLData(CONSUMER_ROUTES.REQUESTS, 'Заявки', 'text_snippet', undefined, undefined, true), [
        TLRoute('', RequestsComponent, TLData(undefined, 'Заявки', 'text_snippet')),
        TLRoute('request', RequestFormComponent, TLData(CONSUMER_ROUTES.REQUEST_NEW, 'Нова', 'add', undefined, undefined, undefined, 'Заявки')),
        TLRoute('request/:ID', RequestFormComponent, TLData(CONSUMER_ROUTES.REQUEST_SHOW, 'Преглед', 'remove_red_eye', false, undefined, undefined, 'Заявки')),
        TLRoute('request/:ID/edit', RequestFormComponent, TLData(CONSUMER_ROUTES.REQUEST_EDIT, 'Редакция', 'edit', true, undefined, undefined, 'Заявки')),
        TLRoute(':REQ_ID/access-requests', undefined, TLData(CONSUMER_ROUTES.ACCESS_REQUESTS, 'Операции', 'receipt', undefined, undefined, true), [
          TLRoute('', AccessRequestsComponent, TLData(undefined, 'Операции', 'receipt')),
          TLRoute('request-operation', AccessRequestsFormComponent, TLData(CONSUMER_ROUTES.ACCESS_REQUESTS_NEW, 'Нова', 'add', false, undefined, undefined, 'Операция')),
          TLRoute('request-operation/:ID', AccessRequestsFormComponent, TLData(CONSUMER_ROUTES.ACCESS_REQUESTS_SHOW, 'Преглед', 'remove_red_eye', false, undefined, undefined, 'Операция')),
          TLRoute('request-operation/:ID/edit', AccessRequestsFormComponent, TLData(CONSUMER_ROUTES.ACCESS_REQUESTS_EDIT, 'Редакция', 'edit', true , undefined, undefined, 'Операция'))
        ])
      ]),
    ]),
    TLRoute('consumer-profile/:ID/edit', ConsumerProfileComponent, TLData(CONSUMER_ROUTES.CONSUMER_PROFILE_EDIT, 'Редакция', 'edit', true, undefined, undefined, 'Профил на консуматор')),
    TLRoute('consumer-profile-users/:ID/edit', ConsumerProfileUserComponent, TLData(CONSUMER_ROUTES.CONSUMER_PROFILE_USERS_EDIT, 'Редакция', 'edit', true, undefined, undefined, 'Профил на представител')),
    TLRoute('consumer-profile-users-approved', undefined, TLData(CONSUMER_ROUTES.CONSUMER_PROFILE_USERS_APPROVED, 'Нови представители', 'group_add'), [
      TLRoute('', ConsumerProfilesUsersApprovedComponent, TLData(undefined, 'Нови представители', 'group_add')),
      TLRoute('consumer-profile-users-approved/:ID/edit', ConsumerProfilesUsersApprovedFormComponent, TLData(CONSUMER_ROUTES.CONSUMER_PROFILE_USERS_APPROVED_EDIT, 'Редакция', 'edit', true , undefined, undefined, 'Нов представител'))
    ])
  ])
];

@NgModule({
  imports: [RouterModule.forChild(routes)],
  exports: [RouterModule],
})
export class ConsumerRoutingModule extends TLRoutingModule {
  constructor() {
    super(routes, 'consumer');
    console.log(routes);
  }
}
