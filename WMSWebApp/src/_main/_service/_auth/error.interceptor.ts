import { HttpEvent, HttpHandler, HttpInterceptor, HttpRequest} from "@angular/common/http";
import {Injectable} from "@angular/core";
import {catchError, Observable, throwError} from "rxjs";
import {AuthenticationService} from "./auth.service";

@Injectable()
export class ErrorInterceptor implements HttpInterceptor {
  constructor(private authService: AuthenticationService) {
  }
    intercept(request: HttpRequest<any>, next: HttpHandler): Observable<HttpEvent<any>> {
    console.log(`im in error interceptor`);
        return next.handle(request)
          .pipe(catchError(err => {
            if(err.status === 403) {
              this.authService.logout();
            }
            const error = err.error.message || err.statusText;
            return throwError(error);
          }));
    }
}
