import { environment } from "../../environments/environment";
import {HttpClient, HttpParams} from "@angular/common/http";

export class SharedService {
  apiUrl: string;
  http: HttpClient;

  constructor(httpClient: HttpClient) {
    this.http = httpClient;
    this.apiUrl = environment.apiUrl;
  }

  combineUrl(endpointPath: string, filter?: string): string {
    if(filter){
      return this.apiUrl + endpointPath + filter;
    }
    return this.apiUrl + endpointPath;
  }
}
