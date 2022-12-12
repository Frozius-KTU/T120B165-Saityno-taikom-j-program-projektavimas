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
import { CarModelService } from 'src/app/core/services/car-model.service';
import { CarBrand, CarModel } from 'src/app/core/types/CarPartsShop.types';
import { v4 } from 'uuid';

@Component({
  selector: 'app-car-model',
  templateUrl: './car-model.component.html',
  styleUrls: ['./car-model.component.scss'],
})
export class CarModelComponent implements OnInit {
  public loading: boolean = false;

  public skip: number = 0;
  public pageSize: number = 5;
  public carModels: PaginatedList<CarModel> = { data: [], total: 0 };
  public carBrands?: CarBrand[];
  constructor(
    private carModelService: CarModelService,
    private carBrandService: CarBrandService,
    private alertService: AlertsService
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
    this.getCarModelList();
    this.getCarBrandList();
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
  getCarModelList() {
    this.loading = true;
    this.carModelService
      .getCarModelList()
      .pipe(finalize(() => (this.loading = false)))
      .subscribe({
        next: (data) => {
          this.carModels = {
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

    this.getCarModelList();
  }

  public editHandler(event: EditEvent): void {
    const formGroup = new FormGroup({
      id: new FormControl<string>(event.dataItem.id),
      name: new FormControl<string>(event.dataItem.name),
      carBrand: new FormControl<CarBrand | undefined>(event.dataItem.carBrand),
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
      carBrand: new FormControl<CarBrand | undefined>({ name: '' }, [
        Validators.required,
      ]),
    });

    event.grid.addRow(formGroup);
  }

  public saveHandler(event: SaveEvent): void {
    if (event.formGroup.invalid) return console.log('netinka');

    const value = event.formGroup.getRawValue() as CarModel;

    const sub = event.isNew
      ? this.carModelService.addCarModel(value)
      : this.carModelService.updateItem(value);

    sub.subscribe({
      next: () => {
        this.getCarModelList();
      },
    });

    event.grid.closeRow(event.rowIndex);
  }

  public removeHandler(event: RemoveEvent): void {
    this.alertService
      .confirm('Remove', 'Do you truly wish to remove this object?')
      .subscribe({
        next: (isConfirmed) => {
          if (!isConfirmed) return;
          this.carModelService.deleteItemFromList(event.dataItem.id).subscribe({
            next: () => {
              this.getCarModelList();
            },
          });
        },
      });
  }
}
