import { Injectable } from '@angular/core';
import { HttpClient, HttpHeaders } from '@angular/common/http';

import { Response } from '../Models/response';
import { EmailAccountList, EmailAccountAdd, EmailAccountEdit, EmailAccount } from '../Models/emailaccount';

import { BaseUrl } from './url';

@Injectable({
  providedIn: 'root'
})
export class EmailAccountService {

  private headerOptions: any;
  private newUrl = new BaseUrl();
  private baseUrl: string = this.newUrl.baseUrl + "emailaccount";

  private httpOptions = {
    headers: new HttpHeaders({
      'Content-Type': 'applicaton/json; charset=utf-8'
    })
  };

  constructor(private httpClient: HttpClient) { }

  async getEmailAccounts() {
    return await this.httpClient.get<Response<EmailAccountList[]>>(this.baseUrl, this.httpOptions).toPromise();
  }

  async getEmailAccount(id: number) {
    return await this.httpClient.get<Response<EmailAccount>>(`${this.baseUrl}/${id}`, this.httpOptions).toPromise();
  }

  async addEmailAccount(newEmailAccount: EmailAccountAdd) {
    return await this.httpClient.post<Response<EmailAccount>>(this.baseUrl, newEmailAccount).toPromise();
  }

  async editEmailAccount(editEmailAccount: EmailAccountEdit) {
    return await this.httpClient.put<Response<EmailAccount>>(`${this.baseUrl}/${editEmailAccount.EmailAccountId}`, editEmailAccount).toPromise();
  }

  async deleteEmailAccount(id: number) {
    return await this.httpClient.delete<Response<EmailAccount>>(`${this.baseUrl}/${id}`, this.httpOptions).toPromise();
  }
}
