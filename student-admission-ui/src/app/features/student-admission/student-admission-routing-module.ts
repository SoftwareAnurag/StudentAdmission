import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { StudentInfoComponent } from './components/student-info/student-info.component';
import { AdmissionInfoComponent } from './components/admission-info/admission-info.component';

const routes: Routes = [
  { path: '', component: StudentInfoComponent },  // Step 1
  { path: 'step2', component: AdmissionInfoComponent } // Step 2
];

@NgModule({
  imports: [RouterModule.forChild(routes)],
  exports: [RouterModule]
})
export class StudentAdmissionRoutingModule { }
