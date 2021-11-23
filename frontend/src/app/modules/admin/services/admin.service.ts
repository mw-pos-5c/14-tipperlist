import { Injectable } from '@angular/core';
import {HttpClient} from "@angular/common/http";
import {MatchDto} from "../../../../models/matchdto";

@Injectable({
  providedIn: 'root'
})
export class AdminService {

  constructor(private http: HttpClient) { }


  updateMatch(dto: MatchDto) {
    this.http.put('http://localhost:5000/tipsadmin/UpdateMatchResult/'+dto.id, dto).subscribe({

    });
  }

}
