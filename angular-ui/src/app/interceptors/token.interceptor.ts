import { Observable, throwError } from 'rxjs';
import { AuthService } from '../services/auth.service';
import { Injectable } from '@angular/core';
import { catchError } from 'rxjs/operators';
import {
  HttpEvent,
  HttpHandler,
  HttpInterceptor,
  HttpRequest,
} from '@angular/common/http';

@Injectable()
export class TokenInterceptor implements HttpInterceptor {
  constructor(private authService: AuthService) {}

  intercept(
    req: HttpRequest<any>,
    next: HttpHandler
  ): Observable<HttpEvent<any>> {
    const authToken = this.authService.getToken();

    if (!authToken) {
      return next.handle(req); // No token, proceed with the original request
     }

    const authReq = req.clone({
      setHeaders: {
        Authorization: `Bearer ${authToken}`,
      },
    });

    return next.handle(authReq).pipe(
      catchError((error) => {
        // Handle errors here
        console.error('Error occurred in HTTP request:', error);
        return throwError(() => error);
      })
    );
  }
}
