import { HttpClient, HttpHeaders } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';

import { environment } from '../../environments/environment';
import { IExerciseCreateFormModel } from '../models';
import { IExerciseDetailsModel } from '../models/exercises/exerciseDetailsModel';
import { AuthService } from './auth.service';

@Injectable({
  providedIn: 'root',
})
export class ExercisesService {
  private createPath = environment.apiUrl + 'exercises/add';

  constructor(private http: HttpClient, private authService: AuthService) {}

  create(data: IExerciseCreateFormModel): Observable<IExerciseDetailsModel> {
    return this.http.post<IExerciseDetailsModel>(this.createPath, data, {
      headers: { Authorization: `Bearer ${this.authService.getToken()}` },
    });
  }
}
