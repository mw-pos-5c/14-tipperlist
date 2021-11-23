import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { GoalDiffPipe } from './pipes/goal-diff.pipe';
import { FilterByGroupPipe } from './pipes/filter-by-group.pipe';
import { ResultPipe } from './pipes/result.pipe';
import { FlagComponent } from './components/flag/flag.component';
import { MatchResultComponent } from './components/match-result/match-result.component';



@NgModule({
  declarations: [
    GoalDiffPipe,
    FilterByGroupPipe,
    ResultPipe,
    FlagComponent,
    MatchResultComponent
  ],
  exports: [
    FilterByGroupPipe,
    ResultPipe,
    FlagComponent,
    GoalDiffPipe
  ],
  imports: [
    CommonModule
  ]
})
export class SharedModule { }
