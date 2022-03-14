import { Router, ActivatedRoute } from '@angular/router';

export interface ITLRouteReference {
  route: string[];
  title: string;
  icon: string;
  permissions: string[];
  
  navigate(
    router: Router,
    args?: TlRouteArguments,
    activatedRoute?: ActivatedRoute
  ): void;

  staticRoute(args?: TlRouteArguments): string[];

  relativeRoute(args?: TlRouteArguments): string[];
}

export interface TlRouteArguments {
  [name: string]: string;
}
// При разширяване на долния клас да се има предвид функционалонстта в TLRoutingModule
// Ако се добавят нови методи това трябва да се отрази и там!
export class TLRouteReference implements ITLRouteReference{
  public route: string[] = [];
  public title: string;
  public icon: string;
  public permissions: string[];

  public navigate(
    router: Router,
    args?: TlRouteArguments,
    activatedRoute?: ActivatedRoute
  ) {
    if (activatedRoute) {
      if (!args) {
        args = {};
      }
      for (const key of Object.keys(activatedRoute.snapshot.params)) {
        // Explcitly provided arguments are not overwritten
        if (!args[`:${key}`]) {
          args[`:${key}`] = activatedRoute.snapshot.params[key];
        }
      }
    }
    const route = this.staticRoute(args);
    router.navigate(route);
  }

  public staticRoute(args?: TlRouteArguments): string[] {
    return this.route.map((r: string) => {
      if (args && args[r]) {
        return args[r];
      } else {
        if (r.startsWith(':')) {
          return '-';
        }
        return r;
      }
    });
  }
  public relativeRoute(args?: TlRouteArguments): string[] {
    return this.staticRoute(args).slice(1);
  }
}
