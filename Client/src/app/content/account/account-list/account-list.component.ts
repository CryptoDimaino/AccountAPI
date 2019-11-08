import { Component, OnInit } from '@angular/core';
import { PaginationInstance } from 'ngx-pagination';

import { AccountService } from '../../../Services/account.service';
import { Response } from '../../../Models/response';
import { AccountList, AccountAdd, AccountPlatform } from '../../../Models/account';

import { PlatformService } from '../../../Services/platform.service';

import { PlatformList, PlatformAdd, PlatformEdit, Platform, Platforms } from '../../../Models/platform';


@Component({
  selector: 'app-account-list',
  templateUrl: './account-list.component.html',
  styleUrls: ['./account-list.component.scss']
})
export class AccountListComponent implements OnInit {

  // Loaded
  private loaded: boolean;

  // API data
  private response: Response<AccountList[]>;
  private accountList: AccountList[] = [];
  private numberOfAccounts: number;

  private platResponse: Response<PlatformList[]>;
  private platformList: PlatformList[] = [];

  private filterList: AccountList[] = [];

  private resetFilterSelect: PlatformList;

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

  constructor(private accountService: AccountService, private platformService: PlatformService) { }

  async ngOnInit() {
    // Check if API was loaded
    this.loaded = false;

    this.resetFilterSelect = {
      GameCount: 0,
      Platform: "All",
      Id: 0
    }


    // Loads response and all game list
    await this.loadResponse();

    // Checks to see if there was an error trying to load the API
    if(this.response.DidError) {
    }
    else {
      // Sort
      this.key = 'Username';
      this.reverse = false;
      this.caseInsensitive = false;

      // Select
      this.numberOfAccounts = this.accountList.length;
      this.selectOptions = [10, 25, 50, 100, this.numberOfAccounts];
      this.numberToShow = 25;
      this.config.itemsPerPage = this.numberToShow;

      // Select Platform
    this.platformList.push(this.resetFilterSelect);


      // Pagination
      this.page = 1;
      this.maxSize = 7;
      this.directionLinks = false;
      this.autoHide = true;
      this.responsive = true;
    }
  }

  // Reads in data from API
  async loadResponse() {
    await this.accountService.getAccounts().then((data: Response<AccountList[]>) => {
      this.response = data;
      this.accountList = data.Model;
      this.filterList = data.Model;
      this.loaded = true;
    });

    await this.platformService.getPlatformsWithId().then((data: Response<PlatformList[]>) => {
      this.platResponse = data;
      this.platformList = data.Model;
    });
  }

  // Reads in select number
  onChange(itemsPerPageValue: number) {
    this.numberToShow = itemsPerPageValue;
    this.config.itemsPerPage = this.numberToShow;
  }

  // Filters table based on platform
  onPickPlatform(platform: string) {
    console.log(platform);
    this.filterList = [];
    this.accountList.forEach(account => {
      if(account.Platform === platform)
      {
        this.filterList.push(account);
      }
    });
    if(this.filterList.length == 0)
    {
      this.filterList = this.accountList;
    }
    console.log(this.filterList);

  }

  // Sorts columns
  sort(key: string) {
    this.key = key;
    this.reverse = !this.reverse;
  }
}
