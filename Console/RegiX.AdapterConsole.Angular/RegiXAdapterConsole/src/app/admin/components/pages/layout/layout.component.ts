import { Component } from '@angular/core';
import { NavigationDrawerItem, DividerDrawerItem, HeaderDrawerItem, ConfigurationService } from '@tl/tl-common';
import { ROUTES } from 'src/app/admin/routes/static-routes';

@Component({
  selector: 'app-layout',
  templateUrl: './layout.component.html',
  styleUrls: ['./layout.component.scss']
})
export class LayoutComponent {
  public applicationTitle: string;
  routes = ROUTES;
  public drawerItems = [];

  constructor(
    configurationService: ConfigurationService
  ) {
    this.applicationTitle = configurationService.getApplicationName();
    this.drawerItems =
    [
      //new NavigationDrawerItem('Начало', [], ROUTES.HOME.staticRoute(), 'home'),
      new NavigationDrawerItem('Чакащи услуги', [], ROUTES.OPERATION_CALLS.relativeRoute(), 'schedule'),
      new NavigationDrawerItem('Моите услуги', [], ROUTES.MY_OPERATION_CALLS.relativeRoute(), 'receipt'),
      new NavigationDrawerItem('Приключени услуги', [], ROUTES.RETURNED_CALLS.relativeRoute(), 'history'),
      new DividerDrawerItem([]),
      new HeaderDrawerItem('Настройки', []),
      new NavigationDrawerItem('Потребители', [], ROUTES.USERS.relativeRoute(), 'person'),
      new NavigationDrawerItem('Роли', [], ROUTES.ROLES.relativeRoute(), 'group')
    ];
  }
}
