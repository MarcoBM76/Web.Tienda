import { NgModule } from '@angular/core';
import { RouterModule, Routes, PreloadAllModules } from '@angular/router';
import { HomeComponent } from './components/home/home.component';
import { CarritoComponent } from './components/carrito/carrito.component';
import { TiendaComponent } from './components/tienda/tienda.component';
import { ClienteComponent } from './components/cliente/cliente.component';
import { ArticuloComponent } from './components/articulo/articulo.component';
import { LoginComponent } from './components/login/login.component';
import { authGuard } from './guards/auth.guard';
import { roleGuard } from './guards/role.guard';

const routes: Routes = [

  { path: 'login', component: LoginComponent },
  { path: 'articulos', component: ArticuloComponent, canActivate: [authGuard, roleGuard], data: { expectedRole: 'ADMIN' } },
  { path: 'tiendas', component: TiendaComponent, canActivate: [authGuard, roleGuard], data: { expectedRole: 'ADMIN' } },
  { path: 'clientes', component: ClienteComponent, canActivate: [authGuard, roleGuard], data: { expectedRole: 'ADMIN' } },
  { path: 'home', component: HomeComponent, canActivate: [authGuard] },
  { path: 'carrito', component: CarritoComponent, canActivate: [authGuard] },
  { path: '', redirectTo: '/login', pathMatch: 'full' }
];

@NgModule({
  imports: [
    RouterModule.forRoot(routes, {
      preloadingStrategy: PreloadAllModules,
      scrollPositionRestoration: 'enabled',
      initialNavigation: 'enabledBlocking',
    }),
  ],
  exports: [RouterModule],
})
export class AppRoutingModule {}
