import { HttpClient, HttpHeaderResponse, HttpHeaders, HttpParams } from "@angular/common/http";
import { Injectable } from "@angular/core";
import { DeliveryApiUrl } from "src/data/api/apiUrl";
import { DeliveryModel } from "src/models/delivery.model";
import { Observable} from "rxjs";
import { SharedService } from "./shared.service";

@Injectable({
  providedIn: 'root'
})
export class DeliveryService extends SharedService {

  constructor(private httpClient: HttpClient){
    super(httpClient);
  }

  getDeliveries(name?: string): Observable<DeliveryModel> {
    let filterParam = new HttpParams();
    if(name) {
      filterParam = filterParam.set('Name', name);
    }
    const url = this.combineUrl(DeliveryApiUrl.getDeliveries);
    return this.http.get<DeliveryModel>(url, {params: filterParam});
  }
}
