import { Component, OnInit } from '@angular/core';
import { HttpClient } from '@angular/common/http';

export class response {
  message: string = ''
}

@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.css']
})
export class AppComponent {
  title = 'FrontTienda';

  mensaje: string = '';

  constructor(private http: HttpClient) { }

  ngOnInit() {
    this.getCliente();
  }

  getCliente() {
    this.http.get<response>('https://localhost:7141/api/cliente').subscribe(
      (data) => {
        console.log('Cliente data:', data.message);
        this.mensaje = data.message;
      },
      (error:string) => {
        console.error('Error fetching cliente data:', error);
      }
    );
  }

}
