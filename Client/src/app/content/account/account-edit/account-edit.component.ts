import { Component, OnInit } from '@angular/core';
import { Router, ActivatedRoute } from '@angular/router';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { DatePipe } from '@angular/common';

import { AccountService } from '../../../Services/account.service';
import { EmailAccountService } from '../../../Services/email-account.service';
import { PlatformService } from '../../../Services/platform.service';

import { EventService } from '../../../Services/event.service';

import { Response } from '../../../Models/response';
import { PlatformList, PlatformAdd, PlatformEdit, Platform, Platforms } from '../../../Models/platform';
import { AccountList, AccountAdd, AccountEdit, Account, AccountPlatform } from '../../../Models/account';
import { EmailAccountList, EmailAccountAdd, EmailAccountEdit, EmailAccount } from '../../../Models/emailaccount';
import { EventList, EventAdd, EventEdit, Event } from '../../../Models/event';

import { CodeList, CodeAdd, CodeEdit, Code } from '../../../Models/code';


import { Subscription } from 'rxjs';
import { distinctUntilChanged } from 'rxjs/operators';
import { debounceTime } from 'rxjs/operators';


@Component({
  selector: 'app-account-edit',
  templateUrl: './account-edit.component.html',
  styleUrls: ['./account-edit.component.scss']
})
export class AccountEditComponent implements OnInit {

  // Route Id
  private id: number;
  private loaded: boolean;

  private Title: string;

  private OnEvent: boolean;

  // private response

  private response: Response<AccountEdit>
  private account: AccountEdit;
  private newAccount: AccountEdit;
  private events: EventList[];

  // Form
  private submitted = false;
  private editModelForm: FormGroup;

  private subscriptions: Array<Subscription> = [];


  constructor(private route: ActivatedRoute, private router: Router, private formBuilder: FormBuilder, private accountService: AccountService, private eventService: EventService, private datePipe: DatePipe) { }

  async ngOnInit() {
    this.loaded = false;
    this.id = this.route.snapshot.params.id;
    this.Title = "Editing...";

    this.OnEvent = false;

    this.editModelForm = this.formBuilder.group({
      Username: ['', [Validators.required, Validators.minLength(3)]],
      Password: ['', [Validators.required, Validators.minLength(3)]],
      Status: ['', Validators.required],
      EventId: ['',Validators.required]
    });

    await this.loadResponse();

    // Checks to see if there was an error trying to load the API
    if(this.response.DidError) {
      // Title
      this.Title = "Error";
    }
    else {
      // Set the title
      this.Title = this.account.Username;

      // Check if there is an account Id
      if(this.account.EventId == null) {
        this.account.Status = false;
      }
      else {
        this.account.Status = true;
      }

      // If the account's status is true and there is no event id
      if(this.account.Status === true && this.account.EventId != null) {
        // Set Title that the account cannot be changed while on an event.
        this.OnEvent = true;

        // Disable Input
        this.editModelForm.controls["Username"].disable();
        this.editModelForm.controls["Password"].disable();
        this.editModelForm.controls["EventId"].disable();
      }
      else {
        // Disable EventId
        this.editModelForm.controls["EventId"].disable();
      }

      // Set all the values if they exist
      this.editModelForm.controls["Username"].setValue(this.account.Username);
      this.editModelForm.controls["Password"].setValue(this.account.Password);
      this.editModelForm.controls["Status"].setValue(this.account.Status);
      this.editModelForm.controls["EventId"].setValue(this.account.EventId);

      this.subscriptions.push(this.editModelForm.controls["Status"].valueChanges.subscribe((data: boolean) => {
        console.log("LOL" + data);
        if(data === true) {
            this.editModelForm.controls["EventId"].enable();
            this.editModelForm.controls["Username"].disable();
          this.editModelForm.controls["Password"].disable();
        }
        else {
          this.editModelForm.controls["EventId"].disable();
          this.editModelForm.controls["EventId"].setValue(null);
          this.editModelForm.controls["Username"].enable();
          this.editModelForm.controls["Password"].enable();
        }
      }));

      this.subscriptions.push(this.editModelForm.controls["EventId"].valueChanges.subscribe((data: boolean) => {
        console.log("EventId" + data);
      }));
    }
  }


  // Loads in all data needed to edit the account
  async loadResponse() {
    // Loads in the account information
    await this.accountService.getAccount(this.id).then((data: Response<AccountEdit>) => {
      this.response = data;
      this.account = data.Model;
      this.loaded = true;
    });

    // Loads in a list of events
    await this.eventService.getEvents().then((data: Response<EventList[]>) => {
      this.events = data.Model;
    })
  }

  get f() { return this.editModelForm.controls; }


  ngAfterViewInit() {

  }

  async onEdit() {
    // this.submitted = true;

    // if(this.editModelForm.invalid) {
    //   return;
    // }

    this.newAccount = {
      AccountId: this.id,
      Username: this.editModelForm.getRawValue().Username,
      Password: this.editModelForm.getRawValue().Password,
      PlatformId: this.account.PlatformId,
      EmailAccountId: this.account.EmailAccountId,
      Status: this.editModelForm.getRawValue().Status,
      EventId: this.editModelForm.getRawValue().EventId
    };

    // console.log(this.newAccount);

    await this.accountService.editAccount(this.newAccount).then((data: Response<Account>) => {
      if(data.DidError) {
        alert(data.Message);
      }
      else {
        console.log(data);
        this.router.navigate(['/accounts/' + this.id]);
      }
    });
  }

  public ngOnDestroy(): void {
    this.subscriptions.forEach((subscription: Subscription) => {
        subscription.unsubscribe();
    });
  }
}
