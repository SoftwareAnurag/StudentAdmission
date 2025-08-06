import { Routes } from '@angular/router';
import { StudentInfoComponent } from './features/student-admission/components/student-info/student-info.component';
import { AdmissionInfoComponent } from './features/student-admission/components/admission-info/admission-info.component';

export const routes: Routes = [
  {
    path: 'student-admission',
    loadChildren: () =>
      import('./features/student-admission/student-admission-module')
        .then(m => m.StudentAdmissionModule)
  },
  { path: '', redirectTo: 'student-admission', pathMatch: 'full' },
  { path: '**', redirectTo: 'student-admission' }
];
