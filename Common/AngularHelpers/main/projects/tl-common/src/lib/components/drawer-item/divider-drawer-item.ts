import { DrawerItem } from './drawer-item';
import { DrawerItemType } from './drawer-item-type';

export class DividerDrawerItem extends DrawerItem {
    constructor(pms: string|string[]) {
      super(
      {
        type: DrawerItemType.Divider,
        permissions: pms,
      });
    }
  }