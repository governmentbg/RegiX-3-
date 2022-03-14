import { DrawerItem } from './drawer-item';
import { DrawerItemType } from './drawer-item-type';

export class NavigationDrawerItem extends DrawerItem {
    constructor(txt: string, pms: string|string[], link: string|string[], icn?: string, tooltip?: string) {
      super(
      {
        type: DrawerItemType.Naivgation,
        permissions: pms,
        routerLink: link,
        routerLinkActive: ['active-menu-item'],
        routerLinkActiveOptions: { exact: true },
        icon: icn,
        text: txt,
        tooltip: tooltip
      });
    }
  }