import { Articulo } from "./articulo.model";

export interface ClienteArticulo extends Articulo {
  id: number,
  clienteId: number,
  articuloId: number
}
