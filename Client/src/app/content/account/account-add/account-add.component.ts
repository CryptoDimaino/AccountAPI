import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { debounceTime } from 'rxjs/operators';

import { Response } from '../../../Models/response';

import { AccountService } from '../../../Services/account.service';
import { PlatformService } from '../../../Services/platform.service';
import { EmailAccountService } from '../../../Services/email-account.service';

import { AccountList, AccountAdd, AccountEdit, Account, AccountPlatform } from '../../../Models/account';
import { PlatformList, PlatformAdd, PlatformEdit, Platform, Platforms } from '../../../Models/platform';
import { EmailAccountList, EmailAccountAdd, EmailAccountEdit, EmailAccount } from '../../../Models/emailaccount';


import { Subscription } from 'rxjs';
import { distinctUntilChanged } from 'rxjs/operators';


@Component({
  selector: 'app-account-add',
  templateUrl: './account-add.component.html',
  styleUrls: ['./account-add.component.scss']
})
export class AccountAddComponent implements OnInit {

  // Loaded
  private loaded = false;

  // Models
  private platformResponse: Response<Platforms[]>;
  private platforms: Platforms[];

  private emailaccountResponse: Response<EmailAccountList[]>;
  private emailaccounts: EmailAccountList[];

  private accountplatformResponse: Response<AccountPlatform[]>;
  private accountplatforms: AccountPlatform[];

  private newAccount: AccountAdd;

  private subscriptions: Array<Subscription> = [];


  private checkCheckbox: boolean;

  // Form
  submitted = false;
  addAccountForm: FormGroup;

  constructor(private router: Router, private formBuilder: FormBuilder, private accountService: AccountService, private platformService: PlatformService, private emailaccountService: EmailAccountService) { }

  async ngOnInit() {
    this.checkCheckbox = true;
    // Check if API was loaded
    this.loaded = false;

    this.newAccount = {
      Username: "",
      Password: "",
      PlatformId: null,
      EmailAccountId: null
    }

    // Create initial form
    this.addAccountForm = this.formBuilder.group({
      CheckBox: [true],
      Username: ['', [Validators.required]],
      Password: ['', Validators.required],
      EmailAccountId: ['', Validators.required],
      PlatformId: ['', Validators.required],

    });

    this.addAccountForm.controls['Username'].disable();
    this.addAccountForm.controls['Password'].disable();


    // Loads response and all platform list
    await this.loadResources();

    if(this.platformResponse.DidError || this.emailaccountResponse.DidError || this.accountplatformResponse.DidError) {
      console.log("Did not load");
    }
    else {
      this.loaded = true;
    }
  }

  // Reads in data from API
  async loadResources() {
    await this.platformService.getPlatformsWithId().then((data: Response<Platforms[]>) => {
      this.platformResponse = data;
      this.platforms = data.Model;
      console.log(data.Model);
    });

    await this.emailaccountService.getEmailAccounts().then((data: Response<EmailAccountList[]>) => {
      this.emailaccountResponse = data;
      this.emailaccounts = data.Model;

      console.log(data.Model);
    });

    await this.accountService.getEmailAccountAndPlatforms().then((data: Response<AccountPlatform[]>) => {
      this.accountplatformResponse = data;
      this.accountplatforms = data.Model;
      console.log(data.Model);
    });
  }

  // getter for easy access to form fields
  get f() { return this.addAccountForm.controls; }



