import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { environment } from 'src/environments/environment';
import { Employee } from '../interfaces/employee';
import { GenericApiResponse } from '../interfaces/genericApiResponse';

@Injectable({
  providedIn: 'root'
})
export class EmployeeService {

  constructor(private _httpClient: HttpClient) { }

  /**
   * Get all the employees from the databse
   * @returns 
   */
  public GetEmployees(): Observable<GenericApiResponse<Employee[]>> {
    return this._httpClient.get<GenericApiResponse<Employee[]>>(`${environment.baseUrl}Employee/getAllEmployees`, {})
  }

  /**
   * Create a new employee to the records
   * @returns 
   */
  public CreateEmployee(employee: Employee): Observable<GenericApiResponse<Employee>> {
    return this._httpClient.post<GenericApiResponse<Employee>>(`${environment.baseUrl}Employee`, employee)
  }
}
