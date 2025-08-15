import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { StudentInfoComponent } from './components/student-info/student-info.component';
import { AdmissionInfoComponent } from './components/admission-info/admission-info.component';
import { ReviewSubmitComponent } from './components/review-submit/review-submit.component';

const routes: Routes = [
  { path: '', component: StudentInfoComponent },  // Step 1
  { path: 'step2', component: AdmissionInfoComponent }, // Step 2
  { path: 'step3', component: ReviewSubmitComponent } // Step 3
  
];

@NgModule({
  imports: [RouterModule.forChild(routes)],
  exports: [RouterModule]
})
export class StudentAdmissionRoutingModule { }
