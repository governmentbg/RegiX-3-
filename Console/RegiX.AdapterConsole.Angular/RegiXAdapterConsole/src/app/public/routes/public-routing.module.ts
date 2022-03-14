import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { UnauthorizedComponent } from '../components/unauthorized/unauthorized.component';
import { MainComponent } from '../components/main/main.component';
import { SignupComponent } from '../components/signup/signup.component';
import { TLPostLoginComponent, TLLoginComponent, AUTH_PATHS } from '@tl/tl-common';

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
    component: TLPostLoginComponent
  },
  {
    path: 'signup',
    component: SignupComponent,
    data: { name: 'Регистрация' }
  },
  {
    path: 'unauthorized',
    component: UnauthorizedComponent
  }
];

@NgModule({
  imports: [RouterModule.forChild(routes)],
  exports: [RouterModule]
})
export class PublicRoutingModule {}
