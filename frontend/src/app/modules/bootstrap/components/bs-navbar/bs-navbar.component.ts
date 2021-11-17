import {Component, EventEmitter, Input, OnInit, Output} from '@angular/core';

@Component({
  selector: 'app-bs-navbar',
  templateUrl: './bs-navbar.component.html',
  styleUrls: ['./bs-navbar.component.scss']
})
export class BsNavbarComponent implements OnInit {

  @Input() title: string = 'Navbar';
  @Input() navItems: string[] = [];

  @Output() navItemClick = new EventEmitter<number>();

  constructor() { }

  ngOnInit(): void {
  }

}
