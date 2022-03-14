import {
  Component,
  Injector,
  OnDestroy,
  OnInit
} from '@angular/core';
import { ActivatedRoute, NavigationEnd, Router } from '@angular/router';
import { LayoutComponent, NavigationDrawerItem, DividerDrawerItem, HeaderDrawerItem, ReferenceDrawerItem, ConfigurationService } from '@tl/tl-common';
import { Subscription } from 'rxjs';
import { filter } from 'rxjs/operators';
import { AdminPermissions } from '../../permissions';
import { ROUTES } from '../../routes/static-routes';


@Component({
  selector: 'app-layout',
  templateUrl: './layout.component.html',
  styleUrls: ['./layout.component.scss']
})
export class TempLayoutComponent implements OnInit, OnDestroy {
  public applicationTitle: string;
  routes = ROUTES;
  public drawerItems = [];
  subscription: Subscription;
  activatedRouteData: any;

  constructor(
    configurationService: ConfigurationService,
    private router: Router,
    private activatedRoute: ActivatedRoute) {
    this.applicationTitle = configurationService.getApplicationName();
    this.drawerItems =
    [
      new HeaderDrawerItem('Първични администратори', AdminPermissions.ADMIN),
      new ReferenceDrawerItem(ROUTES.ADMINISTRATIONS, {':ADM_TYPE': 'primary'}),
      new ReferenceDrawerItem(ROUTES.REGISTRIES, {':ADM_TYPE': 'primary'}),
      new ReferenceDrawerItem(ROUTES.ADAPTERS, {':ADM_TYPE': 'primary'}),
      new ReferenceDrawerItem(ROUTES.OPERATIONS, {':ADM_TYPE': 'primary'}),
      new DividerDrawerItem(AdminPermissions.ADMIN),
      new HeaderDrawerItem('Ползватели', AdminPermissions.ADMIN),
      new ReferenceDrawerItem(ROUTES.ADMINISTRATIONS),
      new ReferenceDrawerItem(ROUTES.CONSUMERS),
      new ReferenceDrawerItem(ROUTES.CERTIFICATES),
      new ReferenceDrawerItem(ROUTES.ACCESS_REPORT),
      new ReferenceDrawerItem(ROUTES.CONSUMER_ROLES),
      new ReferenceDrawerItem(ROUTES.STATISTICS),
      new ReferenceDrawerItem(ROUTES.LOGS),
      new ReferenceDrawerItem(ROUTES.ERRORS),
      new DividerDrawerItem(AdminPermissions.GLOBAL_ADMIN),
      new HeaderDrawerItem('Системни настройки', AdminPermissions.GLOBAL_ADMIN),
      new ReferenceDrawerItem(ROUTES.USERS, {':ADM_TYPE': 'primary'}),
      new ReferenceDrawerItem(ROUTES.ADMINISTRATIONS_TYPES),
      new ReferenceDrawerItem(ROUTES.AUDIT),
      new HeaderDrawerItem('Заявки от консуматори', AdminPermissions.ADMIN),
      new ReferenceDrawerItem(ROUTES.CONSUMER_PROFILES),
      new ReferenceDrawerItem(ROUTES.CONSUMER_SYSTEMS),
      // new ReferenceDrawerItem(ROUTES.USER_ACTIONS)
     // new NavigationDrawerItem('Одит', [], ROUTES.AUDIT.relativeRoute(), 'menu_book')
    ];
  }
  ngOnDestroy(): void {
    if (this.subscription) {
      this.subscription.unsubscribe();
      this.subscription = undefined;
    }
  }
  ngOnInit(): void {
    this.subscription = this.router.events
      .pipe(filter(event => event instanceof NavigationEnd))
      .subscribe(() => {
        let data = this.activatedRoute;
        while (data.firstChild) {
          data = data.firstChild;
        }
        this.activatedRouteData = data.snapshot.data;
      });
  }

  navigateToHelp() {
    const res = this.activatedRouteData;
    this.routes.HELP.navigate(this.router, {':MARKED': res?.helpPageName ?? 'Contents.md'});
  }
}
