import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { map, Observable } from 'rxjs';
import { StudentAdmissionDto } from '../models/student-admission-dto.model';

@Injectable({ providedIn: 'root' })

export class AdmissionInfoService {
  private apiUrl = 'http://localhost:44302/api/admission'; // Adjust as per API

  constructor(private http: HttpClient) {}

  saveAdmissionData(admissioninfo: any): Observable<any> {
    return this.http.post(this.apiUrl, admissioninfo);
  }

  getAdmissionDetails(studentId: string): Observable<StudentAdmissionDto[]> {
  return this.http.get<{ response: any[] }>(`${this.apiUrl}/${studentId}`)
    .pipe(
      map(res => res.response.map(item => ({
        admissionId: item.AdmissionId,
        fullName: item.FullName,
        email: item.Email,
        phoneNumber: item.PhoneNumber,
        courseId: item.CourseId || 0,
        courseName: item.CourseName,
        courseFee: item.CourseFee,
        StatusId: item.StatusId,
        StatusName: item.StatusName
      })))
    );
}

}
