import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';

import { environment } from '../../../environments/environment';
import {
  ITrainingCreateFormModel,
  ITrainingDetailsModel,
} from 'src/app/models';

@Injectable({
  providedIn: 'root',
})
export class TrainingsService {
  private createEquipmentPath = environment.apiUrl + 'trainings/add';

  constructor(private http: HttpClient) {}

  create(data: ITrainingCreateFormModel): Observable<ITrainingDetailsModel> {
    return this.http.post<ITrainingDetailsModel>(
      this.createEquipmentPath,
      data
    );
  }
}
