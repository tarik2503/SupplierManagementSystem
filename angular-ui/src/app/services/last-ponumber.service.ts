import { Injectable } from '@angular/core';
import { environment } from '../../environments/environment.development';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';
import { LastPONumber } from '../models/lastPONumber.model';


@Injectable({
  providedIn: 'root'
})
export class LastPONumberService {
  baseApiUrl: string = environment.baseApiUrl;
  constructor(private http: HttpClient) {}

  getLastPONumber(): Observable<LastPONumber>{
    return this.http.get<LastPONumber>(this.baseApiUrl + '/api/lastponumber'); 
  }

  updateLastPONumber(newLastNumber:number){
    const lastPONumber:LastPONumber =  {
      id : 0,
       lastNumber : newLastNumber,
    }
     this.http.put<LastPONumber>(this.baseApiUrl + '/api/lastponumber', lastPONumber).subscribe({
      next: (response) =>{
         return response
      }
     })
  }
}
