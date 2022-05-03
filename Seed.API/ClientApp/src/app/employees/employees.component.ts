import { Component, OnInit } from '@angular/core';
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
  constructor(private _employeeService: EmployeeService) { }

  ngOnInit() {
    this.getAll();
  }

  getAll(): void {
    this._employeeService.GetEmployees().subscribe(res => {
      this.employees = res.result;
    })
  }
}
