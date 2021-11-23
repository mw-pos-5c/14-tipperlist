import { Component, OnInit } from '@angular/core';
import {TippsService} from "../../../core/services/tipps.service";
import {TipperDto} from "../../../../../models/tipperdto";

@Component({
  selector: 'app-tipper-overview',
  templateUrl: './tipper-overview.component.html',
  styleUrls: ['./tipper-overview.component.scss']
})
export class TipperOverviewComponent implements OnInit {

  constructor(public service: TippsService) { }

  selectedGroup = '';
  selectedName = '';

  minGoal = 0;

  ngOnInit(): void {
    this.service.getTippers();
    this.service.getMatches();
  }

  tipperSelected(tipper: TipperDto) {
    this.selectedName = tipper.name;
    this.service.getTipps(tipper);
  }

  selectGroup(s: string) {
    this.selectedGroup = s;
  }
}
