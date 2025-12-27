import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { ReactiveFormsModule } from '@angular/forms';
import { StudentAdmissionRoutingModule } from './student-admission-routing-module';
import { StudentInfoComponent } from './components/student-info/student-info.component';
import { AdmissionInfoComponent } from './components/admission-info/admission-info.component';
import { ReviewSubmitComponent } from './components/review-submit/review-submit.component';

@NgModule({
  declarations: [
    StudentInfoComponent,
    AdmissionInfoComponent,
    ReviewSubmitComponent
  ],
  imports: [
    CommonModule,
    ReactiveFormsModule,
    StudentAdmissionRoutingModule
  ]
})
export class StudentAdmissionModule { }
