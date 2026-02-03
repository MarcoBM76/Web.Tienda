import { Injectable } from '@angular/core';

@Injectable({ providedIn: 'root' })
export class AuthService {

  login(usuario: string, password: string): string | null {
    let rol = null;

    // Simulación de validación de roles
    if (usuario === 'admin' && password === '1234') {
      rol = 'ADMIN';
    } else if (usuario === 'cliente' && password === '1234') {
      rol = 'USER';
    }

    if (rol) {
      localStorage.setItem('isLoggedIn', 'true');
      localStorage.setItem('userRole', rol);
      return rol;
    }
    return null;
  }

  getRole(): string | null {
    return localStorage.getItem('userRole');
  }

  isAuthenticated(): boolean {
    return localStorage.getItem('isLoggedIn') === 'true';
  }

  logout() {
    localStorage.clear();
  }
}
