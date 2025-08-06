import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';

@Injectable({
  providedIn: 'root' // or use 'StudentAdmissionModule' if you want feature-level encapsulation
})
export class StudentService {
  private apiUrl = 'http://localhost:44302/api/students'; // Replace with actual API URL

  constructor(private http: HttpClient) {}

  saveStudent(student: any): Observable<any> {
    return this.http.post(this.apiUrl, student);
  }
}
