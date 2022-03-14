import { Component, OnInit } from '@angular/core';
import { Input } from '@angular/core';import { TlRouteArguments, ITLRouteReference } from '../../routing/route-reference';
import { Router } from '@angular/router';
import { ActivatedRoute } from '@angular/router';
import { NGXLogger } from 'ngx-logger';
;

@Component({
  selector: 'tl-reference-button',
  templateUrl: './reference-button.component.html',
  styleUrls: ['./reference-button.component.scss']
})
export class ReferenceButtonComponent implements OnInit {

  @Input()
  public routeReference: ITLRouteReference;

  @Input()
  public title: string;

  @Input()
  public isDisabled: boolean = false;
  
  @Input()
  public buttonType = 'raised';

  public get IgxButtonType(): string {
    switch (this.buttonType) {
      case 'action-button':
        return 'icon';
      default : 
        return this.buttonType;
    }
  }
  public get ButtonClass(): string {
    switch (this.buttonType) {
      case 'action-button':
        return 'table-action-button';
      case 'raised':
        return 'raised';
        case 'fab':
          return 'fab-button';
      default : 
        return '';
    }
  }

  @Input()
  public icon: string;

  @Input()
  public permissions: string[];

  @Input()
  public routeArguments: TlRouteArguments;

  constructor(
    public router: Router,
    public activatedRoute: ActivatedRoute,
    private logger: NGXLogger
  ) { }

  ngOnInit(): void {
    if (!this.title){
      this.title = this.routeReference.title;
    }
    if (!this.icon) {
      this.icon = this.routeReference.icon;
    }
    if (!this.permissions){
      this.permissions = this.routeReference.permissions;
    }
  }

  onClick(): void{
    this.logger.debug(`Navigating to: ${this.routeReference.route} with arguments: ${this.routeArguments}`)
    this.routeReference.navigate(this.router, this.routeArguments, this.activatedRoute);
  }

  public showTitile(): boolean {
    return this.buttonType !== 'fab' && this.buttonType !== 'action-button' ;
  }
}
