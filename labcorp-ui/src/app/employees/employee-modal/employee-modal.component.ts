import { ToastrService } from 'ngx-toastr';
import { Component, EventEmitter, Input, OnInit } from '@angular/core';
import { FormBuilder, FormGroup } from '@angular/forms';
import { BsModalRef } from 'ngx-bootstrap/modal';
import { EmployeeService } from '../../_services/employee.service';
import { Employee } from '../../_models/employee';

@Component({
  selector: 'app-employee-modal',
  templateUrl: './employee-modal.component.html',
  styleUrl: './employee-modal.component.css'
})
export class EmployeeModalComponent implements OnInit {
  @Input() employeeModalEmitter = new EventEmitter<Employee>();
  type = '';
  employeeForm!: FormGroup;
  employee!: Employee;

  constructor(private formBuilder: FormBuilder, public bsModalRef: BsModalRef,
    private employeeService: EmployeeService, private tostr: ToastrService) { }

  ngOnInit(): void {
    this.initializeForm();
  }

  initializeForm() {
    this.employeeForm = this.formBuilder.group({
      firstName: [{ value: this.employee.firstName, disabled: true }],
      lastName: [{ value: this.employee.lastName, disabled: true }],
      vacationDays: [0],
      workDays: [0]
    });

    if (this.type == 'Work')
      this.employeeForm.controls['vacationDays'].disable();
    else
      this.employeeForm.controls['workDays'].disable();

  }

  employeeModal() {
    if (this.type == 'Work') {
      this.employeeService.workDays(this.employee.id, this.employeeForm.value.workDays).subscribe({
        next: (res: string) => {
          this.tostr.success(res, 'Success');
          this.employeeModalEmitter.emit(this.employee);
          this.bsModalRef.hide();
        },
        error: (err) => {
          this.tostr.error(err.error);
          console.log(err);
        }
      });
    }
    else {
      this.employeeService.vacationDays(this.employee.id, this.employeeForm.value.vacationDays).subscribe({
        next: (res: string) => {
          this.tostr.success(res, 'Success');
          this.employeeModalEmitter.emit(this.employee);
          this.bsModalRef.hide();
        },
        error: (err) => {
          this.tostr.error(err.error);
          console.log(err);
        }
      });
    }
  }

}
