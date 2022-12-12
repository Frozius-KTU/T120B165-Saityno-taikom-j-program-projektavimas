import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';
import { FilterableDataSource } from 'angular-helper-utils';
import { CarBrandService } from 'src/app/core/services/car-brand.service';
import { CarModelService } from 'src/app/core/services/car-model.service';
import { CarPartService } from 'src/app/core/services/car-part.service';
import {
  CarBrand,
  CarModel,
  CarPart,
} from 'src/app/core/types/CarPartsShop.types';

@Component({
  selector: 'app-home',
  templateUrl: './home.component.html',
  styleUrls: ['./home.component.scss'],
})
export class HomeComponent implements OnInit {
  constructor(
    private carPartService: CarPartService,
    private router: Router,
    private carBrandService: CarBrandService,
    private carModelService: CarModelService
  ) {}
  public carParts: CarPart[] = [];
  public carBrands: CarBrand[] = [];
  public carModels: FilterableDataSource<CarModel> =
    new FilterableDataSource<CarModel>();

  ngOnInit(): void {
    this.getCarPartList();
    this.getCarModelList();
    this.getCarBrandList();
  }
  setThing(carModel: CarModel): void {
    if (!carModel) this.getCarPartList();
    else if (carModel.id != null) {
      this.carPartService.getCarPartByModelId(carModel.id).subscribe({
        next: (data) => {
          this.carParts = data;
        },
      });
    }
  }
  getCarPartList() {
    this.carPartService.getCarPartList().subscribe({
      next: (data) => {
        this.carParts = data;
      },
      error: (error) => {
        console.log(error);
      },
    });
  }
  getCarModelList() {
    this.carModelService.getCarModelList().subscribe({
      next: (data) => {
        this.carModels.set(data);
      },
      error: (error) => {
        console.log(error);
      },
    });
  }
  getCarBrandList() {
    this.carBrandService.getCarBrandList().subscribe({
      next: (data) => {
        this.carBrands = data;
      },
      error: (error) => {
        console.log(error);
      },
    });
  }
  openItemWindow(id: string) {
    this.router.navigate(['item', id]);
  }
}
