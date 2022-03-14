import { ActivatedRoute, Router } from '@angular/router';
import { Component, OnInit, ViewChild, Injector } from '@angular/core';
import {
  LayoutComponent,
  HeaderDrawerItem,
  NavigationDrawerItem,
  DividerDrawerItem,
  ReferenceDrawerItem,
  AUTH_PATHS,
  ConfigurationService,
} from '@tl/tl-common';
import { ROUTES } from '../../routes/static-routes';

@Component({
  selector: 'app-layout',
  templateUrl: './layout.component.html',
  styleUrls: ['./layout.component.scss'],
})
export class PublicLayoutComponent {
  public applicationTitle: string;

  routes = ROUTES;

  public drawerItems = [];

  constructor(
    public router: Router,
    public activatedRoute: ActivatedRoute,
    configurationService: ConfigurationService
  ) {
    this.applicationTitle = configurationService.getApplicationName();
    this.drawerItems = [
      new HeaderDrawerItem('Първични администратори', []),
      new ReferenceDrawerItem(ROUTES.ADMINISTRATIONS),
      new ReferenceDrawerItem(ROUTES.REGISTRIES),
      //new NavigationDrawerItem('Администрации ', [], ROUTES.ADMINISTRATIONS.relativeRoute(), 'account_balance'),
      //new NavigationDrawerItem('Регистри', [], ROUTES.REGISTRIES.relativeRoute(), 'dashboard'),
      // new NavigationDrawerItem('Адаптери', [], ROUTES.ADAPTERS.relativeRoute(), 'developer_board'),
      // new NavigationDrawerItem('Операции ', [], ROUTES.OPERATIONS.relativeRoute(), 'receipt'),
      // new NavigationDrawerItem('Инфо за администрации ', [], ROUTES.AGENCIES.relativeRoute(), 'account_balance'),
      // new DividerDrawerItem([]),
      // new HeaderDrawerItem('За разработчици', []),
      // new NavigationDrawerItem('Среди на RegiX', [], [''], 'storage'),
      // new NavigationDrawerItem('Изготвяне на сертификат', [], [''], 'card_membership'),
      // new NavigationDrawerItem('Разработка на адаптер', [], [''], 'developer_board'),
      // new DividerDrawerItem([]),
      // new HeaderDrawerItem('Консуматори', []),
      // new NavigationDrawerItem('Вход', [], ['/', AUTH_PATHS.AUTHENTICATED], 'input'),
      new DividerDrawerItem([]),
      new HeaderDrawerItem('Статистика', []),
      new ReferenceDrawerItem(ROUTES.STATISTICS_HOUR),
      new ReferenceDrawerItem(ROUTES.STATISTICS_DAY),
      new ReferenceDrawerItem(ROUTES.STATISTICS_WEEK),
      new ReferenceDrawerItem(ROUTES.STATISTICS_MONTH),
      new HeaderDrawerItem('За разработчици', []),
      new ReferenceDrawerItem(ROUTES.GUIDES, {':MARKED': 'Guides.md'}),
    ];
  }
}