  ngAfterViewInit() {
    // Check for value changes
    this.subscriptions.push(this.addAccountForm.valueChanges.pipe(debounceTime(100), distinctUntilChanged()).subscribe((data: any) => {

      // Check if the checkbox is enabled
      if(data.CheckBox) {
        // Disable the Username and Password field
        this.addAccountForm.controls['Username'].disable({ emitEvent: false });
        this.addAccountForm.controls['Password'].disable({ emitEvent: false });

        this.checkCheckbox = true;

        // Check if EmailAccountId and PlatformId as selected
          if((data.EmailAccountId != "" && data.PlatformId != "")) {
            if(this.PlatformName(data, ["Steam", "Steam VR", "Standalone", "Lego Mini Online"]) && data.EmailAccountId != "") {
              if(this.PlatformName(data, ["Steam"]) && this.EmailNameCompare(data, "demodepotna")) {
                this.addAccountForm.controls.Password.patchValue("D3p0t2020", { emitEvent: false });
              }
              else if(this.PlatformName(data, ["Steam"]) && this.EmailNameCompare(data, "demodepoteu")) {
                this.addAccountForm.controls.Password.patchValue("depot2000", { emitEvent: false });
              }
              else if(this.PlatformName(data, ["Steam"]) && this.EmailNameCompare(data, "demodepotds")) {
                this.addAccountForm.controls.Password.patchValue("Depot2oooDS", { emitEvent: false });
              }
              else if(this.PlatformName(data, ["Steam"]) && this.EmailNameCompare(data, "iemcapcom")) {
                this.addAccountForm.controls.Password.patchValue("IntelCapcom2019", { emitEvent: false });
              }
              else if(this.PlatformName(data, ["Steam"])) {
                this.addAccountForm.controls.Password.patchValue("depot2000", { emitEvent: false });
              }
              else if(this.PlatformName(data, ["Steam VR"]) && this.EmailNameCompare(data, "demodepotvr")) {
                this.addAccountForm.controls.Password.patchValue("Depot2ooo", { emitEvent: false });
              }
              else if(this.PlatformName(data, ["Steam VR"]) && this.EmailNameCompare(data, "demodepotds")) {
                this.addAccountForm.controls.Password.patchValue("Depot2oooDS", { emitEvent: false });
              }
              else if(this.PlatformName(data, ["Steam VR"])) {
                this.addAccountForm.controls.Password.patchValue("Depot2ooo", { emitEvent: false });
              }
              else if(this.PlatformName(data, ["Lego Mini Online"])) {
                this.addAccountForm.controls.Password.patchValue("D3p0t2014", { emitEvent: false });
              }
              else {
                this.addAccountForm.controls.Password.patchValue("depot2000", { emitEvent: false });
              }
              this.addAccountForm.controls.Username.patchValue(this.emailaccounts[data.EmailAccountId - 1].Email.substr(0, this.emailaccounts[data.EmailAccountId - 1].Email.indexOf('@')), { emitEvent: false });

              // Check of standalone games.
            }
            else if(this.PlatformName(data, ["Microsoft Store", "Oculus", "Origin", "Uplay", "Epic", "BattleNet", "Intel Appup", "Minecraft"]) && data.EmailAccountId != "") {
              if(this.PlatformName(data, ["Microsoft Store"]) && this.EmailNameCompare(data, "demodepotna")) {
                this.addAccountForm.controls.Password.patchValue("D3m0D3p0t", { emitEvent: false });
              }
              else if(this.PlatformName(data, ["Microsoft Store"]) && this.EmailNameCompare(data, "demodepotds")) {
                this.addAccountForm.controls.Password.patchValue("Depot2oooDS", { emitEvent: false });
              }
              else if(this.PlatformName(data, ["Microsoft Store"])) {
                this.addAccountForm.controls.Password.patchValue("D3m0D3p0t", { emitEvent: false });
              }
              else if(this.PlatformName(data, ["Oculus"]) && this.EmailNameCompare(data, "demodepotvr")) {
                this.addAccountForm.controls.Password.patchValue("depot2000", { emitEvent: false });
              }
              else if(this.PlatformName(data, ["Oculus"]) && this.EmailNameCompare(data, "demodepottvr")) {
                this.addAccountForm.controls.Password.patchValue("D3m0D3p0t", { emitEvent: false });
              }
              else if(this.PlatformName(data, ["Oculus"]) && this.EmailNameCompare(data, "demodepotds")) {
                this.addAccountForm.controls.Password.patchValue("Depot2oooDS", { emitEvent: false });
              }
              else if(this.PlatformName(data, ["Origin"])) {
                this.addAccountForm.controls.Password.patchValue("Depot2000", { emitEvent: false });
              }
              else if(this.PlatformName(data, ["Uplay"])) {
                this.addAccountForm.controls.Password.patchValue("depot2000", { emitEvent: false });
              }
              else if(this.PlatformName(data, ["Epic"])) {
                this.addAccountForm.controls.Password.patchValue("depot2000", { emitEvent: false });
              }
              else if(this.PlatformName(data, ["BattleNet"])) {
                this.addAccountForm.controls.Password.patchValue("D3p0t2020", { emitEvent: false });
              }
              else if(this.PlatformName(data, ["Intel Appup"])) {
                this.addAccountForm.controls.Password.patchValue("demodepot", { emitEvent: false });
              }
              else if(this.PlatformName(data, ["Minecraft"])) {
                this.addAccountForm.controls.Password.patchValue("depot2000", { emitEvent: false });
              }
              else {
                this.addAccountForm.controls.Password.patchValue("depot2000", { emitEvent: false });
              }
              this.addAccountForm.controls.Username.patchValue(this.emailaccounts[data.EmailAccountId - 1].Email, { emitEvent: false });
            }
          }
        }
        else {
          // Enable both fields if the checkbox if disabled
          this.addAccountForm.controls['Username'].enable({ emitEvent: false });
          this.addAccountForm.controls['Password'].enable({ emitEvent: false });

          this.checkCheckbox = false;
        }
    }));
  }

  // Compares the supplied form value email and compares both values
  EmailNameCompare(data: any, str: string) {
    var email1 = this.emailaccounts[data.EmailAccountId - 1].Email.toUpperCase();
    var email2 = str.toUpperCase();
    return email1.includes(email2);
  }

  // Compares the supplied form value platform and compares both values
  PlatformName(data: any, strList: string[]) {
    // Create a value to return
    var check = false;

    // Read in the current data for the platform name and make it uppercase
    var platform1 = this.platforms[data.PlatformId - 1].Platform.toUpperCase();

    // Loop through each of the platforms in the list provided and return true if it matches the currently selected data
    for(let platform = 0; platform < strList.length; platform++) {
      if(platform1 == strList[platform].toUpperCase()) {
        check = true;
        break;
      }
    }
    return check;
  }

  async AddAccount() {
    // Form was submitted
    this.submitted = true;

    this.addAccountForm.controls['Username'].enable({ emitEvent: false });
    this.addAccountForm.controls['Password'].enable({ emitEvent: false });

    // Check if form is valid
    if(this.addAccountForm.invalid) {
      return;
    }

    // Get form information
    this.newAccount = {
      Username: this.addAccountForm.getRawValue().Username,
      Password: this.addAccountForm.getRawValue().Password,
      PlatformId: this.addAccountForm.value.PlatformId,
      EmailAccountId: this.addAccountForm.value.EmailAccountId
    }

    await this.accountService.addAccount(this.newAccount).then(account => {
      if(account.DidError) {
        if(this.checkCheckbox) {
          this.addAccountForm.controls['Username'].disable({ emitEvent: false });
          this.addAccountForm.controls['Password'].disable({ emitEvent: false });
        }
        alert(account.Message);
      }
      else {
        this.router.navigate(['/accounts/' + account.Model.AccountId]);
      }
    });
  }

   public ngOnDestroy(): void {
    this.subscriptions.forEach((subscription: Subscription) => {
        subscription.unsubscribe();
    });

}
}
