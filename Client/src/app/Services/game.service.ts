import { Injectable } from '@angular/core';
import { HttpClient, HttpHeaders } from '@angular/common/http';

import { Response } from '../Models/response';
import { GameList, GameAdd,  GameEdit, Game } from '../Models/game';

import { BaseUrl } from './url';

@Injectable({
  providedIn: 'root'
})
export class GameService {

  private headerOptions: any;
  private newUrl = new BaseUrl();
  private baseUrl: string = this.newUrl.baseUrl + "game";
  
  private httpOptions = {
    headers: new HttpHeaders({
      'Content-Type': 'applicaton/json; charset=utf-8'
    })
  };

  constructor(private httpClient: HttpClient) { }

  async getGames() {
    return await this.httpClient.get<Response<GameList[]>>(this.baseUrl, this.httpOptions).toPromise();
  }

  async getGame(id: number) {
    return await this.httpClient.get<Response<Game>>(`${this.baseUrl}/${id}`, this.httpOptions).toPromise();
  }

  async addGame(newGame: GameAdd) {
    return await this.httpClient.post<Response<Game>>(this.baseUrl, newGame).toPromise();
  }

  async getGameEdit(editGame: GameEdit) {
    return await this.httpClient.put<Response<Game>>(`${this.baseUrl}/${editGame.GameId}`, editGame).toPromise();
  }

  async deleteGame(id: number) {
    return await this.httpClient.delete<Response<Game>>(`${this.baseUrl}/${id}`, this.httpOptions).toPromise();
  }
}
