import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';

import { environment } from '../../../environments/environment';
import {
  IFilteredTrainingsResponse,
  ITrainingCreateFormModel,
  ITrainingDetailsModel,
  ITrainingFiltersModel,
} from 'src/app/models';

@Injectable({
  providedIn: 'root',
})
export class TrainingsService {
  private createTrainingPath = environment.apiUrl + 'trainings/add';
  private getTrainingDetailsPath = environment.apiUrl + 'trainings/details';
  private getFilteredTrainingsPath = environment.apiUrl + 'trainings/filter';

  constructor(private http: HttpClient) {}

  create(data: ITrainingCreateFormModel): Observable<number> {
    return this.http.post<number>(this.createTrainingPath, data);
  }

  getTrainingDetails(id: string) {
    return this.http.get<ITrainingDetailsModel>(
      this.getTrainingDetailsPath + `/${id}`
    );
  }

  getFilteredTrainings(
    data: ITrainingFiltersModel,
    currentPage: string,
    resultsPerPage: string
  ): Observable<IFilteredTrainingsResponse> {
    return this.http.post<IFilteredTrainingsResponse>(
      this.getFilteredTrainingsPath + `/${currentPage}/${resultsPerPage}`,
      data
    );
  }
}
