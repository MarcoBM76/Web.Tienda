import { Component, OnInit } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Articulo } from './models/articulo.model';


export class response {
  message: string = ''
}

@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.css']
})
export class AppComponent {

  ngOnInit() {
  }
}
