import { Component, OnInit } from '@angular/core';
import { PaginationInstance } from 'ngx-pagination';

import { EmailAccountService } from '../../../Services/email-account.service';
import { Response } from '../../../Models/response';
import { EmailAccountList, EmailAccountAdd, EmailAccountEdit, EmailAccount } from '../../../Models/emailaccount';




@Component({
  selector: 'app-email-account-list',
  templateUrl: './email-account-list.component.html',
  styleUrls: ['./email-account-list.component.scss']
})
export class EmailAccountListComponent implements OnInit {

   // Loaded
   private loaded: boolean;

   // API data
   private response: Response<EmailAccountList[]>;
   private emailaccountList: EmailAccountList[] = [];
   private numberOfEmailAccounts: number;

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

   constructor(private emailaccountService: EmailAccountService) { }

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
       this.key = 'Email';
       this.reverse = false;
       this.caseInsensitive = false;

       // Select
       this.page = 1;
       this.numberOfEmailAccounts = this.emailaccountList.length;
       this.selectOptions = [10, 25, 50, 100, this.numberOfEmailAccounts];
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
     await this.emailaccountService.getEmailAccounts().then((data: Response<EmailAccountList[]>) => {
       this.response = data;
       this.emailaccountList = this.response.Model;
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
