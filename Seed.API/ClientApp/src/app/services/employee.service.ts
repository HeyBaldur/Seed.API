import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { environment } from 'src/environments/environment';
import { Employee } from '../Common/models/employee';
import { GenericApiResponse } from '../Common/models/genericApiResponse';

@Injectable({
  providedIn: 'root'
})
export class EmployeeService {

  constructor(private _httpClient: HttpClient) { }

  /**
   * It returns an Observable of type GenericApiResponse<Employee[]> which is the result of an HTTP GET
   * request to the URL `${environment.baseUrl}Employee/getAllEmployees` with no request body
   * @returns Observable<GenericApiResponse<Employee[]>>
   */
  public GetEmployees(): Observable<GenericApiResponse<Employee[]>> {
    return this._httpClient.get<GenericApiResponse<Employee[]>>(`${environment.baseUrl}Employee/getAllEmployees`, {})
  }

  
  /**
   * This function takes an Employee object as a parameter and returns an Observable of type
   * GenericApiResponse<Employee>
   * @param {Employee} employee - Employee - This is the employee object that we are going to send to
   * the API.
   * @returns Observable<GenericApiResponse<Employee>>
   */
  public CreateEmployee(employee: Employee): Observable<GenericApiResponse<Employee>> {
    return this._httpClient.post<GenericApiResponse<Employee>>(`${environment.baseUrl}Employee`, employee)
  }
}
