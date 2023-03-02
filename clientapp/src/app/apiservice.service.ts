import { Injectable } from '@angular/core';
import { HttpClient, HttpEvent, HttpHeaders } from '@angular/common/http';
import { Observable } from 'rxjs';

@Injectable({
  providedIn: 'root'
})
export class ApiserviceService {
  readonly apiUrl = 'https://localhost:7043/inHouseSysmte/api/inHouseSystem';
  readonly apiUrl2 = 'https://localhost:7043/Process';
  readonly apiUrl3 = 'https://localhost:7043/inHouseSysmte/api/inHouseSystem';
  constructor(private http: HttpClient) { }


  // Department
  getSystemList(): Observable<any[]> {
    return this.http.get<any[]>(this.apiUrl);
  }

  addSystem(dept: any): Observable<any> {
    const httpOptions = { headers: new HttpHeaders({ 'Content-Type': 'application/json' }) };
    return this.http.post<any>(this.apiUrl, dept, httpOptions);
  }

  updateSystem(dept: any): Observable<any> {
    const httpOptions = { headers: new HttpHeaders({ 'Content-Type': 'application/json' }) };
    return this.http.put<any>(this.apiUrl + dept.Id, dept, httpOptions);
  }

  deleteSystem(Id: number): Observable<number> {
    const httpOptions = { headers: new HttpHeaders({ 'Content-Type': 'application/json' }) };
    return this.http.delete<number>(this.apiUrl + Id, httpOptions);
  }
  getCategories(): Observable<any[]> {
    const httpOptions = { headers: new HttpHeaders({ 'Content-Type': 'application/json' }) };
    return this.http.get<any[]>(this.apiUrl3, httpOptions);

  }
  getProcessControls(): Observable<any[]> {
    const httpOptions = { headers: new HttpHeaders({ 'Content-Type': 'application/json' }) };
    return this.http.get<any[]>(this.apiUrl2, httpOptions);

  }
}
