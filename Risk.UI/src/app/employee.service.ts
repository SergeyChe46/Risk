import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { IEmployee } from './shared/employee';

@Injectable({
  providedIn: 'root',
})
export class EmployeeService {
  private URL = 'http://localhost:5285/Employee';

  constructor(private httpClient: HttpClient) {}

  createEmployee(employee: IEmployee) {
    return this.httpClient.post<IEmployee>(this.URL, employee).subscribe();
  }
}
