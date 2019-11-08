import { Injectable } from '@angular/core';
import { HttpClient, HttpHeaders } from '@angular/common/http';

import { Response } from '../Models/response';
import { EventList, EventAdd, EventEdit, Event } from '../Models/event';

import { BaseUrl } from './url';

@Injectable({
  providedIn: 'root'
})
export class EventService {

  private headerOptions: any;
  private newUrl = new BaseUrl();
  private baseUrl: string = this.newUrl.baseUrl + "event";

  private httpOptions = {
    headers: new HttpHeaders({
      'Content-Type': 'applicaton/json; charset=utf-8'
    })
  };

  constructor(private httpClient: HttpClient) { }

  async getEvents()  {
    return await this.httpClient.get<Response<EventList[]>>(this.baseUrl, this.httpOptions).toPromise();
  }

  async getEvent(id: number) {
    return await this.httpClient.get<Response<Event>>(`${this.baseUrl}/${id}`, this.httpOptions).toPromise();
  }

  async addEvent(newEvent: EventAdd) {
    return await this.httpClient.post<Response<Event>>(this.baseUrl, newEvent).toPromise();
  }

  async editEvent(editEvent: EventEdit) {
    return await this.httpClient.put<Response<Event>>(this.baseUrl, editEvent).toPromise();
  }

  async deleteEvent(id: number) {
    return await this.httpClient.delete<Response<Event>>(this.baseUrl, this.httpOptions).toPromise();
  }
}
