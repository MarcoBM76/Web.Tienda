import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';
import { Articulo } from '../models/articulo.model';
import { ClienteArticulo } from '../models/ClienteArticulo';

@Injectable({ providedIn: 'root' })
export class CarritoService {
  private url = 'https://localhost:7141/api/ClienteArticulo';

  constructor(private http: HttpClient) { }

  getAll(clienteId: number): Observable<ClienteArticulo[]> { return this.http.get<ClienteArticulo[]>(`${this.url}/${clienteId}`); }
  add(art: ClienteArticulo): Observable<any> { return this.http.post<ClienteArticulo>(this.url, art); }
  update(id: number, art: Articulo): Observable<any> { return this.http.put(`${this.url}/${id}`, art); }
  delete(id: number): Observable<any> { return this.http.delete(`${this.url}/${id}`); }
}
