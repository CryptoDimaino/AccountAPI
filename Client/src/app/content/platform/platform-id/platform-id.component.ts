import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';
import { ActivatedRoute } from '@angular/router';
import { DatePipe } from '@angular/common';
import { PaginationInstance } from 'ngx-pagination';

import { PlatformService } from '../../../Services/platform.service';

import { PlatformList, PlatformAdd, PlatformEdit, Platform, PlatformGames, PlatformAccounts, Platforms } from '../../../Models/platform';
import { Response } from '../../../Models/response';

@Component({
  selector: 'app-platform-id',
  templateUrl: './platform-id.component.html',
  styleUrls: ['./platform-id.component.scss']
})
export class PlatformIdComponent implements OnInit {

  // Route Id
  private id: number;

  private Title: string;

  // Models
  private platform: Platform;
  private response: Response<Platform>;
  private numberOfGames: number;
  private numberOfAccounts: number;

  private games: PlatformGames[];
  private accounts: PlatformAccounts[];

  private gamesExist: boolean;
  private accountsExist: boolean;

  // Loaded
  private loaded: boolean;

  // Pipe Search
  private searchText: string;
  private searchText1: string;

  // Pagination
  private maxSize: number;
  private directionLinks: boolean;
  private autoHide: boolean;
  private responsive: boolean;

  private config: PaginationInstance = {
    id: 'custom',
    itemsPerPage: 10,
    currentPage: 1,
    totalItems: this.numberOfGames
  };

  private config1: PaginationInstance = {
    id: 'custom1',
    itemsPerPage: 10,
    currentPage: 1,
    totalItems: this.numberOfAccounts
  };

  // Select
  private numberToShow: number;
  private selectOptions: any = [];

  // Sort
  private key: string;
  private reverse: boolean;
  private caseInsensitive: boolean;

  // Select
  private numberToShow1: number;
  private selectOptions1: any = [];

  // Sort
  private key1: string;
  private reverse1: boolean;
  private caseInsensitive1: boolean;

  constructor(private route: ActivatedRoute, private router: Router, private platformService: PlatformService, private datePipe: DatePipe) { }

  async ngOnInit() {
    this.loaded = false;
    this.id = this.route.snapshot.params.id;

    this.Title = "Waiting...";

    await this.loadResponse();

    if(this.response.DidError) {
      this.Title = "Platform Does Not Exist.";
      this.loaded = false;
    }
    else {
      this.Title = this.platform.Name;

      // Display Date
      this.platform.UpdatedAt = this.datePipe.transform(this.platform.UpdatedAt, "mediumDate");
      this.platform.CreatedAt = this.datePipe.transform(this.platform.CreatedAt, "mediumDate");

      // Sort
      this.key = 'Name';
      this.reverse = false;
      this.caseInsensitive = false;

      // Select
      this.numberOfGames = this.platform.Games.length;
      this.selectOptions = [10, 25, 50, 100, this.numberOfGames];
      this.numberToShow = 10;
      this.config.itemsPerPage = this.numberToShow;

      // Sort
      this.key1 = 'Username';
      this.reverse1 = false;
      this.caseInsensitive1 = false;

      // Select
      this.numberOfAccounts = this.platform.Accounts.length;
      this.selectOptions1 = [10, 25, 50, 100, this.numberOfAccounts];
      this.numberToShow1 = 10;
      this.config1.itemsPerPage = this.numberToShow1;

      // Pagination
      this.maxSize = 7;
      this.directionLinks = false;
      this.autoHide = true;
      this.responsive = true;

      this.gamesExist = this.numberOfGames > 0;
      this.accountsExist = true//this.numberOfAccounts > 0;
    }
  }

  // Reads in data from API
  async loadResponse() {
    await this.platformService.getPlatform(this.id).then((data: Response<Platform>) => {
      this.response = data;
      this.platform = data.Model;
      this.games = data.Model.Games;
      this.accounts = data.Model.Accounts;
      this.loaded = true;
      console.log(this.platform);
    }).catch(error => {
      console.log(error);
    });
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


  // Reads in select number
  onChange1(itemsPerPageValue: number) {
    this.numberToShow1 = itemsPerPageValue;
    this.config1.itemsPerPage = this.numberToShow1;
  }

  // Sorts columns
  sort1(key: string) {
    this.key1 = key;
    this.reverse1 = !this.reverse1;
  }

  private DeletePlatform() {
    this.platformService.deletePlatform(this.id).then(data => {
      if(data.DidError) {
        alert(data.Message);
      }
      else {
        this.router.navigate(['/platforms']);
      }
    }).catch(error => {
      console.log(error);
    });
  }
}
