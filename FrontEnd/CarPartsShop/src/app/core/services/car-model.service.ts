import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { environment } from 'src/environments/environment';
import { CarModel } from '../types/CarPartsShop.types';

@Injectable({
  providedIn: 'root',
})
export class CarModelService {
  readonly APIUrl = environment.APIUrl;
  constructor(private http: HttpClient) {}

  getCarModelList(): Observable<CarModel[]> {
    return this.http.get<CarModel[]>(this.getEndPoint());
  }
  getCarModelById(id: string): Observable<CarModel> {
    return this.http.get<CarModel>(this.getEndPoint(id));
  }
  addCarModel(carModel: CarModel) {
    return this.http.post(this.getEndPoint(), carModel);
  }

  updateItem(carModel: CarModel) {
    return this.http.put(this.getEndPoint(carModel.id), carModel);
  }

  deleteItemFromList(id: string) {
    return this.http.delete(this.getEndPoint(id));
  }
  private getEndPoint(id?: string) {
    if (id) return `${this.APIUrl}CarModel/${id}`;
    return `${this.APIUrl}CarModel`;
  }
}
