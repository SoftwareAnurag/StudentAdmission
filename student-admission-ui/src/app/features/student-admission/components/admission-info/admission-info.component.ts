import { Component, OnInit } from '@angular/core';
import { CommonModule } from '@angular/common';
import { StepDataService } from '../../services/step-data.service';
import { CourseService } from '../../services/course.service';
import { Course } from '../../models/course.model';
import { SessionService } from '../../services/session.service';
import { Session } from '../../models/session.model';
import { FormBuilder, FormGroup, ReactiveFormsModule, Validators } from '@angular/forms';
import { AdmissionInfoService } from '../../services/admissioninfo.service';
import { Router } from '@angular/router';

@Component({
  selector: 'app-admission-info',
  standalone: true,
  imports: [CommonModule, ReactiveFormsModule],
  templateUrl: './admission-info.component.html',
  styleUrl: './admission-info.component.scss'
})
export class AdmissionInfoComponent implements OnInit {

 
  
     studentID: string | null = null;
     courses: Course[] = [];
     sessions: Session[] = [];

     admissioninfoForm!: FormGroup;

    constructor(
        private fb: FormBuilder,
        private admissionInfoService: AdmissionInfoService,
        private stepDataService: StepDataService, 
        private courseService: CourseService,
        private sessionService: SessionService,
        private router: Router
      ) {}

   ngOnInit() 
   {

      this.studentID = this.stepDataService.getStudentID();

      this.courseService.getCourses().subscribe(data => {
        this.courses = data;
      });

      this.sessionService.getSessions().subscribe(data =>{
        this.sessions = data;
      });

      this.admissioninfoForm = this.fb.group({
        courselist: ['', Validators.required],
        sessionlist: ['', Validators.required],     
      });
    }

    onSubmit(): void {

      if (this.admissioninfoForm.invalid) {
        this.admissioninfoForm.markAllAsTouched();
         return;
      }

       const v = this.admissioninfoForm.getRawValue();
       // 👇 Map Angular form → Server DTO (names must match the DTO)
       const payload = {
         StudentId : this.studentID,
         CourseId: (v.courselist || '').trim(),
         SessionId: (v.sessionlist || '').trim(),
         StatusId: 1,
          
       };

        if (this.admissioninfoForm.valid) {
           const admissionData = this.admissioninfoForm.value;

            this.admissionInfoService.saveAdmissionData(payload).subscribe({
              next: (res) => {
                console.log('✅ Admission Info Saved:', res);
                
                 this.router.navigate(['/student-admission/step3']); // 👈 go to next step
              },
              error: (err) => {
                console.error('❌ Failed to Save Admission Info:', err);
              }
            });
        }
    }
}
