import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { PublicRoutingModule } from './routes/public-routing.module';
import {
  IgxLayoutModule,
  IgxButtonModule,
  IgxInputGroupModule,
  IgxIconModule,
  IgxNavbarModule,
  IgxProgressBarModule,
  IgxSelectModule,
  IgxDialogModule
} from 'igniteui-angular';
import { ReactiveFormsModule } from '@angular/forms';
import { UnauthorizedComponent } from './components/unauthorized/unauthorized.component';
import { MainComponent } from './components/main/main.component';
import { SignupComponent } from './components/signup/signup.component';
import { SharedModule } from '../shared/shared.module';
import { RgxModule } from '@tl-rgx/rgx-common';

@NgModule({
  declarations: [UnauthorizedComponent, MainComponent, SignupComponent],
  imports: [
    CommonModule,
    SharedModule,
    ReactiveFormsModule,
    PublicRoutingModule,
    IgxLayoutModule,
    IgxDialogModule,
    IgxSelectModule,
    IgxButtonModule,
    IgxInputGroupModule,
    IgxIconModule,
    IgxProgressBarModule,
    RgxModule
  ]
})
export class PublicModule {}
