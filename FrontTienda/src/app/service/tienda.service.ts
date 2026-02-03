import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';
import { Tienda } from '../models/tienda';


@Injectable({ providedIn: 'root' })
export class TiendaService {
  private url = 'https://localhost:7141/api/tienda';

  constructor(private http: HttpClient) { }

  getAll(): Observable<Tienda[]> { return this.http.get<Tienda[]>(this.url); }
  add(art: Tienda): Observable<any> { return this.http.post<Tienda>(this.url, art); }
  update(id: number, art: Tienda): Observable<any> { return this.http.put(`${this.url}/${id}`, art); }
  delete(id: number): Observable<any> { return this.http.delete(`${this.url}/${id}`); }
}
