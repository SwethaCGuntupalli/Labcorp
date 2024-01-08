import { Component } from '@angular/core';
import { EmployeeService } from '../_services/employee.service';
import { Router } from '@angular/router';

@Component({
  selector: 'app-nav',
  templateUrl: './nav.component.html',
  styleUrl: './nav.component.css'
})
export class NavComponent {

  constructor(public employeeService: EmployeeService, private router: Router) {
  }

  logout() {
    this.employeeService.logout();
    this.router.navigateByUrl('/');
    console.clear();
  }

}
