import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { debounceTime } from 'rxjs/operators';

import { Response } from '../../../Models/response';

import { CodeService } from '../../../Services/code.service';
import { PlatformService } from '../../../Services/platform.service';
import { AccountService } from '../../../Services/account.service';
import { GameService } from '../../../Services/game.service';

import { PlatformList, PlatformAdd, PlatformEdit, Platform, Platforms } from '../../../Models/platform';
import { CodeList, CodeAdd, CodeEdit, Code } from '../../../Models/code';
import { AccountList, AccountAdd, AccountPlatform } from '../../../Models/account';
import { Game, GameAccount, GameList, GameAdd, GameEdit } from '../../../Models/game';

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

  // Form
  private submitted = false;
  private addModelForm: FormGroup

  // Check for checkbox
  private checkCheckbox: boolean;


  constructor(private router: Router, private formBuilder: FormBuilder, private accountService: AccountService, private platformService: PlatformService, private codeService: CodeService, private gameService: GameService) { }

  async ngOnInit() {
    this.checkCheckbox = true;

    this.loaded = false;

    // Create initial form
    this.addModelForm = this.formBuilder.group({
      CheckBox: [false],
      CodeString: ['', Validators.required],
      UsedStatus: [''],
      EmailAccountId: [''],
      PlatformId: [''],
      GameId: ['', Validators.required],
    });

    // Loads response and all platform list
    await this.loadResources();
  }

  // Reads in data from API
  async loadResources() {
    await this.platformService.getPlatformsWithId().then((data: Response<Platforms[]>) => {
      this.platformResponse = data;
      this.platforms = data.Model;
      console.log(data.Model);
    });

    await this.gameService.getGames().then((data: Response<GameList[]>) => {
      this.gameResponse = data;
      this.games = data.Model;
      console.log(data.Model);
    });

    // await this.emailaccountService.getEmailAccounts().then((data: Response<EmailAccountList[]>) => {
    //   this.emailaccountResponse = data;
    //   this.emailaccounts = data.Model;
    //   this.loaded = true;
    //   console.log(data.Model);
    // });

    // await this.accountService.getEmailAccountAndPlatforms().then((data: Response<AccountPlatform[]>) => {
    //   this.accountplatformResponse = data;
    //   this.accountplatforms = data.Model;
    //   console.log(data.Model);
    // });
  }

  // getter for easy access to form fields
  get f() { return this.addModelForm.controls; }
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
