import { Routes } from '@angular/router';

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
