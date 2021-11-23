import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import {TheOnlyComponentComponent} from "./components/the-only-component/the-only-component.component";

const routes: Routes = [
  { path: '', component: TheOnlyComponentComponent}
];

@NgModule({
  imports: [RouterModule.forChild(routes)],
  exports: [RouterModule]
})
export class AdminRoutingModule { }
