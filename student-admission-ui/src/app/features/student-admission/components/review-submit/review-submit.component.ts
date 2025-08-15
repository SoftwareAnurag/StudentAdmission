import { Component, OnInit } from '@angular/core';
import { CommonModule } from '@angular/common'; // ✅ import CommonModule
import { StepDataService } from '../../services/step-data.service';
import { CourseService } from '../../services/course.service';
import { Course } from '../../models/course.model';

@Component({
  selector: 'app-review-submit',
  standalone: true,
  imports: [CommonModule],
  templateUrl: './review-submit.component.html',
  styleUrl: './review-submit.component.scss'
})
export class ReviewSubmitComponent implements OnInit{

   studentID: string | null = null;
   courses: Course[] = [];

   constructor(
       private stepDataService: StepDataService,
       private courseService: CourseService,
   ){}
    ngOnInit() 
   {
      this.studentID = this.stepDataService.getStudentID();
      
      
    
   }
   
}
