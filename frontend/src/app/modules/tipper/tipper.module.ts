import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { TipperOverviewComponent } from './components/tipper-overview/tipper-overview.component';
import { TipperNamesComponent } from './components/tipper-names/tipper-names.component';
import { TippedMatchesComponent } from './components/tipped-matches/tipped-matches.component';
import {BootstrapModule} from "../bootstrap/bootstrap.module";
import {CoreModule} from "../core/core.module";
import {SharedModule} from "../shared/shared.module";
import {FormsModule} from "@angular/forms";



@NgModule({
  declarations: [
    TipperOverviewComponent,
    TipperNamesComponent,
    TippedMatchesComponent
  ],
    imports: [
        CommonModule,
        FormsModule,
        BootstrapModule,
        SharedModule
    ]
})
export class TipperModule { }
