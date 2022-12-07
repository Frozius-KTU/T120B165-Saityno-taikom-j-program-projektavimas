import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';
import { CarBrandService } from 'src/app/core/services/car-brand.service';
import { CarBrand } from 'src/app/core/types/CarPartsShop.types';

@Component({
  selector: 'app-car-brand',
  templateUrl: './car-brand.component.html',
  styleUrls: ['./car-brand.component.scss']
})
export class CarBrandComponent implements OnInit {

  carBrandList?: CarBrand[];


  constructor(
    private carBrandService : CarBrandService,
    private route: Router
  ) { }

  ngOnInit(): void {
    this.getCarBrandList();
  }
  getCarBrandList() {
    this.carBrandService.getCarBrandList().subscribe({
      next: (data) => {
        this.carBrandList = data;
      },
      error: (error) => {
        console.log(error);
      },
    });
  }

}
