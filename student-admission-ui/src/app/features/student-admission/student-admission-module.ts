import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { ReactiveFormsModule } from '@angular/forms';
import { StudentAdmissionRoutingModule } from './student-admission-routing-module';
import { StudentInfoComponent } from './components/student-info/student-info.component';
import { AdmissionInfoComponent } from './components/admission-info/admission-info.component';

@NgModule({
  declarations: [
    
  ],
  imports: [
    CommonModule,
    ReactiveFormsModule,
    StudentInfoComponent,
    AdmissionInfoComponent,
    StudentAdmissionRoutingModule
  ]
})
export class StudentAdmissionModule { }
