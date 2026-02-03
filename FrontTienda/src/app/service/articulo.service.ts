import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';
import { AddArticulo, Articulo, ArticuloTienda } from '../models/articulo.model';

@Injectable({ providedIn: 'root' })
export class ArticuloService {
  private url = 'https://localhost:7141/api/Articulo';
  private urlArticuloTienda = 'https://localhost:7141/api/ArticuloTienda';

  constructor(private http: HttpClient) {}

  getAll(): Observable<Articulo[]> { return this.http.get<Articulo[]>(this.url); }
  add(art: AddArticulo): Observable<Articulo> { return this.http.post<AddArticulo>(this.url, art); }
  update(id: number, art: Articulo): Observable<any> { return this.http.put(`${this.url}/${id}`, art); }
  delete(id: number): Observable<any> { return this.http.delete(`${this.url}/${id}`); }

  getAllArticuloTienda(): Observable<ArticuloTienda[]> { return this.http.get<ArticuloTienda[]>(this.urlArticuloTienda); }
}
