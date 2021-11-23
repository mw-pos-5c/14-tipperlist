import {Component, Input, OnInit} from '@angular/core';
import {MatchDto} from "../../../../../models/matchdto";

@Component({
  selector: 'app-flag',
  templateUrl: './flag.component.html',
  styleUrls: ['./flag.component.scss']
})
export class FlagComponent implements OnInit {

  @Input() match!: MatchDto;

  constructor() { }

  // Flags map from Leon Sterner
  flags = {
    Ita: 'it',
    Wal: 'wales',
    Den: 'dk',
    Bel: 'be',
    Eng: 'england',
    Srb: 'rs',
    Aut: 'at',
    Ned: 'nl',
    Pol: 'pl',
    Esp: 'es',
    Hun: 'hu',
    Fra: 'fr',
    Fin: 'fi',
    Tur: 'tr',
    Ukr: 'ua',
    Swe: 'se',
    Cro: 'hr',
    Por: 'pt',
    Sui: 'ch',
    Geo: 'ge',
    Rus: 'ru',
    Cze: 'cz',
    Irl: 'ie',
    Ger: 'de'
  };

  classList1 = '';
  classList2 = '';



  ngOnInit(): void {
    // @ts-ignore
    this.classList1 = `phoca-flag ${this.flags[this.match.team1Name]}`;
    // @ts-ignore
    this.classList2 = `phoca-flag ${this.flags[this.match.team2Name]}`;
  }

}
