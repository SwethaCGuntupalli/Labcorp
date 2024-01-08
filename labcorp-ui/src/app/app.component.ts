import { EmployeeService } from './_services/employee.service';
import { Component } from '@angular/core';
import { User } from './_models/user';

@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrl: './app.component.css'
})
export class AppComponent {
  title = 'labcorp-ui';

  constructor(private employeeService: EmployeeService) {
    this.setCurrentUser();
  }

  setCurrentUser() {
    const user: User = JSON.parse(localStorage.getItem('user')!);    
    if (user) {
      this.employeeService.setCurrentUser(user);
    }

  }

}
