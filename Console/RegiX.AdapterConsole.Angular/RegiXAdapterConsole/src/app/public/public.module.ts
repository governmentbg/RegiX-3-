import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { PublicRoutingModule } from './routes/public-routing.module';
import {
  IgxLayoutModule,
  IgxButtonModule,
  IgxInputGroupModule,
  IgxIconModule,
  IgxProgressBarModule
} from 'igniteui-angular';
import { ReactiveFormsModule } from '@angular/forms';
import { MainComponent } from './components/main/main.component';
import { UnauthorizedComponent } from './components/unauthorized/unauthorized.component';
import { SignupComponent } from './components/signup/signup.component';
import { SharedModule } from '../shared/shared.module';
import { RgxModule } from '@tl-rgx/rgx-common';


@NgModule({
  declarations: [
    MainComponent,
    UnauthorizedComponent,
    SignupComponent
  ],
  imports: [
    CommonModule,
    SharedModule,
    ReactiveFormsModule,
    PublicRoutingModule,
    IgxLayoutModule,
    IgxButtonModule,
    IgxInputGroupModule,
    IgxIconModule,
    IgxProgressBarModule,
    RgxModule
  ],
  exports: [UnauthorizedComponent]
})
export class PublicModule {}
