import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import {TipperOverviewComponent} from "./modules/tipper/components/tipper-overview/tipper-overview.component";

const routes: Routes = [
  { path: 'tipper', component: TipperOverviewComponent},
  { path: 'admin', loadChildren: () => import('./modules/admin/admin.module').then(x => x.AdminModule)},
  { path: '**', redirectTo: 'tipper' }
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
