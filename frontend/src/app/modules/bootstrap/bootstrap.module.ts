import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { BsNavbarComponent } from './components/bs-navbar/bs-navbar.component';
import { BsButtonComponent } from './components/bs-button/bs-button.component';



@NgModule({
  declarations: [
    BsNavbarComponent,
    BsButtonComponent
  ],
  exports: [
    BsNavbarComponent
  ],
  imports: [
    CommonModule
  ]
})
export class BootstrapModule { }
