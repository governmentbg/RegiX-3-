import { Routes, Route } from '@angular/router';
import { TLRouteReference } from './route-reference';

export abstract class TLRoutingModule {
    constructor(aRoutes: Routes, modulePath: string) {  
      this.populateStaticRoutes(aRoutes, [modulePath]);
    }
  
    private populateStaticRoutes(routes: Routes, stack: string[]) {
      if (routes) {
        routes.forEach(
          (route: Route) => {
            if (route && route.data && route.data.staticRoute) {
              const splittedStack = stack.map( s => s.split('/')).reduce((accumulator, value) => accumulator.concat(value), []);
              const splittedRoute = route.path.split('/');
              route.data.staticRoute.route = [...splittedStack, ...splittedRoute];
              route.data.staticRoute.title = route.data.name;
              route.data.staticRoute.icon = route.data.icon;
              route.data.staticRoute.permissions = (route.data.permissions) ? route.data.permissions.only : [];
              // Тази простотия е необходима тъй като обектите в статичните пътища не
              // са инициализирани... Това е така, защото няма как да им се подаде new TLRouteReference(),
              // защото гърми по време на компилация в production режим със съобщение, че функции не могат
              // да бъдат викани в декоратори.
              route.data.staticRoute.navigate = new TLRouteReference().navigate;
              route.data.staticRoute.staticRoute = new TLRouteReference().staticRoute;
              route.data.staticRoute.relativeRoute = new TLRouteReference().relativeRoute;
              this.checkRouteForParameterDuplicates(route.data.staticRoute.route);
            }
            const shouldAddPath = route.path && route.path !== '';
            shouldAddPath ? stack.push(route.path) : {};
            this.populateStaticRoutes(route.children, stack);
            shouldAddPath ? stack.pop() : {};
          }
        );
      }
    }

    private checkRouteForParameterDuplicates(route: string[]){
      if (route && route.length > 0){
        const foundDuplicates = 
          route
            .filter( r => r.startsWith(':'))
            .filter((item, index, filteredArray) => filteredArray.indexOf(item) !== index)
            .length;
        if (foundDuplicates > 0){
          throw new TypeError(`Error creating TLRouteReference for route ${route} - duplicated parameters` )
        }
      }
    }
  }