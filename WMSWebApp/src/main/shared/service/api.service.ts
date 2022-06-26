import {HttpParams} from "@angular/common/http";
import {Injectable} from "@angular/core";
import {RequestParam} from "../models/requestParam.model";
@Injectable({
    providedIn: 'root'
})
export class ApiService {

  createHttpParams(requestParams: RequestParam[]): HttpParams {
    let params = new HttpParams();
    requestParams.filter((param: RequestParam) => param.value)
      .forEach((param: RequestParam) => params = params.append(param.key, <string>param.value));

    return params;
  }
}
