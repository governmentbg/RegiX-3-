import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';
import { TLAuthGuard, AUTH_PATHS, TLLoginComponent, TLPostLoginComponent } from '@tl/tl-common';
import { MainComponent } from './main/main.component';

const routes: Routes = [
  {
    path: 'main',
    component: MainComponent,
    data: { name: 'Начало' }
  },
  {
    path: 'public',
    loadChildren: () =>
      import('./public/public.module').then(m => m.PublicModule)
  },
  {
    path: AUTH_PATHS.LOGIN,
    component: TLLoginComponent,
    data: { name: 'Вход' }
  },
  {
    path: 'consumer',
    loadChildren: () =>
    import('./consumer/consumer.module').then(m => m.ConsumerModule),
     canLoad: [TLAuthGuard]
  },
  {
    path: AUTH_PATHS.POSTLOGIN,
    component: TLPostLoginComponent,
    data: { name: 'Успешен вход' }
  },
  {
    path: '**',
    redirectTo: 'main',
    pathMatch: 'full'
  }
];

@NgModule({
  imports: [RouterModule.forRoot(routes, {
    anchorScrolling: 'enabled', // scrolls to the anchor element when the URL has a fragment
    scrollOffset: [0, 64],  // scroll offset when scrolling to an element (optional)
    scrollPositionRestoration: 'enabled', // restores the previous scroll position on backward navigation
  })],
  exports: [RouterModule]
})
export class AppRoutingModule {}
