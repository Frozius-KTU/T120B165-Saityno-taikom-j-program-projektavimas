import { APP_INITIALIZER, Injector, NgModule, OnInit } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';
import { HttpClientModule, HTTP_INTERCEPTORS } from '@angular/common/http';
import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
import { HomeComponent } from './features/home/home.component';
import { CarBrandComponent } from './features/car-brand/car-brand.component';
import {
  UtilsDropdownsModule,
  UtilsGridModule,
  UtilsInputsModule,
  UtilsLayoutModule,
} from 'angular-helper-utils';
import { LoginComponent } from './features/login/login.component';
import { JwtInterceptor } from './core/interceptors/jwt.interceptor';
import { ReactiveFormsModule } from '@angular/forms';
import { RegisterComponent } from './features/register/register.component';
import { AppInitializer } from './utils/app.initializer';
import { ServiceLocator } from './utils/service-locator';
import { CarModelComponent } from './features/car-model/car-model.component';
import { CrudCommandsComponent } from './core/components/crud-commands/crud-commands.component';
import { ErrorInterceptor } from './core/interceptors/error.interceptor';

function initApp(initializer: AppInitializer) {
  return () => initializer.initialize();
}
@NgModule({
  declarations: [
    AppComponent,
    HomeComponent,
    CarBrandComponent,
    LoginComponent,
    RegisterComponent,
    CarModelComponent,
    CrudCommandsComponent,
  ],
  imports: [
    HttpClientModule,
    BrowserModule,
    AppRoutingModule,
    UtilsGridModule,
    UtilsInputsModule,
    UtilsDropdownsModule,
    UtilsLayoutModule,
    ReactiveFormsModule,
  ],
  providers: [
    AppInitializer,
    {
      provide: APP_INITIALIZER,
      useFactory: initApp,
      deps: [AppInitializer],
      multi: true,
    },
    { provide: HTTP_INTERCEPTORS, useClass: JwtInterceptor, multi: true },
    { provide: HTTP_INTERCEPTORS, useClass: ErrorInterceptor, multi: true },
  ],
  bootstrap: [AppComponent],
})
export class AppModule {
  constructor(private injector: Injector) {
    ServiceLocator.injector = injector;
  }
}
