import { Component } from '@angular/core';
import { CommonModule } from '@angular/common';
import { StepDataService } from '../../services/step-data.service';

@Component({
  selector: 'app-admission-info',
  standalone: true,
   imports: [CommonModule],
  templateUrl: './admission-info.component.html',
  styleUrl: './admission-info.component.scss'
})
export class AdmissionInfoComponent {

  studentID: string | null = null;
  
  constructor(private stepDataService: StepDataService) {}

   ngOnInit() {
    this.studentID = this.stepDataService.getStudentID();
  }
}
