import { Component } from '@angular/core';
import {Router} from "@angular/router";

@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.scss']
})
export class AppComponent {

  constructor(private router: Router) {}

  nav = ['Tipper', 'Admin'];
  routes = ['tipper', 'admin'];

  switchPage(index: number) {
    this.router.navigate([this.routes[index]])
  }


}
