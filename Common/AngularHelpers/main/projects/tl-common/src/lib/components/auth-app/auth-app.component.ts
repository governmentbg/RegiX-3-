import { Injector } from '@angular/core';
import { Subject, Observable } from 'rxjs';
import { OidcSecurityService, PublicEventsService, EventTypes, AuthorizationResult, AuthorizedState, ValidationResult } from 'angular-auth-oidc-client';
import { NgxPermissionsService } from 'ngx-permissions';
import { Title } from '@angular/platform-browser';
import { ActivatedRoute, Router, RouteConfigLoadStart, RouteConfigLoadEnd, NavigationEnd, NavigationStart, NavigationCancel, NavigationError } from '@angular/router';
import { HttpClient } from '@angular/common/http';
import { APP_BASE_HREF } from '@angular/common';
import { getCurrentResourceStrings, changei18n } from 'igniteui-angular';
import { filter, map } from 'rxjs/operators';
import { NGXLogger } from 'ngx-logger';
import { LocalStorageService } from '../../services/local-storage.service';
import { AUTH_PATHS } from '../../modules/auth-paths';

export abstract class TLAuthAppComponent {
  private authorizing$ = new Subject<boolean>();
  public authorizing = false;

  private loadingModule$ = new Subject<boolean>();
  public loadingModule = false;
  public loadingModuleName = '';

  
  private navigating$ = new Subject<boolean>();
  public navigating = false;

  protected baseHref: string;
  protected permissionsService: NgxPermissionsService;
  protected titleService: Title;
  protected activatedRoute: ActivatedRoute;
  protected router: Router;
  protected oidcSecurityService: OidcSecurityService;
  protected http: HttpClient;
  protected logger: NGXLogger;
  protected localStorageService: LocalStorageService;
  protected isAuthenticated$: Observable<boolean>;
  protected eventService: PublicEventsService;

  private validationError: string = undefined;

  constructor(protected injector: Injector) {
    this.baseHref = this.injector.get<string>(APP_BASE_HREF);
    this.permissionsService = this.injector.get<NgxPermissionsService>(NgxPermissionsService);
    this.titleService = this.injector.get<Title>(Title);
    this.activatedRoute = this.injector.get<ActivatedRoute>(ActivatedRoute);
    this.router = this.injector.get<Router>(Router);
    this.oidcSecurityService = this.injector.get<OidcSecurityService>(OidcSecurityService);
    this.http = this.injector.get<HttpClient>(HttpClient);
    this.logger = this.injector.get<NGXLogger>(NGXLogger);
    this.localStorageService = this.injector.get<LocalStorageService>(LocalStorageService);
    this.eventService = this.injector.get<PublicEventsService>(PublicEventsService);

    this.http
      .get('assets/ignite-ui.localization.json')
      .subscribe((data: any) => {
        const currentRS = getCurrentResourceStrings();

        for (const key of Object.keys(data)) {
          currentRS[key] = data[key];
        }
        changei18n(currentRS);
      });

    this.authorizing$.subscribe((authorizing) => {
      this.authorizing = authorizing;
    });
    this.loadingModule$.subscribe((loadingModule) => {
      this.loadingModule = loadingModule;
    });
    this.navigating$.subscribe((navigating) => {
      this.navigating = navigating;
    });
    
    this.eventService
      .registerForEvents()
      .pipe(filter((notification) => notification.type === EventTypes.NewAuthorizationResult))
      .subscribe((event) => {
        if (event.value.validationResult === ValidationResult.MaxOffsetExpired) {
          this.validationError = 'Максимално допустимото отклонение на времето за автентикация е надвишено! Моля проверете дали часовникът на компютъра е синхронизиран.';
        }
      }
    );

    this.router.events.subscribe(event => {
      switch (true) {
        case event instanceof RouteConfigLoadStart: {
          this.loadingModuleName = (event as RouteConfigLoadStart).route.path;
          this.loadingModule$.next(true);
          break;
        }
        case event instanceof RouteConfigLoadEnd: {
          this.loadingModule$.next(false);
          break;
        }
        case event instanceof NavigationStart: {
          this.navigating$.next(true);
          break;
        }

        case event instanceof NavigationEnd:
        case event instanceof NavigationCancel:
        case event instanceof NavigationError: {
          this.navigating$.next(false);
          break;
        }
        default: {
          break;
        }
      }
  });

    this.router.events
      .pipe(
        filter(event => event instanceof NavigationEnd),
        map(() => this.activatedRoute)
      )
      .pipe(
        map(route => {
          while (route.firstChild) {
            route = route.firstChild;
          }
          return route;
        })
      )
      .subscribe(data => {
        const title = this.getTitle(data.snapshot.data.name);
        this.setTitle(title);
      });

      this.isAuthenticated$ = this.oidcSecurityService.isAuthenticated$;
      
      this.oidcSecurityService.checkAuth().subscribe((isAuthenticated) => 
      {
        if (isAuthenticated){
          this.LoadPermissions();
          this.navigateToAuthorized(AuthorizedState.Authorized);
        } /*else {
          this.router.navigate(['']);
        }*/
      },
      error => {
        if (error === 'no code in url'){
          this.router.navigate([`${this.baseHref}${AUTH_PATHS.MAIN}`]);
        } else {
          const path = `${this.baseHref}${AUTH_PATHS.LOGIN_ERROR}`;
          if (this.validationError !== undefined){
            this.router.navigate([path], { queryParams:{ error: this.validationError}});
          } else {
            this.router.navigate([path], { queryParams:{ error: error}});
          }
        }
      });
  }

  private LoadPermissions() {
    this.logger.debug('Loading permissions');
    this.oidcSecurityService.userData$.subscribe(userData => {
      if (userData && userData.role) {
        if (Array.isArray(userData.role)) {
          this.permissionsService.loadPermissions(userData.role);
        } else if (userData.role) {
          this.permissionsService.loadPermissions([userData.role]);
        } else{
          this.permissionsService.loadPermissions([]);
        }
      }
    });
  }

  private navigateToAuthorized(authorizationState: AuthorizedState) {
    if (window.location.pathname === `${this.baseHref}${AUTH_PATHS.POSTLOGIN}`) {
      if (authorizationState === AuthorizedState.Authorized) {
        let path = this.localStorageService.read('redirect');
        this.logger.debug(authorizationState);
        this.LoadPermissions();
        path = (path) ? path : `${this.baseHref}${AUTH_PATHS.MAIN}`;
        this.localStorageService.remove('redirect');
        this.logger.debug(`Redirecting to ${path}`);
        this.router.navigate([path]);
      }
    }
  }

  setTitle(title: string) {
    this.titleService.setTitle(title);
  }
  
  protected abstract getTitle(page: string): string;
}
