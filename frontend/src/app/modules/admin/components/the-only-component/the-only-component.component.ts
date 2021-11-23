import { Component, OnInit } from '@angular/core';
import {TippsService} from "../../../core/services/tipps.service";
import {MatchDto} from "../../../../../models/matchdto";
import {AdminService} from "../../services/admin.service";

@Component({
  selector: 'app-the-only-component',
  templateUrl: './the-only-component.component.html',
  styleUrls: ['./the-only-component.component.scss']
})
export class TheOnlyComponentComponent implements OnInit {

  constructor(public service: TippsService, public adminService: AdminService) { }

  ngOnInit(): void {
    this.service.getMatches();
  }

  save(match: MatchDto, a: number, b: number) {
      match.shot = a;
      match.received = b;

      this.adminService.updateMatch(match)

  }
}
