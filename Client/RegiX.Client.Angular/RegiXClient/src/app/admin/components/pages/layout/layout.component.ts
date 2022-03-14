import {
  AfterViewInit,
  Component, OnDestroy, OnInit, ViewChild} from '@angular/core';
import { ReferenceDrawerItem, ConfigurationService } from '@tl/tl-common';
import { DisplayValue } from 'src/app/core/models/display-value.model';
import { filter, map } from 'rxjs/operators';
import { ReportsForUserService } from 'src/app/core/services/rest/reports-for-user.service';
import { ReportForUserModel } from 'src/app/core/models/dto/report-for-user.model';
import { ClientPermissions } from 'src/app/admin/permissions';
import { DrawerItem, DrawerItemType, HeaderDrawerItem, DividerDrawerItem} from '@tl/tl-common';
import { ROUTES } from 'src/app/admin/routes/static-routes';
import { ActivatedRoute, NavigationEnd, Router } from '@angular/router';
import { Subscription } from 'rxjs';
import { LayoutComponent } from '@tl/tl-common/lib/components/layout/layout.component';


export class AdministrationLoader extends DrawerItem {
  reportsForUserService: ReportsForUserService;
  constructor(
    reportsForUserService: ReportsForUserService
    ) {
    super({
      type: DrawerItemType.Loadable,
      permissions: ClientPermissions.ALL,
      loaded: false
    });
    this.reportsForUserService = reportsForUserService;
    this.loaded = false;
    this.reportsForUserService
      .getAllForUser()
      .pipe(
        map((items: ReportForUserModel[]) => {
          const arr: {id: number, displayName: string, tooltip: string}[] = [];
          items.forEach(item => {
            const foundItem = arr.find(d => d.id === item.authorityId);
            if (!foundItem) {
              arr.push(
                 {
                    id: item.authorityId,
                    displayName: item.authorityAcronym,
                    tooltip: item.authorityName
                  }
              );
            }
          });
          arr.sort((a, b) => {
            if (a.displayName > b.displayName) {
              return 1;
            }
            if (a.displayName < b.displayName) {
              return -1;
            }
            return 0;
          });
          return arr;
        })
      )
      .subscribe(
        data => {
          this.children = [];
          data.forEach( adm =>
              this.children.push(
                new ReferenceDrawerItem(
                  ROUTES.REGISTERS,
                  {':ADM_ID': adm.id + ''},
                  adm.displayName,
                  'account_balance',
                  adm.tooltip
                )
              )
          );
          this.loaded = true;
        },
        () => {
          this.loaded = true;
        }
      );
  }
}


@Component({
  selector: 'app-layout',
  templateUrl: './layout.component.html',
  styleUrls: ['./layout.component.scss']
})
export class TempLayoutComponent implements OnInit, OnDestroy, AfterViewInit {
  public applicationTitle: string;
  public drawerItems = [];
  private routes = ROUTES;
  subscription: Subscription;
  activatedRouteData: any;
  @ViewChild('layout')
  layoutBase: LayoutComponent;

  constructor(
    private reportsForUserService: ReportsForUserService,
    private router: Router,
    private activatedRoute: ActivatedRoute,
    configurationService: ConfigurationService
  ) {
    this.applicationTitle = configurationService.getApplicationName();
    this.drawerItems =
    [
      new ReferenceDrawerItem(ROUTES.ASYNC),
      new ReferenceDrawerItem(ROUTES.FAVOURITES, {}, 'Предпочитани услуги - редакция'),
      new DividerDrawerItem(ClientPermissions.ALL),
      new HeaderDrawerItem('Администрации', ClientPermissions.ALL),
      new AdministrationLoader(this.reportsForUserService),
      new DividerDrawerItem(ClientPermissions.ADMIN),
      new HeaderDrawerItem('Настройки', ClientPermissions.ADMIN),
      new ReferenceDrawerItem(ROUTES.ADMINISTRATIONS),
      new ReferenceDrawerItem(ROUTES.USERS),
      new ReferenceDrawerItem(ROUTES.ROLES),
      new ReferenceDrawerItem(ROUTES.REPORTS),
      new DividerDrawerItem(ClientPermissions.ALL),
      new HeaderDrawerItem('Журнал', ClientPermissions.ALL),
      new ReferenceDrawerItem(ROUTES.AUDIT_DATA),
      new ReferenceDrawerItem(ROUTES.SYSTEM_ERRORS),
      new ReferenceDrawerItem(ROUTES.USER_ACTIONS),
      new ReferenceDrawerItem(ROUTES.REPORT_EXECUTIONS)
    ];
  }
  ngAfterViewInit(): void {
    if (this.layoutBase.drawer.pinThreshold < window.innerWidth) {
      this.layoutBase.toggleDrawer();
    }
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
