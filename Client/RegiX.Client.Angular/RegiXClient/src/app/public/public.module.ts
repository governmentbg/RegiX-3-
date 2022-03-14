import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { PublicRoutingModule } from './routes/public-routing.module';
import {
  IgxLayoutModule,
  IgxButtonModule,
  IgxInputGroupModule,
  IgxIconModule,
  IgxProgressBarModule,
  IgxSelectModule,
  IgxDialogModule,
  IgxNavbarModule
} from 'igniteui-angular';
import { ReactiveFormsModule } from '@angular/forms';
import { MainComponent } from './components/main/main.component';
import { UnauthorizedComponent } from './components/unauthorized/unauthorized.component';
import { SignupComponent } from './components/signup/signup.component';
import { SharedModule } from '../shared/shared.module';
import { EDeliveryLoginComponent } from './components/e-delivery-login/e-delivery-login.component';
import { RgxModule } from '@tl-rgx/rgx-common';
import { EauthLoginComponent } from './components/eauth-login/eauth-login.component';

@NgModule({
  declarations: [MainComponent, UnauthorizedComponent, SignupComponent, EDeliveryLoginComponent, EauthLoginComponent],
  imports: [
    CommonModule,
    SharedModule,
    ReactiveFormsModule,
    PublicRoutingModule,
    IgxLayoutModule,
    IgxButtonModule,
    IgxSelectModule,
    IgxDialogModule,
    IgxInputGroupModule,
    IgxIconModule,
    IgxProgressBarModule,
    IgxNavbarModule,
    RgxModule
  ],
  exports: [
    UnauthorizedComponent
  ]
})
export class PublicModule { }
