import { Injectable } from '@angular/core';
import { environment } from '../../environments/environment.development';
import { HttpClient } from '@angular/common/http';
import { Product } from '../models/product.model';
import { Observable } from 'rxjs';

@Injectable({
  providedIn: 'root',
})
export class ProductService {
  baseApiUrl: string = environment.baseApiUrl;
  constructor(private http: HttpClient) {}

  getAllProducts(): Observable<Product[]> {
    return this.http.get<Product[]>(this.baseApiUrl + '/api/product');
  }

  addProduct(product: Product): Observable<Product> {
    return this.http.post<Product>(this.baseApiUrl + '/api/product', product);
  }

  getProduct(id: string): Observable<Product> {
    return this.http.get<Product>(this.baseApiUrl + '/api/product/' + id);
  }

  deleteProduct(id: string): Observable<Product> {
    return this.http.delete<Product>(this.baseApiUrl + '/api/product/' + id);
  }

  updateProduct(id: string, updateProduct: Product): Observable<Product> {
    return this.http.put<Product>(
      this.baseApiUrl + '/api/product/' + id,
      updateProduct
    );
  }
}
