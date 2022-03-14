import { Component, OnInit, Input } from '@angular/core';
import {
  ITLRouteReference,
  TlRouteArguments,
} from '../../routing/route-reference';
import { Router, ActivatedRoute } from '@angular/router';

@Component({
  selector: 'tl-reference-item',
  templateUrl: './reference-item.component.html',
  styleUrls: ['./reference-item.component.scss'],
})
export class ReferenceItemComponent implements OnInit {
  @Input()
  public routeReference: ITLRouteReference;

  @Input()
  public routeArguments: TlRouteArguments;

  @Input()
  public title: string;

  @Input()
  public icon: string;

  @Input()
  public permissions: string[];

  constructor(public router: Router, public activatedRoute: ActivatedRoute) {}

  ngOnInit(): void {
    if (!this.title) {
      this.title = this.routeReference.title;
    }
    if (!this.icon) {
      this.icon = this.routeReference.icon;
    }
    if (!this.permissions) {
      this.permissions = this.routeReference.permissions;
    }
  }

  onClick() {
    this.routeReference.navigate(
      this.router,
      this.routeArguments,
      this.activatedRoute
    );
  }
}
