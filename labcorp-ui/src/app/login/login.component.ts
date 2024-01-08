import { EmployeeService } from './../_services/employee.service';
import { User } from './../_models/user';
import { Component, OnInit } from '@angular/core';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { Router } from '@angular/router';
import { ToastrService } from 'ngx-toastr';

@Component({
  selector: 'app-login',
  templateUrl: './login.component.html',
  styleUrl: './login.component.css'
})
export class LoginComponent implements OnInit {

  loginForm!: FormGroup;
  user!: User;

  constructor(private router: Router, private formBuilder: FormBuilder,
    private toastr: ToastrService, private employeeService: EmployeeService) {
  }
  ngOnInit(): void {
    this.checkLoginStatus();
    this.initializeLoginForm();
  }

  initializeLoginForm() {
    this.loginForm = this.formBuilder.group({
      username: ['', [Validators.required, Validators.email]],
      password: ['', [Validators.required, Validators.minLength(4), Validators.maxLength(20)]],
    });
  }

  checkLoginStatus() {
    const user: User = JSON.parse(localStorage.getItem('user')!);    
    if (user) {
      this.employeeService.setCurrentUser(user);
      this.router.navigateByUrl('/employees');
    }
    //this.router.navigateByUrl('/');
  }


  login() {
    if (this.loginForm.value.username == 'admin@labcorp.com' && this.loginForm.value.password == 'admin') {
      this.user = new User(this.loginForm.value.username);
      localStorage.setItem('user', JSON.stringify(this.user));
      this.employeeService.setCurrentUser(this.user);
      this.toastr.success('Successfully logged in');
      this.router.navigateByUrl('/employees');
    }
    else {
      this.toastr.error('Please provide valid username or password');
    }
  }

  get loginFormControl() {
    return this.loginForm.controls;
  }

}

