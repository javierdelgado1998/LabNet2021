import { Injectable } from '@angular/core';
import {HttpClient} from '@angular/common/http';
import {Observable} from 'rxjs';
import {Shippers} from '../models/shippers'
import {environment} from '../../../environments/environment'

@Injectable({
  providedIn: 'root'
})
export class ShippersService {

  constructor(private http: HttpClient) { }

  //Insertar nuevo registro
  postShippers(request: Shippers)
  {
    return this.http.post(environment.shippers + 'shippers/', request);
  }
  //Obtener un solo registro
  readShippers(id: number): Observable<Shippers>
  {
    return this.http.get<any>(environment.shippers + 'shippers/' + id);
  }
  //Obtener la lista de registros
  getShippers(): Observable<Shippers[]>
  {
    return this.http.get<any>(environment.shippers + 'shippers/');
  }
  //Eliminar un solo registro
  deleteShippers(id: number): Observable<Shippers>
  {
    return this.http.delete<any>(environment.shippers + 'shippers/' + id);
  }
  //Modificar un registro
  updateShippers(request: Shippers)
  {
    return this.http.put<any>(environment.shippers + 'shippers/', request);
  }

}
