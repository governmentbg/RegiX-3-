import { DrawerItemType } from './drawer-item-type';

export class DrawerItem {
    type: DrawerItemType;
    permissions?: string|string[];
    routerLink?: string|string[];
    routerLinkActive?: string[];
    routerLinkActiveOptions?: any;
    children?: DrawerItem[];
    loaded?: boolean;
    icon?: string;
    text?: string;
    tooltip?: string;
  
    constructor(init?: DrawerItem) {
      if (init) {
        this.type = init.type;
        this.permissions = init.permissions;
        this.routerLink = init.routerLink;
        this.routerLinkActive = init.routerLinkActive;
        this.routerLinkActiveOptions = init.routerLinkActiveOptions;
        this.children = init.children;
        this.loaded = init.loaded;
        this.icon = init.icon;
        this.text = init.text;
        this.tooltip = init.tooltip;
      }
    }
  }