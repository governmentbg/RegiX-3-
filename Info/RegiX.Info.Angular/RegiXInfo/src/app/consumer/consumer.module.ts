import { NgModule } from '@angular/core';
import { ProfileComponent } from './components/profile/profile.component';
import { ConsumerRoutingModule } from './routes/consumer-routing.module';
import { SystemsComponent } from './components/systems/systems.component';
import { TlCommonModule } from '@tl/tl-common';
import { ConsumerLayoutComponent } from './components/consumer-layout/consumer-layout.component';
import { IgxGridModule, IgxDialogModule, IgxLayoutModule, IgxTreeGridModule } from 'igniteui-angular';
import { SystemFormComponent } from './components/systems/system-form/system-form.component';
import { BasicFormComponent } from './components/ui/basic-form/basic-form.component';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';
import { FormGroupComponent } from './components/ui/form-group/form-group.component';
import { CertificatesComponent } from './components/certificates/certificates.component';
import { AccessComponent } from './components/access/access.component';
import { AccessFormComponent } from './components/access/access-form/access-form.component';
import { CertificateFormComponent } from './components/certificates/certificate-form/certificate-form.component';
import { RequestsComponent } from './components/requests/requests.component';
import { AccessRequestsComponent } from './components/access-requests/access-requests.component';
import { AccessRequestsFormComponent } from './components/access-requests/access-requests-form/access-requests-form.component';
import { RequestFormComponent } from './components/requests/request-form/request-form.component';
import { OperationFilterComponent } from './components/filters/operation-filter/operation-filter.component';
import { ConsumerSystemCertificatesFilterComponent } from './components/filters/consumer-system-certificates-filter/consumer-system-certificates-filter.component';
import { LoggedUserComponent } from './components/ui/logged-user/logged-user.component';
import { ConsumerProfileComponent } from './components/consumer-profile/consumer-profile.component';
import { ConsumerSystemsFilterComponent } from './components/filters/consumer-systems-filter/consumer-systems-filter.component';
import { CertificateOperationAccessComponent } from './components/certificate-operation-access/certificate-operation-access.component';
import { ConsumerProfileUserComponent } from './components/consumer-profile-user/consumer-profile-user.component';
import { ConsumerProfilesUsersApprovedComponent } from './components/consumer-profiles-users-approved/consumer-profiles-users-approved.component';
import { ConsumerProfilesUsersApprovedFormComponent } from './components/consumer-profiles-users-approved/consumer-profiles-users-approved-form/consumer-profiles-users-approved-form.component';
import { RgxModule } from '@tl-rgx/rgx-common';

@NgModule({
  declarations: [
    ProfileComponent,
    SystemsComponent,
    ConsumerLayoutComponent,
    SystemFormComponent,
    BasicFormComponent,
    FormGroupComponent,
    CertificatesComponent,
    AccessComponent,
    AccessFormComponent,
    CertificateFormComponent,
    RequestsComponent,
    AccessRequestsComponent,
    AccessRequestsFormComponent,
    RequestFormComponent,
    OperationFilterComponent,
    ConsumerSystemCertificatesFilterComponent,
    LoggedUserComponent,
    ConsumerProfileComponent,
    ConsumerSystemsFilterComponent,
    CertificateOperationAccessComponent,
    ConsumerProfileUserComponent,
    ConsumerProfilesUsersApprovedComponent,
    ConsumerProfilesUsersApprovedFormComponent
  ],
  imports: [
    ConsumerRoutingModule,
    TlCommonModule,
    IgxGridModule,
    IgxDialogModule,
    IgxTreeGridModule,
    IgxLayoutModule,
    FormsModule,
    ReactiveFormsModule,
    RgxModule
  ],
  providers: [
  ],
  exports: []
})
export class ConsumerModule {}
