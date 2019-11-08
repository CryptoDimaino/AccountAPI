import { Injectable } from '@angular/core';
import { HttpClient, HttpHeaders } from '@angular/common/http';

import { Response } from '../Models/response';
import { AccountList, AccountAdd, AccountEdit, Account, AccountPlatform } from '../Models/account';

import { BaseUrl } from './url';

@Injectable({
  providedIn: 'root'
})
export class AccountService {

  private headerOptions: any;
  private newUrl = new BaseUrl();
  private baseUrl: string = this.newUrl.baseUrl + "account";

  private httpOptions = {
    headers: new HttpHeaders({
      'Content-Type': 'applicaton/json; charset=utf-8'
    })
  };

  constructor(private httpClient: HttpClient) { }

  async getAccounts() {
    return await this.httpClient.get<Response<AccountList[]>>(this.baseUrl, this.httpOptions).toPromise();
  }

  async getAccount(id: number) {
    return await this.httpClient.get<Response<Account>>(`${this.baseUrl}/${id}`, this.httpOptions).toPromise();
  }

  async addAccount(newAccount: AccountAdd) {
    return await this.httpClient.post<Response<Account>>(this.baseUrl, newAccount).toPromise();
  }

  async editAccount(editAccount: AccountEdit) {
    return await this.httpClient.put<Response<Account>>(`${this.baseUrl}/${editAccount.AccountId}`, editAccount).toPromise();
  }

  async deleteAccount(id: number) {
    return await this.httpClient.delete<Response<Account>>(`${this.baseUrl}/${id}`, this.httpOptions).toPromise();
  }

  async getEmailAccountAndPlatforms() {
    return this.httpClient.get<Response<AccountPlatform[]>>(`${this.baseUrl}/check`, this.httpOptions).toPromise();
  }
}
