import { HttpEvent, HttpHandler, HttpInterceptor, HttpRequest} from "@angular/common/http";
import {Injectable} from "@angular/core";
import {Observable} from "rxjs";
import {AuthenticationService} from "./auth.service";
import {environment} from "../../../environments/environment";

@Injectable()
export class BasicAuthInterceptor implements HttpInterceptor {
  constructor(private authService: AuthenticationService) {
  }
    intercept(request: HttpRequest<any>, next: HttpHandler): Observable<HttpEvent<any>> {
    console.log(`im in auth interceptor`);
        const currentUser = this.authService.currentUser;
        console.log(`currentUser`, currentUser);
        console.log(`isLoggedIn`, currentUser?.data.authData);
        const isApiUrl = request.url.startsWith(environment.apiUrl);
        if(currentUser && isApiUrl) {
          request = request.clone({
            setHeaders: { Authorization: `Basic ${currentUser?.data.authData}`}
          })
        }
        console.log({currentUser: currentUser, isApiUrl: isApiUrl, request: request});
        return next.handle(request);
    }

}
