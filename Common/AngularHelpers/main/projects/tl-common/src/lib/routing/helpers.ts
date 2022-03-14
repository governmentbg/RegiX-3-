import { Route, Data } from '@angular/router';
import { Type } from '@angular/core';
import { TLRouteReference } from './route-reference';
import { NgxPermissionsGuard } from 'ngx-permissions';

export function TLData(
  aStaticRoute?: TLRouteReference,
  aName?: string,
  aIcon?: string,
  aEdit?: boolean,
  aFilterField?: string,
  aIsFilterable?: boolean,
  aObjectName?: string,
  aIsFilterIconActive?: boolean,
  aHelpPageName?: string,
  aHideRoute?: boolean): Data {
  return {
    staticRoute: aStaticRoute,
    name: aName,
    icon: aIcon,
    edit: aEdit,
    filterField: aFilterField,
    isFilterable: aIsFilterable,
    objectName: aObjectName,
    isFilterIconActive: aIsFilterIconActive,
    helpPageName: aHelpPageName,
    hideRoute: aHideRoute
  };
}

export function TLRoute(
  aPath: string,
  aComponent?: Type<any>,
  aData?: Data,
  aChildren?: Route[],
  aOnly?: string[]): Route {
    const result: Route =  {
      path: aPath,
      component: aComponent,
      data: aData,
      children: aChildren
    };
    if (aOnly && aOnly.length > 0){
      result.canActivate = [NgxPermissionsGuard];
      if (!result.data){
        result.data = {}; 
      }
      result.data.permissions = 
        {
          only: aOnly
        };
    }
    return result;
}
