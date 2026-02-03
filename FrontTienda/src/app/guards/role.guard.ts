import { inject } from '@angular/core';
import { CanActivateFn, Router } from '@angular/router';
import { AuthService } from '../service/auth.service';


export const roleGuard: CanActivateFn = (route, state) => {
  const authService = inject(AuthService);
  const router = inject(Router);

  const expectedRole = route.data['expectedRole']; // Obtenemos el rol requerido de la ruta
  const userRole = authService.getRole();

  if (authService.isAuthenticated() && userRole === expectedRole) {
    return true;
  }

  // Si no tiene el rol, redirigir a una página de "No Autorizado" o al Home
  router.navigate(['/home']);
  return false;
};
