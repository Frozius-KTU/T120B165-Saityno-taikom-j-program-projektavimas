import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { CarBrandComponent } from './features/car-brand/car-brand.component';
import { HomeComponent } from './features/home/home.component';

const routes: Routes = [
  {path: 'home', component: HomeComponent},
  {path: 'carBrand', component: CarBrandComponent},
  {path: '**', redirectTo: 'home'}
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
