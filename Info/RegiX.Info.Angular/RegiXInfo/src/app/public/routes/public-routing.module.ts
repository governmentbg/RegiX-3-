// tslint:disable: max-line-length
import { AdapterDetailComponent } from './../components/adapter-detail/adapter-detail.component';
import { AdministrationListComponent } from './../components/administration-list/administration-list.component';
import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { PublicLayoutComponent } from '../components/layout/layout.component';
import { InfoComponent } from '../components/info/info.component';
import { AdaptersMonitorComponent } from '../components/adapters-monitor/adapters-monitor.component';
import { WsdlComponent } from '../components/wsdl/wsdl.component';
import { HomeComponent } from '../components/home/home.component';
import { RegistersComponent } from '../components/registers/registers.component';
import { RegisterListComponent } from '../components/registers/register-list/register-list.component';
import { RegisterDetailsComponent } from '../components/registers/register-details/register-details.component';
import { AdaptersListComponent } from '../components/adapters-list/adapters-list.component';
import { OperationsListComponent } from '../components/operatios-list/operatios-list.component';
import { AdministrationDetailsComponent } from '../components/administration-details/administration-details.component';
import { OperationsListDetailsComponent } from '../components/operatios-list/operations-list-details/operations-list-details.component';
import { TLRoutingModule, TLData, TLRoute } from '@tl/tl-common';
import { ROUTES } from './static-routes';
import { CertificateProvisionComponent } from '../components/development/certificate-provision/certificate-provision.component';
import { AdapterDevelopmentGuidelinesComponent } from '../components/adapter-development-guidelines/adapter-development-guidelines.component';
import { ConsumerRegistrationComponent } from '../components/consumer-registration/consumer-registration.component';
import { ConsumerUserRegistrationComponent } from '../components/consumer-user-registration/consumer-user-registration.component';
import { StatisticsComponent } from '../components/statistics/statistics.component';
import { SearchResultsComponent } from '../components/search-results/search-results.component';
import { AdapterDevelopmentGuidelinesRecursiveComponent } from '../components/adapter-development-guidelines-recursive/adapter-development-guidelines-recursive.component';
import { AdapterDevelopmentGuidelinesNewComponent } from '../components/adapter-development-guidelines-new/adapter-development-guidelines-new.component';
import { GuidesMarkedComponent } from '../components/guides-marked/guides-marked.component';


export const PUBLIC_MODULE_PATH = 'public';

