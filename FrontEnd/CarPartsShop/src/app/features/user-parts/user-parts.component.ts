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
import { AccountsService } from 'src/app/core/services/accounts.service';
import { AlertsService } from 'src/app/core/services/alerts.service';
import { CarModelService } from 'src/app/core/services/car-model.service';
import { CarPartService } from 'src/app/core/services/car-part.service';
import { CarModel, CarPart, User } from 'src/app/core/types/CarPartsShop.types';
import { v4 } from 'uuid';
@Component({
  selector: 'app-user-parts',
  templateUrl: './user-parts.component.html',
  styleUrls: ['./user-parts.component.scss'],
})
export class UserPartsComponent implements OnInit {
  public loading: boolean = false;

  public skip: number = 0;
  public pageSize: number = 5;
  public carParts: CarPart[] = [];
  public carModels?: CarModel[];
  public user?: User;
  constructor(
    private carPartsService: CarPartService,
    private carModelService: CarModelService,
    private alertService: AlertsService,
    private accountService: AccountsService
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
    this.accountService.currentUser.subscribe({
      next: (val) => {
        if (val) this.user = val;
      },
    });
    console.log(this.user?.id);
    this.getCarPartList();
    this.getCarModelList();
  }
  getCarModelList() {
    this.carModelService.getCarModelList().subscribe({
      next: (data) => {
        this.carModels = data;
      },
      error: (error) => {
        console.log(error);
      },
    });
  }
  getCarPartList() {
    if (!this.user) return;
    this.loading = true;
    this.carPartsService
      .getCarPartByUserId(this.user.id)
      .pipe(finalize(() => (this.loading = false)))
      .subscribe({
        next: (data) => {
          this.carParts = data;
        },
      });
  }
  public onCellClick(event: CellClickEvent): void {
    this.clickedCell = event;
  }

  public pageChange(event: PageChangeEvent): void {
    this.skip = event.skip;
    this.pageSize = event.pageSize;

    this.getCarPartList();
  }

  public editHandler(event: EditEvent): void {
    const formGroup = new FormGroup({
      id: new FormControl<string>(event.dataItem.id),
      name: new FormControl<string>(event.dataItem.name),
      description: new FormControl<string>(event.dataItem.description),
      qty: new FormControl<number>(event.dataItem.qty),
      carModel: new FormControl<CarModel | undefined>(event.dataItem.carModel),
      photoUrl: new FormControl<string>(event.dataItem.photoUrl),
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
      description: new FormControl<string>('', [Validators.required]),
      qty: new FormControl<number>(0, [Validators.required]),
      photoUrl: new FormControl<string>('', [Validators.required]),
      carModel: new FormControl<CarModel | undefined>(
        { name: '', carBrand: { name: '' } },
        [Validators.required]
      ),
    });

    event.grid.addRow(formGroup);
  }

  public saveHandler(event: SaveEvent): void {
    if (event.formGroup.invalid) return console.log('netinka');

    const value = event.formGroup.getRawValue() as CarPart;

    const sub = event.isNew
      ? this.carPartsService.addCarPart(value)
      : this.carPartsService.updateItem(value);

    sub.subscribe({
      next: () => {
        this.getCarPartList();
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
          this.carPartsService.deleteItemFromList(event.dataItem.id).subscribe({
            next: () => {
              this.getCarPartList();
            },
          });
        },
      });
  }
}
