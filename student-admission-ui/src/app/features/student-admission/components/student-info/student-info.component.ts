import { CommonModule } from '@angular/common';
import { Component, OnInit } from '@angular/core';
import { FormBuilder, FormGroup, ReactiveFormsModule, Validators } from '@angular/forms';
import { Router } from '@angular/router';
import { StudentService } from '../../services/student.service';
import { StepDataService } from '../../services/step-data.service';
import { finalize } from 'rxjs/operators';


@Component({
  selector: 'app-student-info',
  standalone: false,
  templateUrl: './student-info.component.html',
  styleUrls: ['./student-info.component.scss'], 
  //imports: [CommonModule, ReactiveFormsModule]
})
export class StudentInfoComponent implements OnInit {

  studentForm!: FormGroup;
  isSubmitting = false;

  constructor(
    private fb: FormBuilder,
    private studentService: StudentService,
    private stepDataService: StepDataService,
    private router: Router
  ) {}

  ngOnInit(): void {

    this.studentForm = this.fb.group({
      firstName: ['', Validators.required],
      lastName: ['', Validators.required],
      email: ['', [Validators.required, Validators.email]],
      dob: ['', Validators.required],
      gender: ['', Validators.required],
      phone: ['', [Validators.required, Validators.pattern(/^\d{10}$/)]],
      address: ['', Validators.required],
    });
  }

  onSubmit(): void {
 
    this.isSubmitting = true; 
    if (this.studentForm.invalid) {
      this.studentForm.markAllAsTouched();
      return;
    }

    const v = this.studentForm.getRawValue();
   
    const payload = {
      FullName: `${(v.firstName || '').trim()} ${(v.lastName || '').trim()}`.trim(),
      DateOfBirth: toIsoUtcDate(v.dob),  
      Gender: (v.gender || '').trim(),
      Email: (v.email || '').trim(),
      PhoneNumber: (v.phone || '').trim(),
      Address: (v.address || '').trim() || null
      
    };
    
    if (this.studentForm.valid) {
      const studentData = this.studentForm.value;

      this.studentService.saveStudent(payload)
      .pipe(
        finalize(() => {        
          this.isSubmitting = false;
        })  
      )
          
      .subscribe({
        next: (res) => {
          console.log('✅ Student Info Saved:', res);
            this.stepDataService.setStudentID(res.studentId); // store studentID
            this.router.navigate(['/student-admission/step2']); //next step
        },
        error: (err) => {
          console.error('❌ Failed to Save Student Info:', err);       
        }
      });
    } else {
      this.studentForm.markAllAsTouched();
    }

      function toIsoUtcDate(value: any): string {
        if (!value) return '';
        const d = value instanceof Date ? value : new Date(value);
        const utc = new Date(Date.UTC(d.getFullYear(), d.getMonth(), d.getDate()));
        return utc.toISOString(); 
      }
  }
  
  
}


