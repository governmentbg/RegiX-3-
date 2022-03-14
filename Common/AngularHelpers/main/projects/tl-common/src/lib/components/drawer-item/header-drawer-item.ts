import { DrawerItem } from './drawer-item';
import { DrawerItemType } from './drawer-item-type';

export class HeaderDrawerItem extends DrawerItem {
    constructor(txt: string, pms: string|string[], tooltip?: string) {
      super(
      {
        type: DrawerItemType.Header,
        permissions: pms,
        text: txt,
        tooltip: tooltip
      });
    }
  }