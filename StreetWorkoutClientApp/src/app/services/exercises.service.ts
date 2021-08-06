import { HttpClient, HttpHeaders } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';

import { environment } from '../../environments/environment';
import {
  IExerciseCreateFormModel,
  IExercisesFilterModel,
  IExerciseDetailsModel,
  IExerciseCardModel,
} from '../models';

@Injectable({
  providedIn: 'root',
})
export class ExercisesService {
  private createPath = environment.apiUrl + 'exercises/add';
  private getFilteredExercisesPath = environment.apiUrl + 'exercises/filter';

  constructor(private http: HttpClient) {}

  create(data: IExerciseCreateFormModel): Observable<IExerciseDetailsModel> {
    return this.http.post<IExerciseDetailsModel>(this.createPath, data);
  }

  getExercises(data: IExercisesFilterModel): Observable<IExerciseCardModel[]> {
    return this.http.post<IExerciseCardModel[]>(
      this.getFilteredExercisesPath,
      data
    );
  }
}
