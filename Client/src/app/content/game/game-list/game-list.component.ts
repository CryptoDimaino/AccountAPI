import { Component, OnInit } from '@angular/core';
import { PaginationInstance } from 'ngx-pagination';
import { DatePipe } from '@angular/common';

import { GameService } from '../../../Services/game.service';
import { Response } from '../../../Models/response';
import { Game, GameAccount, GameList, GameAdd, GameEdit } from '../../../Models/game';


@Component({
  selector: 'app-game-list',
  templateUrl: './game-list.component.html',
  styleUrls: ['./game-list.component.scss']
})
export class GameListComponent implements OnInit {

  // Loaded
  private loaded: boolean;

  // API data
  private response: Response<GameList[]>;
  private gameList: GameList[] = [];
  private numberOfGames: number;

  // Pipe Search
  private searchText: string;

  // Pagination
  private page: number;
  private maxSize: number;
  private directionLinks: boolean;
  private autoHide: boolean;
  private responsive: boolean;

  private config: PaginationInstance = {
    id: 'custom',
    itemsPerPage: 25,
    currentPage: 1
  };

  // Select
  private numberToShow: number = 25;
  private selectOptions: any = [];

  // Sort
  private key: string;
  private reverse: boolean;
  private caseInsensitive: boolean;

  constructor(private gameService: GameService, private datePipe: DatePipe) { }

  async ngOnInit() {
    // Check if API was loaded
    this.loaded = false;

    // Loads response and all game list
    await this.loadResponse();

    // Checks to see if there was an error trying to load the API
    if(this.response.DidError) {
    }
    else {

      this.gameList.forEach(element => {
        element.ReleaseDate = this.datePipe.transform(element.ReleaseDate, 'yyyy/MM');
      });
      // Sort
      this.key = 'Title';
      this.reverse = false;
      this.caseInsensitive = false;

      // Select
      this.page = 1;
      this.numberOfGames = this.gameList.length;
      this.selectOptions = [10, 25, 50, 100, this.numberOfGames];
      this.numberToShow = 25;
      this.config.itemsPerPage = this.numberToShow;

      // Pagination
      this.maxSize = 7;
      this.directionLinks = false;
      this.autoHide = true;
      this.responsive = true;
    }
  }

  // Reads in data from API
  async loadResponse() {
    await this.gameService.getGames().then((data: Response<GameList[]>) => {
      this.response = data;
      this.gameList = this.response.Model;
      this.loaded = true;
      console.log(this.gameList);
    })
  }

  // Reads in select number
  onChange(itemsPerPageValue: number) {
    this.numberToShow = itemsPerPageValue;
    this.config.itemsPerPage = this.numberToShow;
  }

  // Sorts columns
  sort(key: string) {
    this.key = key;
    this.reverse = !this.reverse;
  }
}
