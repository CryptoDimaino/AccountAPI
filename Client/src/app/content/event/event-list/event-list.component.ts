import { Component, OnInit } from '@angular/core';
import { PaginationInstance } from 'ngx-pagination';

import { EventService } from '../../../Services/event.service';
import { Response } from '../../../Models/response';
import { EventList } from '../../../Models/event';

@Component({
  selector: 'app-event-list',
  templateUrl: './event-list.component.html',
  styleUrls: ['./event-list.component.scss']
})
export class EventListComponent implements OnInit {

  // Loaded
  private loaded: boolean;

  // API data
  private response: Response<EventList[]>;
  private eventList: EventList[] = [];
  private numberOfEvents: number;

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

  constructor(private eventService: EventService) { }

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
      this.key = 'Name';
      this.reverse = false;
      this.caseInsensitive = false;

      // Select
      this.page = 1;
      this.numberOfEvents = this.eventList.length;
      this.selectOptions = [10, 25, 50, 100, this.numberOfEvents];
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
    await this.eventService.getEvents().then((data: Response<EventList[]>) => {
      this.response = data;
      this.eventList = this.response.Model;
      this.loaded = true;
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
