import { Injectable } from '@angular/core';

@Injectable({ providedIn: 'root' })

export class StepDataService {
  private studentID: string | null = null;

  setStudentID(id: string) {
    this.studentID = id;
  }

  getStudentID(): string | null {
    return this.studentID;
  }
}