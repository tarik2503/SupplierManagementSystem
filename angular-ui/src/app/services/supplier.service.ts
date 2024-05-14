import { HttpClient, HttpEvent } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { environment } from '../../environments/environment.development';
import { Supplier } from '../models/supplier.model';
import { Observable } from 'rxjs';

@Injectable({
  providedIn: 'root',
})
export class SupplierService {
  baseApiUrl: string = environment.baseApiUrl;
  constructor(private http: HttpClient) {}

  getAllSuppliers(): Observable<Supplier[]> {
    return this.http.get<Supplier[]>(this.baseApiUrl + '/api/supplier');
  }

  addSupplier(formData: FormData): Observable<Supplier> {   
    return this.http.post<Supplier>(
      this.baseApiUrl + '/api/supplier',
      formData
    );
  }

  getSupplier(id: string): Observable<Supplier> { 
    return this.http.get<Supplier>(this.baseApiUrl + '/api/supplier/' + id); 
  }

  updateSupplier(id: string, formData: FormData): Observable<Supplier> {
    return this.http.put<Supplier>(
      this.baseApiUrl + '/api/supplier/' + id,
      formData
    );
  }

  deleteSupplier(id: string): Observable<Supplier> {
    return this.http.delete<Supplier>(this.baseApiUrl + '/api/supplier/' + id);
  }
}
