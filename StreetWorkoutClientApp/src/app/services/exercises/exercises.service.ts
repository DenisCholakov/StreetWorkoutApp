import { HttpClient, HttpParams } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';

import { environment } from '../../../environments/environment';
import {
  IExerciseCreateFormModel,
  IExercisesFilterModel,
  IExerciseDetailsModel,
  IFilteredExercisesResponse,
} from '../../models';

@Injectable({
  providedIn: 'root',
})
export class ExercisesService {
  private createPath = environment.apiUrl + 'exercises/add';
  private getExerciseDetailsPath = environment.apiUrl + 'exercises/details';
  private getFilteredExercisesPath = environment.apiUrl + 'exercises/filter';
  private getAllExerciseNamesPath = environment.apiUrl + 'exercises/all/names';

  constructor(private http: HttpClient) {}

  create(data: IExerciseCreateFormModel): Observable<IExerciseDetailsModel> {
    debugger;
    return this.http.post<IExerciseDetailsModel>(this.createPath, data);
  }

  getAllExerciseNames(): Observable<string[]> {
    return this.http.get<string[]>(this.getAllExerciseNamesPath);
  }

  getExerciseDetails(exerciseId: string): Observable<IExerciseDetailsModel> {
    return this.http.get<IExerciseDetailsModel>(
      this.getExerciseDetailsPath + `/${exerciseId}`
    );
  }

  getExercises(
    data: IExercisesFilterModel,
    resultsPerPage: string,
    currentPage: string
  ): Observable<IFilteredExercisesResponse> {
    let params = new HttpParams();
    params = params.append('currentPage', currentPage);
    params = params.append('resultsPerPage', resultsPerPage);

    return this.http.post<IFilteredExercisesResponse>(
      this.getFilteredExercisesPath,
      data,
      { params: params }
    );
  }
}
