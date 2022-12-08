import { Injectable } from '@angular/core';
import { environment } from 'src/environments/environment';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';
import { CarBrand } from '../types/CarPartsShop.types';

@Injectable({
  providedIn: 'root',
})
export class CarBrandService {
  readonly APIUrl = environment.APIUrl;
  constructor(private http: HttpClient) {}

  getCarBrandList(): Observable<CarBrand[]> {
    return this.http.get<CarBrand[]>(this.getEndPoint());
  }
  getCarBrandById(id: string): Observable<CarBrand> {
    return this.http.get<CarBrand>(this.getEndPoint(id));
  }
  addCarBrand(carBrand: CarBrand) {
    return this.http.post(this.getEndPoint(), carBrand);
  }

  updateItem(carBrand: CarBrand) {
    return this.http.put(this.getEndPoint(carBrand.id), carBrand);
  }

  deleteItemFromList(id: string) {
    return this.http.delete(this.getEndPoint(id));
  }
  private getEndPoint(id?: string) {
    if (id) return `${this.APIUrl}CarBrand/${id}`;
    return `${this.APIUrl}CarBrand
`;
  }
}
