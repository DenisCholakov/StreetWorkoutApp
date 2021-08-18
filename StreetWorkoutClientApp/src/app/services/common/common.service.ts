import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';

import { environment } from '../../../environments/environment';

@Injectable({
  providedIn: 'root',
})
export class CommonService {
  private getMuscleGroupNamesPath =
    environment.apiUrl + 'common/get-muscle-groups';

  constructor(private http: HttpClient) {}

  getMuscleGroups(): Observable<string[]> {
    return this.http.get<string[]>(this.getMuscleGroupNamesPath);
  }
}
