import {Component, EventEmitter, Input, OnInit, Output} from '@angular/core';
import {TipperDto} from "../../../../../models/tipperdto";

@Component({
  selector: 'app-tipper-names',
  templateUrl: './tipper-names.component.html',
  styleUrls: ['./tipper-names.component.scss']
})
export class TipperNamesComponent implements OnInit {

  @Input() tippers: TipperDto[] = [];
  @Input() selectedGroup = ''

  @Output() tipperSelected = new EventEmitter<TipperDto>();

  constructor() { }

  ngOnInit(): void {
  }

}
