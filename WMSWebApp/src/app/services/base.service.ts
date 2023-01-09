import { HttpClient, HttpParams } from "@angular/common/http";
import {Config} from "../common/models/config.model";
import { Observable } from "rxjs";

export class BaseService {
  constructor(private httpClient: HttpClient, private cfg: Config) {
  }

  protected get<T>(endpoint: string, httpParams?: HttpParams): Observable<T> {
    return this.httpClient.get<T>(`${this.cfg.baseApiUrl}${endpoint}`, { params: httpParams });
  }

  protected delete<T>(endpoint: string, httpParams?: HttpParams): Observable<T> {
    return this.httpClient.delete<T>(`${this.cfg.baseApiUrl}${endpoint}`, { params: httpParams });
  }

  protected post<T>(endpoint: string, body?: unknown): Observable<T> {
    return this.httpClient.post<T>(`${this.cfg.baseApiUrl}${endpoint}`, body);
  }

  protected put<T>(endpoint: string, body?: unknown): Observable<T> {
    return this.httpClient.put<T>(`${this.cfg.baseApiUrl}${endpoint}`, body);
  }
}
