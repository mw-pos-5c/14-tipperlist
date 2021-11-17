import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { TipperOverviewComponent } from './components/tipper-overview/tipper-overview.component';
import { TipperNamesComponent } from './components/tipper-names/tipper-names.component';
import { TippedMatchesComponent } from './components/tipped-matches/tipped-matches.component';



@NgModule({
  declarations: [
    TipperOverviewComponent,
    TipperNamesComponent,
    TippedMatchesComponent
  ],
  imports: [
    CommonModule
  ]
})
export class TipperModule { }
