import { Component, OnInit } from '@angular/core';
import { ActivatedRoute, Router } from '@angular/router';
import { CarPartService } from 'src/app/core/services/car-part.service';
import { CarPart } from 'src/app/core/types/CarPartsShop.types';

@Component({
  selector: 'app-item',
  templateUrl: './item.component.html',
  styleUrls: ['./item.component.scss'],
})
export class ItemComponent implements OnInit {
  constructor(
    private partsService: CarPartService,
    private activatedRoute: ActivatedRoute,
    private route: Router
  ) {}
  carPart?: CarPart;
  ngOnInit(): void {
    let route = this.activatedRoute.params.subscribe((params) => {
      const id = params['id'];
      if (!id) {
        return;
      }

      this.partsService.getCarPartById(id).subscribe({
        next: (data) => {
          this.carPart = data;
        },
        error: (error) => {
          console.log(error);
        },
      });
    });
    console.log(this.carPart?.qty);
  }
}
