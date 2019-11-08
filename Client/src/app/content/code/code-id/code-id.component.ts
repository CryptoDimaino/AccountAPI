import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';
import { ActivatedRoute } from '@angular/router';
import { DatePipe } from '@angular/common';
import { PaginationInstance } from 'ngx-pagination';

import { CodeService } from '../../../Services/code.service';
import { AccountService } from '../../../Services/account.service';

import { Response } from '../../../Models/response';

import { CodeList, CodeAdd, CodeEdit, Code } from '../../../Models/code';
import { AccountList, AccountAdd, AccountPlatform, Account } from '../../../Models/account';



import { ModalService } from '../../../modal/modal.service';


@Component({
  selector: 'app-code-id',
  templateUrl: './code-id.component.html',
  styleUrls: ['./code-id.component.scss']
})
export class CodeIdComponent implements OnInit {

  // Route Id
  private id: number;

  // Title
  private Title: string;

  // Models
  private code: Code;
  private account: Account;
  private response1: Response<Account>;
  private response: Response<Code>;

  // Loaded
  private loaded: boolean;

  private accountExists = false;

  private CodeAccountHasEvent = false;



  private bodyText: string;
  private accountHasEvent: boolean;
  private deleteErrorMessage: string;

  private codeHasAnAccount: boolean;



  constructor(private route: ActivatedRoute, private router: Router, private datePipe: DatePipe, private modalService: ModalService, private codeService: CodeService, private accountService: AccountService) { }

  async ngOnInit() {
    this.loaded = false;
    this.id = this.route.snapshot.params.id;

    this.Title = "Waiting...";

    this.bodyText = 'This text can be updated in modal 1';


    await this.loadResponse();

    if(this.response.DidError) {
      this.Title = "Code Does Not Exist.";
      this.loaded = false;
    }
    else {
      this.Title = this.code.CodeString;

      if(this.code.Account != null) {
        this.accountExists = true;
        await this.loadAccountResponse();

        if(this.account.EventId != null) {
          this.CodeAccountHasEvent = true;
        }
      }
    }
  }

  // Reads in data from API
  async loadResponse() {
    await this.codeService.getCode(this.id).then((data: Response<Code>) => {
      this.response = data;
      this.code = data.Model;
      this.loaded = true;
      console.log(this.code);
    }).catch((error: string) => {
      console.log(error);
    });


  }


  // Reads in data from API
  async loadAccountResponse() {
    await this.accountService.getAccount(this.code.AccountId).then((data1: Response<Account>) => {
      this.response1 = data1;
      this.account = data1.Model;
      console.log(data1);
    });
  }



  openModal(id: string) {
    this.modalService.open(id);
  }

  closeModal(id: string) {
    this.modalService.close(id);
  }

  private DeleteCode() {
    this.codeService.deleteCode(this.id).then(data => {
      if(data.DidError) {
        alert(data.Message);
      }
      else {
        this.router.navigate(['/codes']);
      }
    })
  }
}
