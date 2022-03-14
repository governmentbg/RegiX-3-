import { Component, OnInit, Input, TemplateRef } from '@angular/core';
import {
  TlRouteArguments,
  ITLRouteReference,
} from '../../routing/route-reference';
import { Router, ActivatedRoute } from '@angular/router';

@Component({
  selector: 'tl-card',
  templateUrl: './card.component.html',
  styleUrls: ['./card.component.scss'],
})
export class CardComponent implements OnInit {
  @Input()
  public actions: {
    reference: ITLRouteReference;
    args?: TlRouteArguments;
    title?: string;
    icon?: string;
    permissions?: string[];
  }[];

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
  public contentAndList = false;

  @Input()
  public routeReference: ITLRouteReference;

  @Input()
  public title: string;

  @Input()
  public subTitle: string;

  @Input()
  public icon: string;

  @Input()
  public permissions: string[];

  @Input()
  public displayDensity  = 'cosy';
  
  @Input()
  public listLoading = false;

  @Input('cardContent')
  public cardContent: TemplateRef<any>;

  @Input('cardActions')
  public cardActions: TemplateRef<any>;
  
  @Input('cardHeaderContent')
  public cardHeaderContent: TemplateRef<any>;

  

  constructor(
    public router: Router,
    public activatedRoute: ActivatedRoute) {}

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

  onClick(reference: ITLRouteReference, args: TlRouteArguments) {
    reference.navigate(this.router, args, this.activatedRoute);
  }
}
