import { Injectable } from '@angular/core';
import { HttpClient, HttpHeaders } from '@angular/common/http';

import { Response } from '../Models/response';
import { PlatformList, PlatformAdd, PlatformEdit, Platform, Platforms } from '../Models/platform';

import { BaseUrl } from './url';

@Injectable({
  providedIn: 'root'
})
export class PlatformService {

  private headerOptions: any;
  private newUrl = new BaseUrl();
  private baseUrl: string = this.newUrl.baseUrl + "platform";
  
  private httpOptions = {
    headers: new HttpHeaders({
      'Content-Type': 'applicaton/json; charset=utf-8'
    })
  };

  constructor(private httpClient: HttpClient) { }

  async getPlatforms() {
    return await this.httpClient.get<Response<PlatformList[]>>(this.baseUrl, this.httpOptions).toPromise();
  }

  async getPlatform(id: number) {
    return await this.httpClient.get<Response<Platform>>(`${this.baseUrl}/${id}`, this.httpOptions).toPromise();
  }

  async editPlatform(editPlatform: PlatformEdit) {
    return await this.httpClient.put<Response<Platform>>(`${this.baseUrl}/${editPlatform.PlatformId}`, editPlatform).toPromise();
  }

  async addPlatform(newPlatform: PlatformAdd) {
    return await this.httpClient.post<Response<Platform>>(this.baseUrl, newPlatform).toPromise();
  }

  async deletePlatform(id: number) {
    return await this.httpClient.delete<Response<Platform>>(`${this.baseUrl}/${id}`, this.httpOptions).toPromise();
  }

  async getPlatformsWithId() {
    return await this.httpClient.get<Response<Platforms[]>>(`${this.baseUrl}/OnlyId`, this.httpOptions).toPromise();
  }
}
