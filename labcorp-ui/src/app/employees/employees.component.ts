import { ToastrService } from 'ngx-toastr';
import { EmployeeService } from './../_services/employee.service';
import { Component, OnInit } from '@angular/core';
import { Employee } from '../_models/employee';
import { BsModalRef, BsModalService } from 'ngx-bootstrap/modal';
import { EmployeeModalComponent } from './employee-modal/employee-modal.component';

@Component({
  selector: 'app-employees',
  templateUrl: './employees.component.html',
  styleUrl: './employees.component.css'
})
export class EmployeesComponent implements OnInit {
  employees: Employee[] = [];
  bsModalRef!: BsModalRef;

  constructor(private employeeService: EmployeeService, private tostr: ToastrService,
    private modalService: BsModalService) { }

  ngOnInit(): void {
    this.loadEmployees();
  }

  loadEmployees() {
    this.employeeService.getAllEmployees().subscribe({
      next: (res) => {
        this.employees = res;
      },
      error: (err) => {
        this.tostr.error(err);
      }
    });
  }

  addVacation(employee: Employee) {
    this.openModal('Vacation', employee);
  }

  addWork(employee: Employee) {
    this.openModal('Work', employee);
  }

  openModal(type: string, employee: Employee) {
    const config = {
      class: 'modal-dialog-center',
      initialState: {
        type: type,
        employee: employee
      }
    };

    this.bsModalRef = this.modalService.show(EmployeeModalComponent, config);
    this.bsModalRef.content.employeeModalEmitter.subscribe({
      next: () => { this.loadEmployees(); }
    });
  }

  balanceVacations(employee: Employee): string {
    return (employee.vacationDaysAccumulated - employee.vacationDaysAvailed).toFixed(2);
  }

  employeeType(type: string) {
    if (type === 'HourlyEmployee') return 'Hourly';
    else if (type === 'SalariedEmployee') return 'Salaried';
    else return 'Manager';
  }

}
