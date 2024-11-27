import {NgModule} from '@angular/core';
import {RouterModule, Routes} from '@angular/router';

const routes: Routes = [{path: 'home', loadChildren: () => import('./home/home.module').then(m => m.HomeModule)},
  {path: 'dashboard', loadChildren: () => import('./analytics/analytics.module').then(m => m.AnalyticsModule)},
  {path: 'logs', loadChildren: () => import('./logs/logs.module').then(m => m.LogsModule)},

  {path: '', redirectTo: '/dashboard', pathMatch: 'full'}
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule {
}
