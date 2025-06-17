import { Routes } from '@angular/router';
import { NonAuthGuardService } from './services/guards/nonauth.guard';
import { AuthGuardService } from './services/guards/auth.guard';
import { LoginComponent } from './pages/login/login.component';
import { RegisterComponent } from './pages/register/register.component';

export const routes: Routes = [
  /*{ path: '', pathMatch: 'full', redirectTo: '/welcome' },
  { path: 'welcome', loadChildren: () => import('./pages/welcome/welcome.routes').then(m => m.WELCOME_ROUTES) }*/

  {
    path: '',
    loadChildren: () =>
      import('./layouts/main-layout/main-layout.routes').then(
        (m) => m.MAIN_ROUTES
      ),
    canActivate: [AuthGuardService]
  },
  {
    path: 'login',
    component: LoginComponent,
    canActivate: [NonAuthGuardService]
  },
  {
    path: 'register',
    component: RegisterComponent,
    canActivate: [NonAuthGuardService]
  }
];
