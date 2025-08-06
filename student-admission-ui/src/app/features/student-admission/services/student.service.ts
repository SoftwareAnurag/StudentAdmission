import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';

@Injectable({
  providedIn: 'root',
})
export class StudentService {
  private apiUrl = 'http://localhost:44302/api/students'; // Adjust as per API

  constructor(private http: HttpClient) {}

  saveStudent(student: any): Observable<any> {
    return this.http.post(this.apiUrl, student);
  }
}
