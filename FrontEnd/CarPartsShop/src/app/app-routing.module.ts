import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { OnlyAuthorizedGuard } from './core/guards/only-authorized.guard';
import { OnlyUnauthorizedGuard } from './core/guards/only-unauthorized.guard';
import { CarBrandComponent } from './features/car-brand/car-brand.component';
import { CarModelComponent } from './features/car-model/car-model.component';
import { CarPartComponent } from './features/car-part/car-part.component';
import { HomeComponent } from './features/home/home.component';
import { ItemComponent } from './features/item/item.component';
import { LoginComponent } from './features/login/login.component';
import { RegisterComponent } from './features/register/register.component';
import { UserPartsComponent } from './features/user-parts/user-parts.component';

const routes: Routes = [
  { path: 'home', component: HomeComponent },
  {
    path: 'carBrand',
    component: CarBrandComponent,
    canActivate: [OnlyAuthorizedGuard],
  },
  {
    path: 'carModel',
    component: CarModelComponent,
    canActivate: [OnlyAuthorizedGuard],
  },
  {
    path: 'carPart',
    component: CarPartComponent,
    canActivate: [OnlyAuthorizedGuard],
  },
  {
    path: 'login',
    component: LoginComponent,
    canActivate: [OnlyUnauthorizedGuard],
  },
  {
    path: 'register',
    component: RegisterComponent,
    canActivate: [OnlyUnauthorizedGuard],
  },
  {
    path: 'userParts',
    component: UserPartsComponent,
    canActivate: [OnlyAuthorizedGuard],
  },
  { path: 'item/:id', component: ItemComponent },
  { path: '**', redirectTo: 'home' },
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule],
})
export class AppRoutingModule {}
