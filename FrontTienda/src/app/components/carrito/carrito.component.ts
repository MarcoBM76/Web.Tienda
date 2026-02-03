import { Component } from '@angular/core';
import { CarritoService } from '../../service/carrito.service';
import { Articulo } from '../../models/articulo.model';
import { ClienteArticulo } from '../../models/ClienteArticulo';


export interface ArticuloCarrito extends ClienteArticulo {
  cantidad: number;
  subtotal: number;
}

@Component({
  selector: 'app-carrito',
  templateUrl: './carrito.component.html',
  styleUrls: ['./carrito.component.css']
})
export class CarritoComponent {

  articulos: ClienteArticulo[] = [];
  constructor(private _carritoService: CarritoService) { }

  ngOnInit() {
    this.getCarrito(2);
  }

  getCarrito(clienteId: number) {
    this._carritoService.getAll(clienteId).subscribe({
      next: (response) => {
        this.articulos = response;
        console.log(this.articulos)
      },
      error: (error) => { }
    });
  }

  getTotal(): number {
    return this.articulos.reduce((acc, obj) => acc + obj.precio, 0);
  }


  get articulosAgrupados(): ArticuloCarrito[] {
    const mapa = new Map<number, ArticuloCarrito>();

    this.articulos.forEach(art => {
      if (mapa.has(art.articuloId)) {
        const item = mapa.get(art.articuloId)!;
        item.cantidad++;
        item.subtotal = item.cantidad * item.precio;
      } else {
        mapa.set(art.articuloId, { ...art, cantidad: 1, subtotal: art.precio });
      }
    });

    return Array.from(mapa.values());
  }

  deleteArticulo(id: number) {
    this._carritoService.delete(id).subscribe({
      next: (response) => {
        this.getCarrito(2);
      },
      error: (error) => { }
    });
  }
}
