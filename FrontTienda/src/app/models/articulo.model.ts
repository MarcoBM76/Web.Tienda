import { Tienda } from "./tienda";

export interface Articulo {
  articuloId: number;
  codigo: string;
  descripcion: string;
  precio: number;
  imagen: string;
  stock: number;
}

export interface AddArticulo extends Articulo {
  tiendaId: number
}


export interface ArticuloTienda {
  id?: number;
  articuloId: number;
  idTienda: number;
  fecha: Date;
  articulo: Articulo;
  tienda: Tienda;
}
