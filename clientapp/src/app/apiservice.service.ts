import { Injectable } from '@angular/core';
import { HttpClient, HttpEvent, HttpHeaders } from '@angular/common/http';
import { Observable } from 'rxjs';

@Injectable({
  providedIn: 'root'
})
export class ApiserviceService {
  readonly apiUrl = 'https://localhost:7043/inHouseSysmte/api/inHouseSystem';  // APIのURL
  readonly apiUrl2 = 'https://localhost:7043/Process';  // 別のAPIのURL
  readonly apiUrl3 = 'https://localhost:7043/SystemCategories';  // 別のAPIのURL
  constructor(private http: HttpClient) { }


  // Department
  getSystemList(): Observable<any[]> {  // システムの一覧を取得するAPI呼び出し
    return this.http.get<any[]>(this.apiUrl);
  }

  addSystem(dept: any): Observable<any> {  // システムを追加するAPI呼び出し
    const httpOptions = { headers: new HttpHeaders({ 'Content-Type': 'application/json' }) };
    return this.http.post<any>(this.apiUrl, dept, httpOptions);
  }

  updateSystem(dept: any): Observable<any> {  // システムを更新するAPI呼び出し
    const httpOptions = { headers: new HttpHeaders({ 'Content-Type': 'application/json' }) };
    return this.http.put<any>(this.apiUrl + dept.Id, dept, httpOptions);
  }

  deleteSystem(Id: number): Observable<number> {  // システムを削除するAPI呼び出し
    const httpOptions = { headers: new HttpHeaders({ 'Content-Type': 'application/json' }) };
    return this.http.delete<number>(this.apiUrl + Id, httpOptions);
  }
  getCategories(): Observable<any[]> {  // システムカテゴリーの一覧を取得するAPI呼び出し
    const httpOptions = { headers: new HttpHeaders({ 'Content-Type': 'application/json' }) };
    return this.http.get<any[]>(this.apiUrl3, httpOptions);

  }
  getProcessControls(): Observable<any[]> {  // プロセス制御の一覧を取得するAPI呼び出し
    const httpOptions = { headers: new HttpHeaders({ 'Content-Type': 'application/json' }) };
    return this.http.get<any[]>(this.apiUrl2, httpOptions);

  }
}
