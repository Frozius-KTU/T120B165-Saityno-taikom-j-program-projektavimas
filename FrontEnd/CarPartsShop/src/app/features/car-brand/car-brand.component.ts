import { Component, OnInit } from '@angular/core';
import { FormControl, FormGroup, Validators } from '@angular/forms';
import {
  CellClickEvent,
  PageChangeEvent,
  PagerSettings,
  PaginatedList,
} from 'angular-helper-utils';
import {
  AddEvent,
  CancelEvent,
  EditEvent,
  RemoveEvent,
  SaveEvent,
} from 'angular-helper-utils/lib/components/grid/types/edit.events';
import { finalize } from 'rxjs';
import { AlertsService } from 'src/app/core/services/alerts.service';
import { CarBrandService } from 'src/app/core/services/car-brand.service';
import { CarBrand } from 'src/app/core/types/CarPartsShop.types';
import Swal from 'sweetalert2';
import { v4 } from 'uuid';
@Component({
  selector: 'app-car-brand',
  templateUrl: './car-brand.component.html',
  styleUrls: ['./car-brand.component.scss'],
})
export class CarBrandComponent implements OnInit {
  public loading: boolean = false;

  public skip: number = 0;
  public pageSize: number = 6;
  public carBrands: PaginatedList<CarBrand> = { data: [], total: 0 };

  constructor(
    private carBrandService: CarBrandService,
    private alertsService: AlertsService
  ) {}

  public pagerSettings: PagerSettings = {
    pageSizes: [10, 20, 50, 100],
    buttonCount: 5,
  };
  public setLoading(miliseconds: number): void {
    this.loading = true;
    setTimeout(() => {
      this.loading = false;
    }, miliseconds);
  }

  public clickedCell: CellClickEvent | undefined;

  ngOnInit(): void {
    this.getCarBrandList();
  }
  getCarBrandList() {
    this.loading = true;
    this.carBrandService
      .getCarBrandList()
      .pipe(finalize(() => (this.loading = false)))
      .subscribe({
        next: (data) => {
          this.carBrands = {
            data: data.slice(this.skip, this.skip + this.pageSize),
            total: data.length,
          };
        },
        error: (error) => {
          console.log(error);
        },
      });
  }
  public onCellClick(event: CellClickEvent): void {
    this.clickedCell = event;
  }

  public pageChange(event: PageChangeEvent): void {
    this.skip = event.skip;
    this.pageSize = event.pageSize;

    this.getCarBrandList();
  }

  public editHandler(event: EditEvent): void {
    const formGroup = new FormGroup({
      id: new FormControl(event.dataItem.id),
      name: new FormControl(event.dataItem.name),
    });

    event.grid.editRow(event.rowIndex, formGroup);
  }

  public cancelHandler(event: CancelEvent): void {
    event.grid.closeRow(event.rowIndex);
  }

  public addHandler(event: AddEvent): void {
    const formGroup = new FormGroup({
      id: new FormControl(v4()),
      name: new FormControl<string>('', [Validators.required]),
    });

    event.grid.addRow(formGroup);
  }

  public saveHandler(event: SaveEvent): void {
    if (event.formGroup.invalid) return console.log('netinka');

    const value = event.formGroup.getRawValue() as CarBrand;

    const sub = event.isNew
      ? this.carBrandService.addCarBrand(value)
      : this.carBrandService.updateItem(value);

    sub.subscribe({
      next: () => {
        this.getCarBrandList();
      },
    });

    event.grid.closeRow(event.rowIndex);
  }

  public removeHandler(event: RemoveEvent): void {
    this.alertsService
      .confirm('Remove', 'Do you truly wish to remove this object?')
      .subscribe({
        next: (isConfirmed) => {
          if (!isConfirmed) return;
          this.carBrandService.deleteItemFromList(event.dataItem.id).subscribe({
            next: () => {
              this.getCarBrandList();
            },
          });
        },
      });
  }
}
