import { Component, OnInit } from '@angular/core';
import { PaginationInstance } from 'ngx-pagination';

import { PlatformService } from '../../../Services/platform.service';
import { Response } from '../../../Models/response';
import { PlatformList, PlatformAdd, PlatformEdit, Platform, Platforms } from '../../../Models/platform';


@Component({
  selector: 'app-platform-list',
  templateUrl: './platform-list.component.html',
  styleUrls: ['./platform-list.component.scss']
})
export class PlatformListComponent implements OnInit {

  // Title
  private LoadError: boolean;
  private loaded: boolean;

  // API data
  private response: Response<PlatformList[]>;
  private platformList: PlatformList[] = [];
  private numberOfPlatforms: number;

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

  constructor(private platformService: PlatformService) { }

  async ngOnInit() {
    // Check if API was loaded
    this.loaded = false;

    // Loads response and all game list
    await this.loadResponse();

    // Checks to see if there was an error trying to load the API
    if(this.response.DidError) {
      
    }
    else {
      // Sort
      this.key = 'Platform';
      this.reverse = false;
      this.caseInsensitive = false;

      // Select
      this.page = 1;
      this.numberOfPlatforms = this.platformList.length;
      this.selectOptions = [10, 25, 50, 100, this.numberOfPlatforms];
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
    await this.platformService.getPlatforms().then((data: Response<PlatformList[]>) => {
      this.response = data;
      this.platformList = data.Model;
      this.LoadError = false;
      this.loaded = true;
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
}
