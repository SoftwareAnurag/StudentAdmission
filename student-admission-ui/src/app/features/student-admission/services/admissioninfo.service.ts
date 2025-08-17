import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';
import { StudentAdmissionDto } from '../models/student-admission-dto.model';

@Injectable({
  providedIn: 'root',
})

export class AdmissionInfoService {
  private apiUrl = 'http://localhost:44302/api/admission'; // Adjust as per API

  constructor(private http: HttpClient) {}

  saveAdmissionData(admissioninfo: any): Observable<any> {
    return this.http.post(this.apiUrl, admissioninfo);
  }

  getAdmissionDetails(studentId: number): Observable<StudentAdmissionDto[]> {
     return this.http.get<StudentAdmissionDto[]>(`${this.apiUrl}/student/${studentId}`);
    }

}
