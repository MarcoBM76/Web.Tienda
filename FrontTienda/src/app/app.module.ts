import { NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';

import { AppComponent } from './app.component';
import { HttpClientModule } from '@angular/common/http';
import { CarritoComponent } from './components/carrito/carrito.component';
import { HomeComponent } from './components/home/home.component';
import { AppRoutingModule } from './app-routing.module';
import { NavComponent } from './components/shared/nav/nav.component';
import { TiendaComponent } from './components/tienda/tienda.component';
import { ClienteComponent } from './components/cliente/cliente.component';
import { ArticuloComponent } from './components/articulo/articulo.component';
import { ReactiveFormsModule } from '@angular/forms';
import { LoginComponent } from './components/login/login.component';

@NgModule({
  declarations: [
    AppComponent,
    CarritoComponent,
    HomeComponent,
    NavComponent,
    TiendaComponent,
    ClienteComponent,
    ArticuloComponent,
    LoginComponent
  ],
  imports: [
    BrowserModule,
    HttpClientModule,
    AppRoutingModule,
    ReactiveFormsModule
  ],
  providers: [],
  bootstrap: [AppComponent]
})
export class AppModule { }
