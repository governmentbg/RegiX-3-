import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';
import { TLAuthGuard, AUTH_PATHS } from '@tl/tl-common';


const routes: Routes = [
  {
    path: '',
    loadChildren: () =>
      import('./public/public.module').then(m => m.PublicModule)
  },
  {
    path: AUTH_PATHS.AUTHENTICATED,
    loadChildren: () => import('./admin/admin.module').then(m => m.AdminModule),
    canLoad: [TLAuthGuard]
  },
  {
    path: '**',
    redirectTo: AUTH_PATHS.MAIN,
    pathMatch: 'full'
  }
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
