import { TlCommonModule } from '@tl/tl-common';
import { NgModule } from '@angular/core';
import { CoreModule } from '../core/core.module';
import { PublicRoutingModule } from './routes/public-routing.module';
import { PublicLayoutComponent } from './components/layout/layout.component';
import { CommonModule } from '@angular/common';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';
import {
  IgxNavbarModule,
  IgxLayoutModule,
  IgxProgressBarModule,
  IgxNavigationDrawerModule,
  IgxToastModule,
  IgxAutocompleteModule,
  IgxDropDownModule,
  IgxInputGroupModule,
  IgxGridModule,
  IgxListModule,
  IgxPrefixModule,
  IgxAvatarModule
} from 'igniteui-angular';
import { IgxSelectModule } from 'igniteui-angular';
import { IgxIconModule } from 'igniteui-angular';
import { IgxCardModule } from 'igniteui-angular';
import { IgxExpansionPanelModule } from 'igniteui-angular';
import { IgxDividerModule } from 'igniteui-angular';
import { IgxButtonModule } from 'igniteui-angular';
import { IgxToggleModule } from 'igniteui-angular';
import { IgxTabsModule } from 'igniteui-angular';
import { IgxBottomNavModule  } from 'igniteui-angular';

import { InfoComponent } from './components/info/info.component';
import { OperationDetailsComponent } from './components/operation-details/operation-details.component';
import { SchemeDetailsComponent } from './components/scheme-details/scheme-details.component';
import { RegistersComponent } from './components/registers/registers.component';
import { OperationDescriptionComponent } from './components/operation-description/operation-description.component';
import { AdaptersMonitorComponent } from './components/adapters-monitor/adapters-monitor.component';

import { HighlightModule, HighlightJS } from 'ngx-highlightjs';
import xml from 'highlight.js/lib/languages/xml';
import scss from 'highlight.js/lib/languages/scss';
import typescript from 'highlight.js/lib/languages/typescript';
import javascript from 'highlight.js/lib/languages/javascript';
import { WsdlComponent } from './components/wsdl/wsdl.component';
import { HomeComponent } from './components/home/home.component';
import { OperationsComponent } from './components/operations/operations.component';

import { RegisterListComponent } from './components/registers/register-list/register-list.component';
import { RegisterDetailsComponent } from './components/registers/register-details/register-details.component';
import { AdaptersListComponent } from './components/adapters-list/adapters-list.component';
import { OperationsListComponent } from './components/operatios-list/operatios-list.component';
import { OperationsListDetailsComponent } from './components/operatios-list/operations-list-details/operations-list-details.component';
import { AdministrationListComponent } from './components/administration-list/administration-list.component';
import { AdministrationDetailsComponent } from './components/administration-details/administration-details.component';
import { TitleBarComponent } from './ui/title-bar/title-bar.component';
import { AdapterDetailComponent } from './components/adapter-detail/adapter-detail.component';
import { OperationsListDetailsDescriptionComponent } from './components/operatios-list/operations-list-details-description/operations-list-details-description.component';
import { CertificateProvisionComponent } from './components/development/certificate-provision/certificate-provision.component';
import { MarkdownModule } from 'ngx-markdown';
import { AdapterDevelopmentGuidelinesComponent } from './components/adapter-development-guidelines/adapter-development-guidelines.component';
import { ConsumerRegistrationComponent } from './components/consumer-registration/consumer-registration.component';
import { ConsumerUserRegistrationComponent } from './components/consumer-user-registration/consumer-user-registration.component';
import { StatisticsComponent } from './components/statistics/statistics.component';
import { SearchResultsComponent } from './components/search-results/search-results.component';
import { RgxModule } from '@tl-rgx/rgx-common';
import { AdapterDevelopmentGuidelinesNewComponent } from './components/adapter-development-guidelines-new/adapter-development-guidelines-new.component';
import { AdapterDevelopmentGuidelinesRecursiveComponent } from './components/adapter-development-guidelines-recursive/adapter-development-guidelines-recursive.component';
import { GuidesMarkedComponent } from './components/guides-marked/guides-marked.component';


export function hljsLanguages() {
  return [
    { name: 'typescript', func: typescript },
    { name: 'javascript', func: javascript },
    { name: 'scss', func: scss },
    { name: 'xml', func: xml }
  ];
}

@NgModule({
  declarations: [
    PublicLayoutComponent,
    RegistersComponent,
    InfoComponent,
    OperationDetailsComponent,
    SchemeDetailsComponent,
    OperationDescriptionComponent,
    AdaptersMonitorComponent,
    WsdlComponent,
    HomeComponent,
    OperationsComponent,
    RegisterListComponent,
    RegisterDetailsComponent,
    AdaptersListComponent,
    OperationsListComponent,
    OperationsListDetailsComponent,
    AdministrationListComponent,
    AdministrationDetailsComponent,
    TitleBarComponent,
    AdapterDetailComponent,
    OperationsListDetailsDescriptionComponent,
    CertificateProvisionComponent,
    AdapterDevelopmentGuidelinesComponent,
    ConsumerRegistrationComponent,
    ConsumerUserRegistrationComponent,
    StatisticsComponent,
    SearchResultsComponent,
    AdapterDevelopmentGuidelinesNewComponent,
    AdapterDevelopmentGuidelinesRecursiveComponent,
    GuidesMarkedComponent,
  ],
  imports: [
    HighlightModule.forRoot({
      languages: hljsLanguages
    }),
    CommonModule,
    CoreModule,
    PublicRoutingModule,
    TlCommonModule,
    FormsModule,
    ReactiveFormsModule,
    IgxPrefixModule,
    IgxListModule,
    IgxNavbarModule,
    IgxAutocompleteModule,
    IgxDropDownModule,
    IgxInputGroupModule,
    IgxSelectModule,
    IgxNavigationDrawerModule,
    IgxIconModule,
    IgxBottomNavModule,
    IgxToastModule,
    IgxCardModule,
    IgxExpansionPanelModule,
    IgxDividerModule,
    IgxButtonModule,
    IgxToggleModule,
    IgxTabsModule,
    IgxLayoutModule,
    IgxProgressBarModule,
    IgxGridModule,
    IgxAvatarModule,
    MarkdownModule.forChild(),
    TlCommonModule,
    RgxModule
  ],
  providers: [
    HighlightJS
    // {
    //   provide: HIGHLIGHT_OPTIONS,
    //   useValue: {
    //     languages: hljsLanguages
    //   }
    // }
  ],
  exports: []
})
export class PublicModule {}
