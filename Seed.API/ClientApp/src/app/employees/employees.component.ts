import { Component, OnInit } from '@angular/core';
import { FormControl, FormGroup, Validators } from '@angular/forms';
import { of, throwError, timer } from 'rxjs';
import { catchError, delayWhen, retryWhen, take, tap } from 'rxjs/operators';
import { PersonAge } from '../Common/models/personAge';
import { Employee } from '../Common/models/employee';
import { EmployeeService } from '../services/employee.service';

@Component({
  selector: 'app-employees',
  templateUrl: './employees.component.html',
  styleUrls: ['./employees.component.scss']
})
export class EmployeesComponent implements OnInit {

  // Public members
  employees: Employee[] = [];
  personAges: PersonAge[] = [];

  // Private members
  form: FormGroup;
  constructor(
    private _employeeService: EmployeeService) { }

  ngOnInit() {
    this.getAll();
    this.setForm();
    this.getValuesFromObject();
    this.sumValuesFromArrayAndGetAverage();
    this.makeInmutableObjects();
  }

  
  /* A method that gets all the employees from the API. */
  getAll(): void {
    this._employeeService.GetEmployees()
      .pipe(
        catchError(val => {
          return throwError(of(`Error: ${val}`))
        }),
        retryWhen(errors =>
          errors.pipe(
            tap(val => console.log(`Error from retryWhen: ${val}`)),
            delayWhen(() => timer(3000)), // Try again in 3 seconds
            take(5) // It will only try 5 times
          )
        )
      )
      .subscribe(res => {
        
        const employees: Employee[] = [...res.result]; // We use spread operator to create a new one

        this.employees = employees;

        employees.forEach(employee => {
          const ages: PersonAge = {
            age: employee.age,
            name: `${employee.firstName} ${employee.lastName}`
          };
          this.personAges.push(ages);
        });

        // How to return the props of the object?
        this.handleObjects();
      })
  };


  /**
   * Object.assign() creates a new object, copies the properties of the first object into it, and then
   * copies the properties of the second object into it
   */
  makeInmutableObjects(): void {
    const myObject = {
      country: 'Poland',
      capital: 'Warsaw'
    };

    const updatedLocation = Object.assign({}, myObject, {
      country: 'United States of America'
    });

    /**
     * Spread syntax (...) allows an iterable, such as an array or string, to be expanded in 
     * places where zero or more arguments (for function calls) or elements (for array literals) 
     * are expected. In an object literal, the spread syntax enumerates the properties of an 
     * object and adds the key-value pairs to the object being created.
     */
    const updatedLocation2 = {...myObject}; // Spread operator
    updatedLocation2.country = 'Germany'; // Changed the location

    console.log(updatedLocation); // Mutated object
    console.log(updatedLocation2); // Mutated object
    console.log(myObject); // Original object
  }


  /**
   * We are looping through the object and checking if the object 
   * has the property we are looking for
   */
  private handleObjects() {
    // keys: Returns the names of the enumerable string properties and methods of an object.
    const propObj = Object.keys(this.employees);
    console.log(propObj); // We will see ['0', '1', '2', '3', '4', '5', '6']

    // How to determine what props the object has
    for (const key in this.employees) {
      if (Object.prototype.hasOwnProperty.call(this.employees, key)) {
        const element = this.employees[key];
        console.log(element); // We will see {id: 1, firstName: 'Baldur', lastName: 'Odinson', middleName: null, age: 32, …}
        if (element.firstName) {
          // The element does have the prop firstName 
        }
      }
    }
  }

  /**
   * It takes an array of arrays, and returns an object with the first element of each array as the
   * key, and the second element as the value
   */
  getValuesFromObject(): void {
    // How to create object with the values from array
    const person = [
      ['name', 'Christian'],
      ['friend', 'Sean'],
      ['position', 'Plastic Surgeon']
    ]

    // Option #1 
    person.reduce((total, actual) => {
      const [prop, value] = actual;
      let result = { ...total, [prop]: value };
      console.log(result);
      return result; // We must see {name: 'Christian', friend: 'Sean', position: 'Plastic Surgeon'}
    }, {});

    // Option #2
    const obj = Object.fromEntries(person);
    console.log(obj); // We must see {name: 'Christian', friend: 'Sean', position: 'Plastic Surgeon'}
  }


  /**
   * We get the values from the ages object, we sum them up and we get the average
   */
  sumValuesFromArrayAndGetAverage(): void {
    const ages = {
      one: 22,
      two: 33,
      three: 98
    };

    const values = Object.values(ages);
    // TIP: Validate that all values are number
    // Calls the specified callback function for all the elements in an array. 
    // The return value of the callback function is the accumulated result, 
    // and is provided as an argument in the next call to the callback function.
    const agesAverage = values.reduce((total, actual) => total + actual, 0) / Object.entries(ages).length;

    console.log(agesAverage);
  }

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
