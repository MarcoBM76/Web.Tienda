import { Component } from '@angular/core';
import { Router } from '@angular/router';
import { CarritoService } from '../../../service/carrito.service';
import { AuthService } from '../../../service/auth.service';

@Component({
  selector: 'app-nav',
  templateUrl: './nav.component.html',
  styleUrls: ['./nav.component.css']
})
export class NavComponent {

  totalArticulos: number = 0;

  constructor(public auth: AuthService, private router: Router, private _carritoService: CarritoService) { }

  ngOnInit() {
    this.getCarrito(2);
  }



  getCarrito(clienteId: number) {
    this._carritoService.getAll(clienteId).subscribe({
      next: (response) => {
        this.totalArticulos = response.length;
      },
      error: (error) => { }
    });
  }

  logout() {
    this.auth.logout();
    this.router.navigate(['/login']);
  }

}
