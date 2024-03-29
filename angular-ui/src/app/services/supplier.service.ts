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

  addSupplier(supplier: Supplier): Observable<Supplier> {
    return this.http.post<Supplier>(
      this.baseApiUrl + '/api/supplier',
      supplier
    );
  }

  getSupplier(id: string): Observable<Supplier> {
    return this.http.get<Supplier>(this.baseApiUrl + '/api/supplier/' + id);
  }

  updateSupplier(id: string, updateSupplier: Supplier): Observable<Supplier> {
    return this.http.put<Supplier>(
      this.baseApiUrl + '/api/supplier/' + id,
      updateSupplier
    );
  }

  deleteSupplier(id: string): Observable<Supplier> {
    return this.http.delete<Supplier>(this.baseApiUrl + '/api/supplier/' + id);
  }

  uploadImage(formData: FormData): Observable<HttpEvent<Object>> {
    return this.http.post<HttpEvent<Object>>(
      this.baseApiUrl + '/api/supplier/image',
      formData,
      { reportProgress: true, observe: 'events' }
    );
  }

  getImageFullPath(serverPath: string): string {
    serverPath = serverPath.replace(/\\/g, '/');
    return `${this.baseApiUrl}/${serverPath}`;
  }
}
