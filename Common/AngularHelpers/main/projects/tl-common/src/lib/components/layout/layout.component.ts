import { Component, OnInit, OnDestroy, AfterViewInit, ViewChild, ChangeDetectorRef, Input, TemplateRef, Injector } from '@angular/core';
import { Location } from '@angular/common';
import { IgxNavigationDrawerComponent, IgxToastPosition, IgxToastComponent } from 'igniteui-angular';
import { Subscription } from 'rxjs';
import { Router } from '@angular/router';
import { ToastService } from '../../services/toast.service';
import { BackService } from '../../services/back.service';
import { DrawerItem } from '../drawer-item/drawer-item';

@Component({
  selector: 'tl-layout',
  templateUrl: './layout.component.html',
  styleUrls: ['./layout.component.scss']
})
export class LayoutComponent  implements OnInit, OnDestroy, AfterViewInit {
  @ViewChild(IgxNavigationDrawerComponent, { static: true })
  public drawer: IgxNavigationDrawerComponent;

  @Input('headerContent')
  headerContent: TemplateRef<any>;

  @Input('navBarContent')
  navBarContent: TemplateRef<any>;
  
  @Input('mainContent')
  mainContent: TemplateRef<any>;
  
  @Input('defaultBaseSegment')
  defaultBaseSegment =  'admin';

  @Input('drawerState')
  public drawerState = {
    miniTemplate: false,
    open: false,
    pin: true
  };
  
  @Input()
  public drawerItems: DrawerItem[];

  @Input()
  public applicationTitle: string;

  public toastPosition: IgxToastPosition;
  public toastMessage: string;

  toastSubscription: Subscription;

  errorMessage = null;

  @ViewChild('toast')
  toast: IgxToastComponent;

  protected router: Router;
  protected toastService: ToastService;
  protected backService: BackService;
  protected location: Location;
  protected changeDetectorRef: ChangeDetectorRef;

  constructor(
    protected injector: Injector
  ) {
    
    this.router = this.injector.get<Router>(Router as any);
    this.toastService = this.injector.get<ToastService>(ToastService as any);
    this.backService = this.injector.get<BackService>(BackService as any);
    this.location = this.injector.get<Location>(Location as any);
    this.changeDetectorRef = this.injector.get<ChangeDetectorRef>(ChangeDetectorRef as any);
  }

  ngOnInit() {
    this.toastSubscription = this.toastService.toastSubject.subscribe(
      message => {
        this.toastMessage = message;
        this.toastPosition = this.toastService.toastPosition;
        this.toast.show();
      }
    );
  }
  toggleDrawer(){
    this.drawerState.open = !this.drawerState.open;
  }

  ngOnDestroy() {
    if (this.toastSubscription) {
      this.toastSubscription.unsubscribe();
    }
  }

  ngAfterViewInit() {
    // const elem = document.getElementById('content-wrapper');
    // elem.onscroll = this.scrollFunction;
    // window.onscroll = this.scrollFunction;
  }

  // scrollFunction() {
  //   const elem = document.getElementById('content-wrapper');
  //   if (
  //     document.body.scrollTop > 20 ||
  //     document.documentElement.scrollTop > 20 ||
  //     elem.scrollTop > 20 ||
  //     elem.scrollTop > 20
  //   ) {
  //     document.getElementById('scroll-top-wrapper').classList.add('show');
  //   } else {
  //     document.getElementById('scroll-top-wrapper').classList.remove('show');
  //   }
  // }

  // scrollTop() {
  //   const content = document.getElementById('content-wrapper');
  //   content.scrollTo(0, 0);
  //   window.scrollTo(0, 0);
  // }
}
