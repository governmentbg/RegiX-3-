# tl-common

TL-Common uses LoggerModule. The logger module should be imported in the application which is using tl-common.

## Components

### tl-reference-button
Used with TLRouteReference objects.
Automatically applies settings from the TLRouteReference like:
* Navigation route
* Title
* Icon
* Permissions

Additional properties include `buttonType` and `routeArguments`.

Currently alowed `buttonType` include:
* **raised** - standard button
* **fab** - fab button
* **action-button** - button in table's actions

Sample usage:
* As fab button

    ```html
    <tl-reference-button
        [routeReference]="this.routes.AUDIT_DATA"
        buttonType="fab"
    >
    </tl-reference-button>
    ```
    
* As raised button

    ```html
    <tl-reference-button
        [routeReference]="this.routes.ROLE_NEW"
        buttonType="raised"
    >
    </tl-reference-button>
    ```

* As action-button
    
    ```html
    <tl-reference-button
        [routeReference]="this.routes.ROLE_EDIT"
        [routeArguments]="{ ':ID': cell.rowData.id + '' }"
        buttonType="action-button"
    >
    </tl-reference-button>
    ```
The routeArguments are used to provide additional arguments for the routing

## Helpers

### TLRoute/TLData
The functions `TLRoute` and `TLData` are used for shortened routes declarations.

Sample usage: 
```javascript
TLRoute('home', HomeComponent, TLData(ROUTES.HOME, 'Начало', 'home'), [])
```

The line above is equivalent to the following:
```javascript
{
    path: 'home',
    component: HomeComponent,
    data: {
        staticRoute: ROUTES.HOME,
        name: 'Начало',
        icond: 'home'
    },
    children: []
}
```

### TLRouteReference
This class is used for referencing routes in routing modules. It should be used in the follwing manner:

* Define constant containig definitions for all the needed routes:

    ```javascript
    export const ROUTES = {
        // ...
        HOME: {} as TLRouteReference,
        SETTINGS: {} as TLRouteReference,
        // ...
    }
    ```

* Extend the `TLRoutingModule` class in your module and reference the static definition from ROUTES in the routes used in the routing module's declaration:

    ```javascript
    export const ADMIN_MODULE_PATH = 'admin';

    const routes: Routes = [
        TLRoute('', HomeComponent, TLData(ROUTES.HOME, 'Начало', 'home'))
    ];

    @NgModule({
        imports: [RouterModule.forChild(routes)],
        exports: [RouterModule]
    })
    export class AdminRoutingModule extends TLRoutingModule {
        constructor() {
            super(routes, ADMIN_MODULE_PATH);
        }
    }
    ```
