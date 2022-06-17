import {HttpParams} from "@angular/common/http";
import {Injectable} from "@angular/core";
@Injectable({
    providedIn: 'root'
})
export class ApiService {

  createHttpParam(key: string, value: any): HttpParams {
    let params = new HttpParams();
    if(value) {
      params = params.set(key, value);
    }
    return params;
  }
}
