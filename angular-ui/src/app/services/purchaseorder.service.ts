import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { environment } from '../../environments/environment.development';
import { Observable } from 'rxjs/internal/Observable';
import { Product } from '../models/product.model';
import { PurchaseOrder } from '../models/purchaseorder.model';

@Injectable({
  providedIn: 'root'
})
export class PurchaseorderService {
  baseApiUrl: string = environment.baseApiUrl;
  constructor(private http: HttpClient) {}
  
  getAllPurchaseOrders(): Observable<PurchaseOrder[]> {
    return this.http.get<PurchaseOrder[]>(this.baseApiUrl + '/api/purchaseorder');
  }

  createPurchaseOrder(purchaseOrder: PurchaseOrder): Observable<PurchaseOrder> {
    return this.http.post<PurchaseOrder>(this.baseApiUrl + '/api/purchaseorder', purchaseOrder);
  }

}


