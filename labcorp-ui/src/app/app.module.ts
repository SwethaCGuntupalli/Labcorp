import { NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';
import { BrowserAnimationsModule } from '@angular/platform-browser/animations';
import { BsDropdownModule } from 'ngx-bootstrap/dropdown';
import { ModalModule } from 'ngx-bootstrap/modal';
import { FontAwesomeModule, FaIconLibrary } from '@fortawesome/angular-fontawesome';

import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
import { ToastrModule } from 'ngx-toastr';
import { LoginComponent } from './login/login.component';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';
import { HttpClientModule } from '@angular/common/http';
import { NavComponent } from './nav/nav.component';
import { EmployeesComponent } from './employees/employees.component';
import { faUserClock, faUserTie, faUserShield, faBriefcaseClock, faTruckPlane } from '@fortawesome/free-solid-svg-icons';
// import {  } from '@fortawesome/free-regular-svg-icons'
// import { faSellsy, faMeta } from '@fortawesome/free-brands-svg-icons';
import { EmployeeModalComponent } from './employees/employee-modal/employee-modal.component'

@NgModule({
  declarations: [
    AppComponent,
    LoginComponent,
    NavComponent,
    EmployeesComponent,
    EmployeeModalComponent
  ],
  imports: [
    BrowserModule,
    AppRoutingModule, 
    BrowserAnimationsModule,   
    FormsModule,
    ReactiveFormsModule,
    HttpClientModule,
    ToastrModule.forRoot({ positionClass: 'toast-bottom-right' }),
    BsDropdownModule.forRoot(),
    ModalModule.forRoot(),
    FontAwesomeModule
  ],
  providers: [],
  bootstrap: [AppComponent]
})
export class AppModule {
  
  constructor(library: FaIconLibrary) {
    //library.addIconPacks(fas, far, fab);
    library.addIcons(faTruckPlane, faUserTie, faUserShield, faUserClock, faBriefcaseClock);

    // library.addIcons(faSellsy, faMeta);
  }

 }
