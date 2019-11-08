import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { debounceTime } from 'rxjs/operators';
import { Subscription } from 'rxjs';


import { Response } from '../../../Models/response';

import { CodeService } from '../../../Services/code.service';
import { PlatformService } from '../../../Services/platform.service';
import { AccountService } from '../../../Services/account.service';
import { GameService } from '../../../Services/game.service';

import { PlatformList, PlatformAdd, PlatformEdit, Platform, Platforms } from '../../../Models/platform';
import { CodeList, CodeAdd, CodeEdit, Code } from '../../../Models/code';
import { AccountList, AccountAdd, AccountPlatform, Account } from '../../../Models/account';
import { Game, GameAccount, GameList, GameAdd, GameEdit } from '../../../Models/game';
import { ThrowStmt } from '@angular/compiler';

@Component({
  selector: 'app-code-add',
  templateUrl: './code-add.component.html',
  styleUrls: ['./code-add.component.scss']
})
export class CodeAddComponent implements OnInit {

  // Loaded
  private loaded = false;

  private platformResponse: Response<Platforms[]>;
  private platforms: Platforms[];

  private gameResponse: Response<GameList[]>;
  private games: GameList[];

  private accountResponse: Response<AccountList[]>;
  private accounts: AccountList[];

  private sortedAccountList: AccountList[] = [];

  private newCode: CodeAdd;

  private game: GameList;


  // Form
  private submitted = false;
  private addModelForm: FormGroup;


  private account: Account;



  private subscriptions: Array<Subscription> = [];



  constructor(private router: Router, private formBuilder: FormBuilder, private accountService: AccountService, private platformService: PlatformService, private codeService: CodeService, private gameService: GameService) { }

  async ngOnInit() {

    this.loaded = false;

    // Create initial form
    this.addModelForm = this.formBuilder.group({
      CodeString: ['', Validators.required],
      Status: ['', Validators.required],
      AccountId: ['', Validators.required],
      GameId: ['', Validators.required],
    });

    // Loads response and all platform list
    await this.loadResources();

    if(this.platformResponse.DidError || this.gameResponse.DidError) {
      console.log("Error loading resources.");
    }
    else {
      this.loaded = true;

      // Checks for value changes and if there is a change it set the other form controls to disabled.
      this.subscriptions.push(this.addModelForm.controls["Status"].valueChanges.subscribe((data: boolean) => {
        if(data === true) {
            this.addModelForm.controls["AccountId"].enable();
        }
        else {
          this.addModelForm.controls["AccountId"].disable();
          this.addModelForm.controls["AccountId"].setValue(null);
        }
      }));


      this.subscriptions.push(this.addModelForm.controls["GameId"].valueChanges.subscribe((data) => {
        this.sortedAccountList = [];
        
        this.games.forEach(game => {
          if(game.Id == data)
          {
            this.game = game;
          }
        });
        this.accounts.forEach(account => {
          if(this.game.Platform == account.Platform)
          {
            this.sortedAccountList.push(account);
          }
        });
      }));
    }
  }

  // Reads in data from API
  async loadResources() {
    await this.platformService.getPlatformsWithId().then((data: Response<Platforms[]>) => {
      this.platformResponse = data;
      this.platforms = data.Model;
    });

    await this.gameService.getGames().then((data: Response<GameList[]>) => {
      this.gameResponse = data;
      this.games = data.Model;
    });

    await this.accountService.getAccounts().then((data: Response<AccountList[]>) => {
      this.accountResponse = data;
      this.accounts = data.Model;
    });

    // Loads in the platform information
    await this.platformService.getPlatformsWithId().then((data: Response<PlatformList[]>) => {
      this.platformResponse = data;
      this.platforms = data.Model;
      // console.log(this.platformList);
    });
  }

  // getter for easy access to form fields
  get f() { return this.addModelForm.controls; }

  async AddCode() {
    this.submitted = true;

    if(this.addModelForm.invalid) {
      return;
    }

    if(this.addModelForm.getRawValue().Status == true) {
      await this.accountService.getAccount(this.addModelForm.getRawValue().AccountId).then((data: Response<Account>) => {
        this.account = data.Model;
      });

      this.newCode = {
        CodeString: this.addModelForm.getRawValue().CodeString,
        UsedStatus: this.addModelForm.getRawValue().Status,
        GameId: this.addModelForm.getRawValue().GameId,
        EmailAccountId: this.account.EmailAccountId,
        PlatformId: this.account.PlatformId
      };
    }
    else {
      let plat = 0;
      this.platforms.forEach(platform => {
        if(platform.Platform == this.game.Platform) {
          plat = platform.Id;
        }
      });

      this.newCode = {
        CodeString: this.addModelForm.getRawValue().CodeString,
        UsedStatus: this.addModelForm.getRawValue().Status,
        GameId: this.addModelForm.getRawValue().GameId,
        PlatformId: plat,
        EmailAccountId: null,
      };
    }

    console.log(this.newCode);

    this.codeService.addCode(this.newCode).then((data: Response<Code>) => {
      if(data.DidError) {
        alert(data.Message);
      }
      else {
        this.router.navigate(['/codes/' + data.Model.CodeId]);
      }
    });
  }

  public ngOnDestroy(): void {
    this.subscriptions.forEach((subscription: Subscription) => {
        subscription.unsubscribe();
    });
  }

}


/*
Toggle - Account needed or only game? Set bool to true or fall based on this
Toggle - Autofill
Select Game drop down search
Select platform drop down search will be based off of game if only 1 opion gray out
Select account drop down search will be based off of plat form picked that do not currently have a game but an account exists.
TODO: Accounts sort based on account name, microsft show na and ds have a click to load all the other names?


New API Route Games[] - GameId, GameName, PlatformId

Platforms[]

New API ROUTE Accounts[] - PlatformId, EmailAccountId, AccountId, Name
*/
