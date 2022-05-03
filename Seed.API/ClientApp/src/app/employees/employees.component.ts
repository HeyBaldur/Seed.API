import { Component, OnInit } from '@angular/core';
import { FormControl, FormGroup, Validators } from '@angular/forms';
import { Employee } from '../interfaces/employee';
import { EmployeeService } from '../services/employee.service';

@Component({
  selector: 'app-employees',
  templateUrl: './employees.component.html',
  styleUrls: ['./employees.component.scss']
})
export class EmployeesComponent implements OnInit {

  // Public members
  employees: Employee[];

  // Private members
  form: FormGroup;
  constructor(private _employeeService: EmployeeService) { }

  ngOnInit() {
    this.getAll();
    this.setForm();
  }

  /**
   * Get all employees from the service
   */
  getAll(): void {
    this._employeeService.GetEmployees().subscribe(res => {
      this.employees = res.result;
    })
  };

  /**
   * Create a new employee
   * After create it, it should display all again
   * @param employee 
   */
  onSubmit(employee: Employee): void {
    this._employeeService.CreateEmployee(employee).subscribe(res => {
      if (!res.isError) {
        this.getAll();
      }
    })
  }

  private setForm(): void {
    this.form = new FormGroup({
      firstName: new FormControl('', Validators.required),
      lastName: new FormControl('', Validators.required),
      emailAddress: new FormControl('', Validators.required),
      age: new FormControl('', Validators.required),
    })
  };
}
