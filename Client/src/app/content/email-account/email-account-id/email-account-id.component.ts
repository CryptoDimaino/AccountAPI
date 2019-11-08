import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { ActivatedRoute } from '@angular/router';
import { DatePipe } from '@angular/common';
import { PaginationInstance } from 'ngx-pagination';

import { Response } from '../../../Models/response';

import { EmailAccountService } from '../../../Services/email-account.service';

import { EmailAccountList, EmailAccountAdd, EmailAccountEdit, EmailAccount, EmailAccountAccounts } from '../../../Models/emailaccount';
import { AccountList } from 'src/app/Models/account';
import { AccountListComponent } from '../../account/account-list/account-list.component';

import { ModalService } from '../../../modal/modal.service';




@Component({
  selector: 'app-email-account-id',
  templateUrl: './email-account-id.component.html',
  styleUrls: ['./email-account-id.component.scss']
})
export class EmailAccountIdComponent implements OnInit {

  // Route Id
  private id: number;

  private Title: string;

  // Models
  private emailAccount: EmailAccount;
  private response: Response<EmailAccount>;
  private numberOfGames: number;
  private numberOfAccounts: number;

  // private games: PlatformGames[];
  // private accounts: PlatformAccounts[];

  private accounts: EmailAccountAccounts[];
  private account: AccountList;

  private gamesExist: boolean;
  private accountsExist: boolean;

  // Loaded
  private loaded: boolean;

  // Pipe Search
  private searchText: string;

  // Pagination
  private maxSize: number;
  private directionLinks: boolean;
  private autoHide: boolean;
  private responsive: boolean;

  private config: PaginationInstance = {
    id: 'custom',
    itemsPerPage: 25,
    currentPage: 1,
    totalItems: this.numberOfGames
  };

  // Select
  private numberToShow: number;
  private selectOptions: any = [];

  // Sort
  private key: string;
  private reverse: boolean;
  private caseInsensitive: boolean;

  constructor(private route: ActivatedRoute, private router: Router, private modalService: ModalService, private emailAccountService: EmailAccountService, private datePipe: DatePipe) { }

  async ngOnInit() {
    this.loaded = false;
    this.id = this.route.snapshot.params.id;

    this.Title = "Loading...";

    await this.loadResponse();

    if(this.response.DidError) {
      this.Title = "Email Account Does Not Exist.";
      this.loaded = false;
    }
    else {
      this.Title = this.emailAccount.Email;

      
      this.accounts = this.emailAccount.Accounts;

      // Sort
      this.key = 'Email';
      this.reverse = false;
      this.caseInsensitive = false;

      this.numberOfAccounts = this.emailAccount.Accounts.length;
      this.selectOptions = [10, 25, 50, 100, this.numberOfAccounts];
      this.numberToShow = 25;
      this.config.itemsPerPage = this.numberToShow;

      // Pagination
      this.maxSize = 7;
      this.directionLinks = false;
      this.autoHide = true;
      this.responsive = true;

      this.accountsExist = this.numberOfAccounts > 0;
      console.log(this.numberOfAccounts);
    }
  }

  onChange(itemsPerPageValue: number) {
    this.numberToShow = itemsPerPageValue;
    this.config.itemsPerPage = this.numberToShow;
  }

  sort(key: string) {
    this.key = key;
    this.reverse = !this.reverse;
  }

  async loadResponse() {
    await this.emailAccountService.getEmailAccount(this.id).then((data: Response<EmailAccount>) => {
      this.response = data;
      this.emailAccount = data.Model;
      this.loaded = true;
      console.log(data);
    });
  }

  openModal(id: string) {
    this.modalService.open(id);
  }

  closeModal(id: string) {
    this.modalService.close(id);
  }


  async DeleteEmailAccount() {
    this.emailAccountService.deleteEmailAccount(this.id).then((data: Response<EmailAccount>) => {
      if(data.DidError) {
        alert(data.Message);
      }
      else {
        this.router.navigate(['/emailaccounts']);
      }
    });
  }

}
