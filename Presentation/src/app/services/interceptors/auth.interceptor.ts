import {HttpEvent, HttpHandlerFn, HttpInterceptorFn, HttpRequest} from "@angular/common/http";
import {AuthService} from "../auth.service";
import {inject} from "@angular/core";
import {catchError, Observable, of, switchMap, throwError} from "rxjs";
import {User} from "../../models/user/user.model";
import {NzMessageService} from "ng-zorro-antd/message";


export const authInterceptor: HttpInterceptorFn = (request: HttpRequest<unknown>, next: HttpHandlerFn) => {
  const authService = inject(AuthService);
  const notify = inject(NzMessageService);
  if (['refreshToken', 'resetPassword', 'authenticate', 'shared'].some(endpoint => request.url.includes(endpoint)))
    return next(request);


  if (authService.loggedIn) {
    const user = authService.userValue;
    if (authService.isTokenExpired(authService.GetToken)) {
      if (!authService.isRefreshing) {
        return authService.refreshToken(user.email, user.token, user.refreshToken).pipe(
          switchMap((user: User) => {
            return handleAuthorizedRequest(request, next, authService, user, notify);
          })
        )
      } else {
        return authService.pipeToRefreshToken().pipe(
          switchMap((newUser: User) => {
            return handleAuthorizedRequest(request, next, authService, newUser, notify)
          })
        )
      }
    } else {
      return handleAuthorizedRequest(request, next, authService, user, notify);
    }
  } else {
    return next(request);
  }
}

const handleAuthorizedRequest = (request: HttpRequest<unknown>, next: HttpHandlerFn, authService: AuthService, user: User, notify: NzMessageService): Observable<HttpEvent<unknown>> => {
  return next(addTokenHeader(request, user.token))
    .pipe(
      catchError((err) => {
        if ([401].includes(err.status) && authService.userValue) {
          authService.logout();
          notify.create("error", "Превышено время бездействия");
          return of(err);
        }
        return throwError(err);
      })
    );
}

const addTokenHeader = (request: HttpRequest<any>, token: string) => {
  request = request.clone({
    setHeaders: {
      Authorization: `Bearer ${token}`
    },
  });
  return request;
}

