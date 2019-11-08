import { Injectable } from '@angular/core';
import { HttpClient, HttpHeaders } from '@angular/common/http';

import { Response } from '../Models/response';
import { CodeList, CodeAdd, CodeEdit, Code } from '../Models/code';

import { BaseUrl } from './url';

@Injectable({
  providedIn: 'root'
})
export class CodeService {

  private headerOptions: any;
  private newUrl = new BaseUrl();
  private baseUrl: string = this.newUrl.baseUrl + "code";

  private httpOptions = {
    headers: new HttpHeaders({
      'Content-Type': 'applicaton/json; charset=utf-8'
    })
  };

  constructor(private httpClient: HttpClient) { }

  async getCodes() {
    return await this.httpClient.get<Response<CodeList[]>>(this.baseUrl, this.httpOptions).toPromise();
  }

  async getCode(id: number) {
    return await this.httpClient.get<Response<Code>>(`${this.baseUrl}/${id}`, this.httpOptions).toPromise();
  }

  async addCode(newCode: CodeAdd) {
    return await this.httpClient.post<Response<Code>>(this.baseUrl, newCode).toPromise();
  }

  async editCode(editCode: CodeEdit) {
    return await this.httpClient.put<Response<Code>>(`${this.baseUrl}/${editCode.CodeId}`, editCode).toPromise();
  }

  async deleteCode(id: number) {
    return await this.httpClient.delete<Response<Code>>(`${this.baseUrl}/${id}`, this.httpOptions).toPromise();
  }
}
