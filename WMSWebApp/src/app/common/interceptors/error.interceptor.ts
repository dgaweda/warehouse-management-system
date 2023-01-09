import { HttpEvent, HttpHandler, HttpInterceptor, HttpRequest, HttpResponseBase} from "@angular/common/http";
import {Injectable} from "@angular/core";
import {catchError, Observable, throwError} from "rxjs";
import {AuthenticationService} from "../../auth/auth.service";

@Injectable()
export class ErrorInterceptor implements HttpInterceptor {
  constructor(private authService: AuthenticationService) {
  }
    intercept(request: HttpRequest<any>, next: HttpHandler): Observable<HttpEvent<HttpResponseBase>> {
      console.info(request);
      return next.handle(request)
        .pipe(
          catchError(error => {
            if (error.status === 403) {
              this.authService.logout();
            }
            return throwError(error);
          })
        );
    }
}
