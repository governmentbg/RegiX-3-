import { Component, OnInit, OnDestroy, Input } from '@angular/core';
import { Subscription } from 'rxjs';
import { filter } from 'rxjs/operators';
import { ActivatedRoute, Router, NavigationEnd } from '@angular/router';

@Component({
  selector: 'tl-breadcrumbs',
  templateUrl: './breadcrumbs.component.html',
  styleUrls: ['./breadcrumbs.component.scss']
})
export class BreadcrumbsComponent  implements OnInit, OnDestroy {
  breadcrumbs: {
    name: string;
    url: string[],
    removeFilterUrl: string[],
    icon: string,
    filter: boolean}[] = [];


  @Input()
  defaultBaseSegment: string;

  subscription: Subscription;
  activatedRoute: ActivatedRoute

  constructor(public activatedRouteParam: ActivatedRoute, private router: Router) {
    this.activatedRoute = activatedRouteParam;
  }

  ngOnInit() {
    this.buildBreadcrumps(this.activatedRoute);

    this.subscription = this.router.events
      .pipe(filter(event => event instanceof NavigationEnd))
      .subscribe(() => {
        this.buildBreadcrumps(this.activatedRoute);
      });
  }

  ngOnDestroy() {
    if (this.subscription) {
      this.subscription.unsubscribe();
    }
  }

  private buildBreadcrumps(data: any) {
    const theBreadcrumbs = [];
    // push root element
    let baseSegment = null;
    if (data.snapshot.url.length === 0) {
      baseSegment = this.defaultBaseSegment;
    } else {
      data.snapshot.url.forEach(element => {
        baseSegment = element.path;
      });
    }
    let theUrl: string[] = ['/', baseSegment];
    theBreadcrumbs.push({
      url: [...theUrl],
      name: data.snapshot.data['name'],
      icon: data.snapshot.data['icon']
    });
    while (data.firstChild) {
      data = data.firstChild;
      if (data.snapshot.url.length > 0) {
        let rmvFilterUrl = [...theUrl];
        data.snapshot.url.forEach(element => {
          theUrl.push(element.path);
        });
        const isFilterable = this.shouldFilter(data.snapshot);
        const isBreadcrumbDisabled = this.isBreadcrumbDisabled(data.snapshot);
        if (isFilterable) {
          rmvFilterUrl.push('-');
          rmvFilterUrl.push(data.snapshot.url[1].path);
        }
        const datum = {
          url: [...theUrl],
          removeFilterUrl: rmvFilterUrl,
          name: data.snapshot.data['name'],
          icon: data.snapshot.data['icon'],
          filter: isFilterable,
          isDisabled: isBreadcrumbDisabled
        };
        const isHidden = data.snapshot.data['hideRoute'];
        if (!isHidden) {
          theBreadcrumbs.push(datum);
        }
      }
    }
    this.breadcrumbs = theBreadcrumbs;
  }
  
  public shouldFilter(snapshot: any): boolean {
    return snapshot.data['isFilterable'] &&
      snapshot.url.length === 2 &&
      snapshot.url[0].path !== '-';
  }

  public isBreadcrumbDisabled(snapshot: any): boolean {
    //if param is missing button is active 
    if(snapshot.data['isFilterIconActive'] === null ||
       snapshot.data['isFilterIconActive'] === undefined){
      return false;
    }
    
    return snapshot.data['isFilterIconActive']; 
  }

  public removeFilter(event: any, breadcrumb: {removeFilterUrl: string[]}) {
    event.originalEvent.stopPropagation();
    this.router.navigate(breadcrumb.removeFilterUrl);
  }
}