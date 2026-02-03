import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';
import { Tienda } from '../models/tienda';
import { Cliente } from '../models/cliente';


@Injectable({ providedIn: 'root' })
export class ClienteService {
  private url = 'https://localhost:7141/api/cliente';

  constructor(private http: HttpClient) { }

  getClientes(): Observable<Cliente[]> { return this.http.get<Cliente[]>(this.url); }
  getCliente(id: number): Observable<Cliente> { return this.http.get<Cliente>(`${this.url}/${id}`); }
  createCliente(cliente: Cliente): Observable<Cliente> { return this.http.post<Cliente>(this.url, cliente); }
  updateCliente(cliente: Cliente): Observable<any> { return this.http.put(`${this.url}/${cliente.clienteId}`, cliente); }
  deleteCliente(id: number): Observable<any> { return this.http.delete(`${this.url}/${id}`); }
}
