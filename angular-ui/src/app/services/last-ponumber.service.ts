import { Injectable } from '@angular/core';
import { environment } from '../../environments/environment.development';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';

@Injectable({
  providedIn: 'root'
})
export class LastPONumberService {
  baseApiUrl: string = environment.baseApiUrl;
  constructor(private http: HttpClient) {}

  getLastPONumber(): Observable<number>{
    return this.http.get<number>(this.baseApiUrl + '/api/lastponumber');
   
  }

  updateLastPONumber(newLastNumber:number): void{
     this.http.put(this.baseApiUrl + '/api/lastponumber', newLastNumber)
  }
}