const routes: Routes = [
  TLRoute('', PublicLayoutComponent, TLData(ROUTES.REGIXINFO, 'Начало', 'home'), [
    TLRoute('', HomeComponent, TLData(undefined, 'Начало', 'home')),
    TLRoute('wsdl', WsdlComponent, TLData(ROUTES.WSDL, 'WSDL')),
    TLRoute('adapterStatus', AdaptersMonitorComponent, TLData(ROUTES.ADAPTER_STATUS, 'Статус на адаптери')),
    TLRoute('agencies', undefined, TLData(ROUTES.AGENCIES, 'Инфо администрации','account_balance'), [
      TLRoute('', InfoComponent, TLData(undefined, 'Инфо администрации','account_balance')),
      TLRoute('agencies/:AGENCY_ID', RegistersComponent, TLData(ROUTES.AGENCIES_VIEW, 'Инфо администрация')),
    ]),
    TLRoute('adapters', undefined, TLData(ROUTES.ADAPTERS, 'Адаптери', 'developer_board'), [
      TLRoute('', AdaptersListComponent, TLData(undefined, 'Адаптери', 'developer_board')),
      TLRoute('adapters/:ADAPTER_NAME', AdapterDetailComponent, TLData(ROUTES.ADAPTERS_VIEW, 'Адаптер','developer_board')),
    ]),
    TLRoute('operations', undefined, TLData(ROUTES.OPERATIONS, 'Операции', 'receipt'), [
      TLRoute('', OperationsListComponent, TLData(undefined, 'Операции', 'receipt')),
      TLRoute('operations/:INTERFACE/:OPERATION_NAME', OperationsListDetailsComponent, TLData(ROUTES.OPERATIONS_VIEW, 'Операция', 'receipt')),
    ]),
    TLRoute('administrations', undefined, TLData(ROUTES.ADMINISTRATIONS, 'Aдминистрации', 'account_balance'), [
      TLRoute('', AdministrationListComponent, TLData(undefined, 'Aдминистрации','account_balance')),
      TLRoute(':ADM_CODE/registries', undefined, TLData(ROUTES.REGISTRIES, 'Регистри', 'dashboard', undefined, undefined, true), [
        TLRoute('', RegisterListComponent, TLData(undefined, 'Регистри', 'dashboard')),
        TLRoute('registries/:REGISTER_NAME', RegisterDetailsComponent, TLData(ROUTES.REGISTRIES_VIEW, 'Регистър', 'dashboard')),
        TLRoute('operations/:INTERFACE/:OPERATION_NAME', OperationsListDetailsComponent, TLData(ROUTES.OPERATIONS_VIEW, 'Операция', 'receipt'))
      ]),
      TLRoute('administrations/:ID/:ADMINISTRATION_NAME', AdministrationDetailsComponent, TLData(ROUTES.ADMINISTRATIONS_VIEW, 'Aдминистрация', 'account_balance')),
    ]),
    TLRoute('info', undefined, TLData(ROUTES.INFO, 'Информация', 'info')),
    TLRoute('statisticsTest', undefined, TLData(ROUTES.STATISTICS, 'Статистика', 'bar_chart')),
    TLRoute('statistics/hour', StatisticsComponent, TLData(ROUTES.STATISTICS_HOUR, 'Последен час', 'bar_chart'),[
      TLRoute('error', StatisticsComponent, TLData(ROUTES.STATISTICS_HOUR_ERROR, 'Последен час - Грешки', 'bar_chart'))
    ]),
    TLRoute('statistics/day', StatisticsComponent, TLData(ROUTES.STATISTICS_DAY, 'Последен ден', 'bar_chart'),[
      TLRoute('error', StatisticsComponent, TLData(ROUTES.STATISTICS_DAY_ERROR, 'Последен ден - Грешки', 'bar_chart'))
    ]),
    TLRoute('statistics/week', StatisticsComponent, TLData(ROUTES.STATISTICS_WEEK, 'Последна седмица', 'bar_chart'),[
      TLRoute('error', StatisticsComponent, TLData(ROUTES.STATISTICS_WEEK_ERROR, 'Последна седмица - Грешки', 'bar_chart'))
    ]),
    TLRoute('statistics/month', StatisticsComponent, TLData(ROUTES.STATISTICS_MONTH, 'Последен месец', 'bar_chart', false, undefined, undefined, 'Операция'),[
      TLRoute('error', StatisticsComponent, TLData(ROUTES.STATISTICS_MONTH_ERROR, 'Последен месец - Грешки', 'bar_chart'))
    ]),
    TLRoute('consumers', undefined, TLData(ROUTES.CONSUMERS, 'Консуматори', 'dns'), [
      TLRoute('consumer-registration', ConsumerRegistrationComponent, TLData(ROUTES.CONSUMER_REGISTRATION, 'Регистрация', 'add', true, undefined, false, 'Профил на консуматор')),
      TLRoute('consumer-user-registration', ConsumerUserRegistrationComponent, TLData(ROUTES.CONSUMER_USER_REGISTRATION, 'Регистрация на представител', 'person', true, undefined, false, 'Профил на консуматор'))
    ]),
    TLRoute('guides/:MARKED', GuidesMarkedComponent, TLData(ROUTES.GUIDES, 'Ръководства и инструкции', 'build')),
    TLRoute('developers', undefined, TLData(ROUTES.DEVELOPERS, 'Разработчици', 'build'), [
      TLRoute('environments', undefined, TLData(ROUTES.REGIX_ENVIRONMENTS, 'Среди на RegiX', 'storage')),
      TLRoute('certificate', CertificateProvisionComponent, TLData(ROUTES.CERTIFICATE_PROVISION, 'Изготвяне на сертификат', 'card_membership')),
      TLRoute('development', AdapterDevelopmentGuidelinesNewComponent, TLData(ROUTES.ADAPTER_DEVELOPMENT, 'Разработка на адаптер', 'developer_board')),
    ]),
    TLRoute('search-results/:TERM', SearchResultsComponent, TLData(ROUTES.SEARCH_RESULTS, 'Търсене', 'search'))
  ]),
];

@NgModule({
  imports: [RouterModule.forChild(routes)],
  exports: [RouterModule],
})
export class PublicRoutingModule extends TLRoutingModule {
  constructor() {
    super(routes, PUBLIC_MODULE_PATH);
  }
}
