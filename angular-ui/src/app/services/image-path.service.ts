import { Injectable } from '@angular/core';
import { environment } from '../../environments/environment.development';

@Injectable({
  providedIn: 'root'
})
export class ImagePathService {
  baseApiUrl: string = environment.baseApiUrl;
 
  getImageFullPath(serverPath: string): string {
    serverPath = serverPath.replace(/\\/g, '/');
    return `${this.baseApiUrl}/${serverPath}`;
  }
}
