import { Component, OnInit, Input } from '@angular/core';
import { DrawerItemType } from './drawer-item-type';
import { DrawerItem } from './drawer-item';

@Component({
  selector: 'tl-drawer-item',
  templateUrl: './drawer-item.component.html',
  styleUrls: ['./drawer-item.component.scss']
})
export class DrawerItemComponent implements OnInit {

  @Input()
  public drawerItems: DrawerItem[];

  get DrawerTypes() { return DrawerItemType; }

  constructor() { }

  ngOnInit() {
  }

}