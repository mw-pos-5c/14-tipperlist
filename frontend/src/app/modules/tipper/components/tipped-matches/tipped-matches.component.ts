import {Component, Input, OnInit} from '@angular/core';
import {SingleTippDto} from "../../../../../models/singletippdto";
import {TippsService} from "../../../core/services/tipps.service";
import {MatchDto} from "../../../../../models/matchdto";

@Component({
  selector: 'app-tipped-matches',
  templateUrl: './tipped-matches.component.html',
  styleUrls: ['./tipped-matches.component.scss']
})
export class TippedMatchesComponent implements OnInit {

  @Input() matches: MatchDto[] = [];
  @Input() tipps: SingleTippDto[] = [];

  @Input() minDiff = 0;

  constructor() { }

  ngOnInit(): void {
  }

  getMatchTipp(seq: any): MatchDto {
    return <MatchDto>this.matches.find(value => value.seq === seq);
  }
}
