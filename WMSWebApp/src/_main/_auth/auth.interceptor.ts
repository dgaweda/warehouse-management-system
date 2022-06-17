import { HttpEvent, HttpHandler, HttpHeaders, HttpInterceptor, HttpRequest} from "@angular/common/http";
import {Injectable} from "@angular/core";
import {Observable} from "rxjs";
import {AuthenticationService} from "./auth.service";
import {environment} from "../../environments/environment";

@Injectable()
export class BasicAuthInterceptor implements HttpInterceptor {

  constructor(private authService: AuthenticationService) {
  }

  intercept(request: HttpRequest<any>, next: HttpHandler): Observable<HttpEvent<any>> {
    const currentUser = this.authService.currentUser;
    const headers = new HttpHeaders({
      'Authorization': `Basic ${currentUser?.authData}`,
      'Content-Type': 'application/json; charset=UTF-8'
    });

    const isApiUrl = request.url.startsWith(environment.apiUrl);
    if(currentUser && isApiUrl) {
      request = request.clone({headers})
    }

    return next.handle(request);
  }

}
