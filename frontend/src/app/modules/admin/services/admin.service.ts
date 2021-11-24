import { Injectable } from '@angular/core';
import {HttpClient} from "@angular/common/http";
import {MatchDto} from "../../../../models/matchdto";
import {TippsService} from "../../core/services/tipps.service";

@Injectable({
  providedIn: 'root'
})
export class AdminService {

  constructor(private http: HttpClient, private tipps: TippsService) { }


  updateMatch(dto: MatchDto) {
    this.http.put('http://localhost:5000/tipsadmin/UpdateMatchResult/'+dto.id, dto).subscribe(value => {
      this.tipps.getMatches();
    }
   );
  }

}
