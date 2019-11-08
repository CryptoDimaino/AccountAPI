import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';
import { ActivatedRoute } from '@angular/router';
import { DatePipe } from '@angular/common';
import { PaginationInstance } from 'ngx-pagination';

import { AccountService } from '../../../Services/account.service';
import { CodeService } from '../../../Services/code.service';

import { CodeList, CodeAdd, CodeEdit, Code } from '../../../Models/code';
import { AccountList, AccountAdd, AccountEdit, Account, AccountCodes, AccountPlatform } from '../../../Models/account';
import { Response } from '../../../Models/response';

import { ModalService } from '../../../modal/modal.service';

@Component({
  selector: 'app-account-id',
  templateUrl: './account-id.component.html',
  styleUrls: ['./account-id.component.scss']
})
export class AccountIdComponent implements OnInit {

  // Route Id
  private id: number;

  // Title
  private Title: string;

  // Models
  private account: Account;
  private response: Response<Account>;
  private numberOfCodes: number;
  private codes: AccountCodes[];

  // Check for model list
  private codesExist: boolean;

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
    totalItems: this.numberOfCodes
  };

  // Select
  private numberToShow: number;
  private selectOptions: any = [];

  // Sort
  private key: string;
  private reverse: boolean;
  private caseInsensitive: boolean;


  bodyText: string;

  private accountHasEvent: boolean;

  private deleteErrorMessage: string;


  constructor(private route: ActivatedRoute, private router: Router, private accountService: AccountService, private datePipe: DatePipe, private modalService: ModalService) { }

  async ngOnInit() {
    this.loaded = false;
    this.id = this.route.snapshot.params.id;

    this.Title = "Waiting...";

    this.accountHasEvent = false;



    this.bodyText = 'This text can be updated in modal 1';



    await this.loadResponse();

    if(this.response.DidError) {
      this.Title = "Account Does Not Exist.";
      this.loaded = false;
    }
    else {

      if(this.account.EventId != null)
      {
        this.accountHasEvent = true;
      }

      this.Title = this.account.Username;

      // Sort
      this.key = 'Username';
      this.reverse = false;
      this.caseInsensitive = false;

      // Select
      this.numberOfCodes = this.account.Codes.length;
      this.selectOptions = [10, 25, 50, 100, this.numberOfCodes];
      this.numberToShow = 10;
      this.config.itemsPerPage = this.numberToShow;

      // Pagination
      this.maxSize = 7;
      this.directionLinks = false;
      this.autoHide = true;
      this.responsive = true;

      this.codesExist = this.numberOfCodes > 0;

      console.log(this.codes);
    }
  }


   // Reads in data from API
   async loadResponse() {
    await this.accountService.getAccount(this.id).then((data: Response<Account>) => {
      this.response = data;
      this.account = data.Model;
      this.codes = data.Model.Codes;
      this.loaded = true;
      console.log(this.account);
    }).catch(error => {
      console.log(error);
    });
  }

  // Reads in select number
  onChange(itemsPerPageValue: number) {
    this.numberToShow = itemsPerPageValue;
    this.config.itemsPerPage = this.numberToShow;
  }


  openModal(id: string) {
    this.modalService.open(id);
}

closeModal(id: string) {
    this.modalService.close(id);
}






  // Sorts columns
  sort(key: string) {
    this.key = key;
    this.reverse = !this.reverse;
  }

  private DeleteAccount() {
    this.accountService.deleteAccount(this.id).then(data => {
      if(data.DidError) {
        // alert(data.Message);
        this.deleteErrorMessage = data.Message;
        this.openModal("delete-model-button");
      }
      else {
        this.router.navigate(['/accounts']);
      }
    }).catch(error => {
      console.log(error);
    });
  }
}
