import { NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';

import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
import {CoreModule} from "./modules/core/core.module";
import {BootstrapModule} from "./modules/bootstrap/bootstrap.module";
import {TipperModule} from "./modules/tipper/tipper.module";
import {SharedModule} from "./modules/shared/shared.module";

@NgModule({
  declarations: [
    AppComponent
  ],
  imports: [
    BrowserModule,
    AppRoutingModule,
    BootstrapModule,
    SharedModule,
    CoreModule,
    TipperModule
  ],
  providers: [],
  bootstrap: [AppComponent]
})
export class AppModule { }
