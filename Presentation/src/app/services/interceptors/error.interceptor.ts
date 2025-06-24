import { HttpErrorResponse, HttpInterceptorFn } from '@angular/common/http';
import { catchError, EMPTY, throwError } from 'rxjs';
import { inject } from '@angular/core';
import { NzMessageService } from 'ng-zorro-antd/message';

export const errorInterceptor: HttpInterceptorFn = (req, next) => {
  const notify = inject(NzMessageService);

  return next(req).pipe(
    catchError((errorResponse: HttpErrorResponse) => {
      if (req.responseType === 'blob' && errorResponse.error instanceof Blob) {
        Promise.resolve(errorResponse).then(async x => {
          notify.create("error", JSON.parse(await x.error.text()));
        });
      } else if (errorResponse.error != "" && errorResponse.error != null) {
        notify.create("error", errorResponse.error);
      } else {
        return EMPTY;
      }

      return throwError(errorResponse.error);
    })
  );
};
