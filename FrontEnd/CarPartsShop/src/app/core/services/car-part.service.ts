import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { environment } from 'src/environments/environment';
import { CarPart } from '../types/CarPartsShop.types';

@Injectable({
  providedIn: 'root',
})
export class CarPartService {
  readonly APIUrl = environment.APIUrl;
  constructor(private http: HttpClient) {}

  getCarPartList(): Observable<CarPart[]> {
    return this.http.get<CarPart[]>(this.getEndPoint());
  }
  getCarPartById(id: string): Observable<CarPart> {
    return this.http.get<CarPart>(this.getEndPoint(id));
  }
  getCarPartByUserId(id?: string): Observable<CarPart[]> {
    return this.http.get<CarPart[]>(`${this.APIUrl}user/${id}/carParts`);
  }
  getCarPartByBrandAndModelId(
    brandID: string,
    modelID: string
  ): Observable<CarPart> {
    return this.http.get<CarPart>(
      `${this.APIUrl}carBrand/${brandID}/carModel/${modelID}/carPart`
    );
  }
  getCarPartByModelId(modelId: string): Observable<CarPart[]> {
    return this.http.get<CarPart[]>(
      `${this.APIUrl}carModel/${modelId}/carPart`
    );
  }
  addCarPart(carBrand: CarPart) {
    return this.http.post(this.getEndPoint(), carBrand);
  }

  updateItem(carBrand: CarPart) {
    return this.http.put(this.getEndPoint(carBrand.id), carBrand);
  }

  deleteItemFromList(id: string) {
    return this.http.delete(this.getEndPoint(id));
  }

  private getEndPoint(id?: string) {
    if (id) return `${this.APIUrl}CarPart/${id}`;
    return `${this.APIUrl}CarPart`;
  }
}
