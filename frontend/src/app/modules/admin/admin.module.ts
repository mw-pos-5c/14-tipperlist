import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';

import { AdminRoutingModule } from './admin-routing.module';
import { TheOnlyComponentComponent } from './components/the-only-component/the-only-component.component';
import {SharedModule} from "../shared/shared.module";
import {BootstrapModule} from "../bootstrap/bootstrap.module";
import {CoreModule} from "../core/core.module";


@NgModule({
  declarations: [
    TheOnlyComponentComponent
  ],
  imports: [
    CommonModule,
    AdminRoutingModule,
    SharedModule,
    CoreModule,
    BootstrapModule
  ]
})
export class AdminModule { }
