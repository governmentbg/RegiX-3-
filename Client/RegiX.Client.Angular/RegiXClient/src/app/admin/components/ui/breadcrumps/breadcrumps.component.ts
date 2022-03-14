import { Component, OnInit, OnDestroy, Input } from '@angular/core';
import { ActivatedRoute, Router } from '@angular/router';

import { NavigationEnd } from '@angular/router';
import { filter } from 'rxjs/operators';
import { Subscription } from 'rxjs';

@Component({
  selector: 'app-breadcrumps',
  templateUrl: './breadcrumps.component.html',
  styleUrls: ['./breadcrumps.component.scss']
})
export class BreadcrumpsComponent implements OnInit, OnDestroy {
  breadcrumbs: { name: string; url: string, icon: string}[] = [];

  @Input()
  defaultBaseSegment: string;

  subscription: Subscription;

  constructor(private activatedRoute: ActivatedRoute, private router: Router) {}

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
      baseSegment = '';
      data.snapshot.url.forEach(element => {
        baseSegment = '/' + element;
      });
    }
    let theUrl: string = '/' + baseSegment;
    theBreadcrumbs.push({
      url: theUrl,
      name: data.snapshot.data['name'],
      icon: data.snapshot.data['icon']
    });
    while (data.firstChild) {
      data = data.firstChild;
      if (data.snapshot.url.length > 0) {
        data.snapshot.url.forEach(element => {
          theUrl = theUrl + '/' + element;
        });
        const datum = {
          url: theUrl,
          name: data.snapshot.data['name'],
          icon: data.snapshot.data['icon']
        };
        theBreadcrumbs.push(datum);
      }
    }
    this.breadcrumbs = theBreadcrumbs;
  }
}
