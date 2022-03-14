import { Component, OnInit, Input, TemplateRef } from '@angular/core';
import { TlRouteArguments, ITLRouteReference } from '../../routing/route-reference';

@Component({
  selector: 'tl-wrapping-card',
  templateUrl: './wrapping-card.component.html',
  styleUrls: ['./wrapping-card.component.scss']
})
export class WrappingCardComponent implements OnInit {
  
  @Input()
  public fabAction: ITLRouteReference;
  
  @Input()
  public fabArguments: TlRouteArguments;

  @Input()
  public actions: {
    reference: ITLRouteReference;
    args?: TlRouteArguments;
    title?: string;
    icon?: string;
    permissions?: string[];
  }[];
  
  @Input()
  public title: string;

  @Input()
  public subTitle: string;

  @Input()
  public icon: string;

  @Input()
  public isPresent: boolean = true;  

  @Input('cardActions')
  public cardActions: TemplateRef<any>;

  @Input('cardHeaderContent')
  public cardHeaderContent: TemplateRef<any>;

  constructor() { }

  ngOnInit(): void {
  }
}
