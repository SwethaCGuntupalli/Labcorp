import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable, ReplaySubject } from 'rxjs';
import { User } from '../_models/user';
import { environment } from '../../environments/environment';
import { Employee } from '../_models/employee';
import { WorkRequest } from '../_models/workRequest';
import { VacationRequest } from '../_models/vacationRequest';

@Injectable({
  providedIn: 'root'
})
export class EmployeeService {
  baseUrl = environment.apiUrl;
  private currentUserSource = new ReplaySubject<User>(1);
  currentUser$ = this.currentUserSource.asObservable();

  constructor(private http: HttpClient) { }

  setCurrentUser(user: User) {
    localStorage.setItem('user', JSON.stringify(user));
    this.currentUserSource.next(user);
  }

  logout() {
    localStorage.clear();
    this.currentUserSource.next(JSON.parse(localStorage.getItem('user')!));
  }

  getAllEmployees() {
    return this.http.get<Employee[]>(this.baseUrl + '/employees');
  }

  workDays(employeeId: number, days: number): Observable<string> {
    let request = new WorkRequest(days);
    return this.http.post<string>(this.baseUrl + '/employees/' + employeeId + '/work', request);
  }

  vacationDays(employeeId: number, days: number): Observable<string> {
    let request = new VacationRequest(days);
    return this.http.post<string>(this.baseUrl + '/employees/' + employeeId + '/vacation', request);
  }

}
