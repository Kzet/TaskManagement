import { Injectable } from '@angular/core';
import { ActivatedRouteSnapshot, CanActivate, CanActivateChild, Router, RouterStateSnapshot } from '@angular/router';
import { AuthService } from '../auth.service';
@Injectable({
  providedIn: 'root'
})
export class NonAuthGuardService implements CanActivate, CanActivateChild {
  constructor(private authServie: AuthService, private router: Router) { }

  canActivate(route: ActivatedRouteSnapshot, state: RouterStateSnapshot): any {
    const user = this.authServie.userValue;

    if (user && user.token) {
      this.router.navigate(['/']);
      return false;
    }
    else {
      return true;
    }
  }

  canActivateChild(route: ActivatedRouteSnapshot, state: RouterStateSnapshot): any {
    const user = this.authServie.userValue;

    if (user && user.token) {
      this.router.navigate(['/']);
      return false;
    }
    else {
      return true;
    }
  }
}
