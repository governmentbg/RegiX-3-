import { DrawerItemType } from './drawer-item-type';
import { DrawerItem } from './drawer-item';
import { ITLRouteReference } from '../../routing/route-reference';

export class ReferenceDrawerItem extends DrawerItem {
  constructor(
    reference: ITLRouteReference,
    referenceArguments?: any,
    title?: string,
    icon?: string,
    tooltip?: string
  ) {
    super({
      type: DrawerItemType.Naivgation,
      permissions: reference.permissions,
      routerLink: reference.relativeRoute(referenceArguments),
      routerLinkActive: ['active-menu-item'],
      routerLinkActiveOptions: { exact: true },
      icon: icon ? icon : reference.icon,
      text: title ? title : reference.title,
      tooltip: tooltip
    });
  }
}
