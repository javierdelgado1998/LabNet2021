import { Injectable } from '@angular/core';
import {HttpClient} from '@angular/common/http';
import {Observable} from 'rxjs';
import {Shippers} from './models/shippers'
import {environment} from '../../../environments/environment'

@Injectable({
  providedIn: 'root'
})
export class ShippersService {

  constructor(private http: HttpClient) { }
  postShippers(request: Shippers)
  {
    return this.http.post(environment.shippers + 'shippers/', request);
  }
  readShippers(id: number): Observable<Shippers>
  {
    return this.http.get<any>(environment.shippers + 'shippers/' + id);
  }
  getShippers(): Observable<Shippers[]>
  {
    return this.http.get<any>(environment.shippers + 'shippers/');
  }
  deleteShippers(id: number): Observable<Shippers>
  {
    return this.http.delete<any>(environment.shippers + 'shippers/' + id);
  }
  updateShippers(request: Shippers)
  {
    return this.http.put<any>(environment.shippers + 'shippers/', request);
  }
}
