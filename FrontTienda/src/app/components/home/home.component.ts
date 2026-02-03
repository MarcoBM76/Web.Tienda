import { Component } from '@angular/core';
import { Articulo } from '../../models/articulo.model';
import { HttpClient } from '@angular/common/http';
import { Router } from '@angular/router';
import { CarritoService } from '../../service/carrito.service';
import { ClienteArticulo } from '../../models/ClienteArticulo';

@Component({
  selector: 'app-home',
  templateUrl: './home.component.html',
  styleUrls: ['./home.component.css']
})
export class HomeComponent {

  public articulos: Articulo[] = [];
  readonly API_URL = 'https://localhost:7141/api/Articulo';

  title = 'FrontTienda';

  bootstrap: any;

  constructor(private http: HttpClient,
    private router: Router,
    private _carritoService: CarritoService) {
  }

  ngOnInit() {
    this.getAllArticulos();

  }

  getAllArticulos() {
    this.http.get<Articulo[]>(this.API_URL).subscribe({
      next: (data) => this.articulos = data,
      error: (err) => console.error('Error al cargar artículos', err)
    });
  }

  eliminarArticulo(id: number | undefined) {
    if (id && confirm('¿Estás seguro de eliminar este artículo?')) {
      this.http.delete(`${this.API_URL}/${id}`).subscribe({
        next: () => {
          this.getAllArticulos();
        },
        error: (err) => console.error('Error al eliminar:', err)
      });

    }
  }

  addCarrito(articuloId: number) {
    this._carritoService.add({ clienteId: 2, articuloId: articuloId } as ClienteArticulo).subscribe({
      next: (data) => { },
      error: (err) => console.error('Error al agregar al carrito:', err)
    });

    const modalElement = document.getElementById('modalCarrito');
    const modalBus = new this.bootstrap.Modal(modalElement);
    modalBus.show();
  }
}

