import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';

import { environment } from '../../environments/environment';
import { IEquipment } from '../models/equipment';

@Injectable({
  providedIn: 'root',
})
export class EquipmentService {
  private getAllNamesPath = environment.apiUrl + 'equipment/get-names';
  private createEquipment = environment.apiUrl + 'equipment/add-equipment';

  constructor(private http: HttpClient) {}

  getAllNames(): Observable<string[]> {
    return this.http.get<string[]>(this.getAllNamesPath);
  }

  create(data: IEquipment): Observable<string> {
    return this.http.post<string>(this.createEquipment, data);
  }
}
