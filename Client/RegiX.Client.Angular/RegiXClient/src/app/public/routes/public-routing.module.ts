import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { UnauthorizedComponent } from '../components/unauthorized/unauthorized.component';
import { MainComponent } from '../components/main/main.component';
import { SignupComponent } from '../components/signup/signup.component';
import { TLPostLoginComponent, TLLoginComponent, AUTH_PATHS, TLLoginErrorComponent } from '@tl/tl-common';
import { EDeliveryLoginComponent } from '../components/e-delivery-login/e-delivery-login.component';
import { EauthLoginComponent } from '../components/eauth-login/eauth-login.component';

const routes: Routes = [
  {
    path: '',
    redirectTo: AUTH_PATHS.MAIN,
    pathMatch: 'full'
  },
  {
    path: AUTH_PATHS.MAIN,
    component: MainComponent,
    data: { name: 'Начало' }
  },
  {
    path: AUTH_PATHS.LOGIN,
    component: TLLoginComponent,
    data: { name: 'Вход' }
  },
  {
    path: AUTH_PATHS.POSTLOGIN,
    component: TLPostLoginComponent,
    data: { name: 'Успешен вход' }
  },
  {
    path: AUTH_PATHS.LOGIN_ERROR,
    component: TLLoginErrorComponent,
    data: { name: 'Грешка при вход' }
  },
  {
    path: 'unauthorized',
    component: UnauthorizedComponent
  },
  {
    path: 'signup',
    component: SignupComponent,
    data: { name: 'Регистрация' }
  },
  {
    path: 'Account/LoginToken',
    component: EDeliveryLoginComponent
  },
  {
    path: 'eauth',
    component: EauthLoginComponent
  }
];

@NgModule({
  imports: [RouterModule.forChild(routes)],
  exports: [RouterModule]
})
export class PublicRoutingModule {}
