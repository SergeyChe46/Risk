import { Injectable } from '@angular/core';
import { HttpClient, HttpHeaders } from '@angular/common/http';
import { Observable } from 'rxjs';
import { ICompany } from './shared/company';

@Injectable({
  providedIn: 'root',
})
export class CompanyService {
  _headers: HttpHeaders = new HttpHeaders()
    .set('accept', 'text/plain')
    .append('Content-Type', 'application/json');

  constructor(private http: HttpClient) {}

  private URL = 'http://localhost:5285/Company';

  public getAll(): Observable<ICompany[]> {
    return this.http.get<ICompany[]>(this.URL);
  }
  public getById(id: string): Observable<ICompany | null> {
    return this.http.get<ICompany | null>(`${this.URL}/${id}`);
  }
  public createCompany(company: ICompany) {
    return this.http.post(this.URL, company).subscribe();
  }
}
