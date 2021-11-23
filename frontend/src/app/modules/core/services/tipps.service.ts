import { Injectable } from '@angular/core';
import {HttpClient} from "@angular/common/http";
import {TipperDto} from "../../../../models/tipperdto";
import {MatchDto} from "../../../../models/matchdto";
import {SingleTippDto} from "../../../../models/singletippdto";
import {TippDto} from "../../../../models/tippdto";

@Injectable({
  providedIn: 'root'
})
export class TippsService {

  constructor(private http: HttpClient) { }

  tipperGroups: string[] = [];
  tippers: TipperDto[] = [];
  matches: MatchDto[] = [];

  tipps: SingleTippDto[] = [];

  private url = 'http://localhost:5000/';




  getTippers() {
    this.http.get<TipperDto[]>(this.url + 'tips/tippernames').subscribe(value => {
      this.tippers = value;
      this.tipperGroups = [];
      for (let tipper of value) {
        for (let group of tipper.groups.split(',')) {
          if (group.length < 1) continue;
          if (!this.tipperGroups.includes(group)) {
            this.tipperGroups.push(group);
          }
        }
      }
    });
  }

  getTipps(tipper: TipperDto) {
    this.http.get<TippDto>(this.url + 'tips/tipps/'+tipper.id).subscribe(value => {
      console.log(value);
      this.tipps = value.tipps;
    })
  }

  getMatches() {
    this.http.get<MatchDto[]>(this.url + 'tips/matchresults').subscribe(value => {
      this.matches = value;
    });
  }
}
