import {
  CanActivateFn,
  Router
} from '@angular/router';
import { inject } from '@angular/core';

// export const authGuard: CanActivateFn = (
//   route: ActivatedRouteSnapshot,
//   state: RouterStateSnapshot
// ) => {
//   return inject(AuthService).isLoggedIn()
//     ? true
//     : inject(Router).createUrlTree(['signup']);
// }

export const authGuard: CanActivateFn = () => {
  
  
  const token = localStorage.getItem('token');
  
  const router: Router = inject(Router);
  if(token!){
    return true;
  }else{
      router.navigate(['login'])
    return false;
  }

};