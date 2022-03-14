import { Component, OnInit, Input } from '@angular/core';
import {
  ITLRouteReference,
  TlRouteArguments,
} from '../../routing/route-reference';
import { Router, ActivatedRoute } from '@angular/router';

@Component({
  selector: 'tl-reference-list',
  templateUrl: './reference-list.component.html',
  styleUrls: ['./reference-list.component.scss'],
})
export class ReferenceListComponent implements OnInit {
  @Input()
  public listItems: {
    reference: ITLRouteReference;
    args?: TlRouteArguments;
    title?: string;
    icon?: string;
    permissions?: string[];
    badge?: { type: string, icon: string};
  }[];

  @Input()
  public displayDensity = 'cosy';

  constructor(public router: Router, public activatedRoute: ActivatedRoute) {}

  ngOnInit(): void {}

  onClick(itemRef: {
    reference: ITLRouteReference;
    args?: TlRouteArguments;
    title?: string;
    icon?: string;
    permissions?: string[];
  }) {
    itemRef.reference.navigate(this.router, itemRef.args, this.activatedRoute);
  }
}
