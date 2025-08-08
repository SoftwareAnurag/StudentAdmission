import { Component } from '@angular/core';
import { CommonModule } from '@angular/common';
import { StepDataService } from '../../services/step-data.service';
import { CourseService } from '../../services/course.service';
import { Course } from '../../models/course.model';
import { SessionService } from '../../services/session.service';
import { Session } from '../../models/session.model';

@Component({
  selector: 'app-admission-info',
  standalone: true,
   imports: [CommonModule],
  templateUrl: './admission-info.component.html',
  styleUrl: './admission-info.component.scss'
})
export class AdmissionInfoComponent {

  studentID: string | null = null;
   courses: Course[] = [];
    sessions: Session[] = [];

   
  constructor(private stepDataService: StepDataService, private courseService: CourseService,
    private sessionService: SessionService
  ) {}

   ngOnInit() {
    this.studentID = this.stepDataService.getStudentID();

     this.courseService.getCourses().subscribe(data => {
      this.courses = data;
    });

    this.sessionService.getSessions().subscribe(data =>{
      this.sessions = data;
    });
  }
}
