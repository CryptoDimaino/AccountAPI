import { Component, OnInit } from '@angular/core';
import { Router, ActivatedRoute } from '@angular/router';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { DatePipe } from '@angular/common';

import { AccountService } from '../../../Services/account.service';
import { EmailAccountService } from '../../../Services/email-account.service';
import { PlatformService } from '../../../Services/platform.service';
import { EventService } from '../../../Services/event.service';
import { CodeService } from '../../../Services/code.service';
import { GameService } from '../../../Services/game.service';


import { Response } from '../../../Models/response';
import { PlatformList, PlatformAdd, PlatformEdit, Platform, Platforms } from '../../../Models/platform';
import { AccountList, AccountAdd, AccountEdit, Account, AccountPlatform } from '../../../Models/account';
import { EmailAccountList, EmailAccountAdd, EmailAccountEdit, EmailAccount } from '../../../Models/emailaccount';
import { EventList, EventAdd, EventEdit, Event } from '../../../Models/event';
import { CodeList, CodeAdd, CodeEdit, Code } from '../../../Models/code';

import { Subscription } from 'rxjs';
import { distinctUntilChanged } from 'rxjs/operators';
import { debounceTime } from 'rxjs/operators';
import { GameList, Game } from 'src/app/Models/game';

@Component({
  selector: 'app-code-edit',
  templateUrl: './code-edit.component.html',
  styleUrls: ['./code-edit.component.scss']
})
export class CodeEditComponent implements OnInit {

  // Route Id
  private id: number;
  private loaded: boolean;

  private Title: string;

  private OnEvent: boolean;

  private response: Response<CodeEdit>
  private code: CodeEdit;
  private newCode: CodeEdit;


  private response1: Response<AccountList[]>
  private response2: Response<GameList[]>
  private response3: Response<PlatformList[]>


  private gameList: GameList[];
  private accountList: AccountList[];
  private platformList: PlatformList[];

  private newAccount: AccountEdit;
  private sortedAccountList: AccountList[] = [];

  private account: Account;
  private game: Game;

  private game1: GameList;


  // Form
  private submitted = false;
  private editModelForm: FormGroup;

  private subscriptions: Array<Subscription> = [];

  constructor(private route: ActivatedRoute, private router: Router, private formBuilder: FormBuilder, private accountService: AccountService, private gameService: GameService, private platformService: PlatformService, private codeService: CodeService, private datePipe: DatePipe) { }

  async ngOnInit() {
    this.loaded = false;
    this.id = this.route.snapshot.params.id;
    this.Title = "Editing...";

    this.editModelForm = this.formBuilder.group({
      Code: ['', Validators.required],
      Status: ['', Validators.required],
      GameId: ['', Validators.required],
      AccountId: ['',Validators.required]
    });

    await this.loadResponse();

    this.gameList.sort(this.GetSortOrder("Title"));

    if(this.response.DidError) {
      this.Title = "Code Does Not Exist.";
      this.loaded = false;
    }
    else {
      // Title of the page
      this.Title = this.code.CodeString;

      // Searches through he list of games
      this.gameList.forEach(game => {
        if(this.code.GameId == game.Id)
        {
          this.game1 = game;
          this.accountList.forEach(account => {
            if(game.Platform == account.Platform)
            {
              this.sortedAccountList.push(account);
            }
          });
        }
      });

      // Returns the game from the code's gameId
      await this.gameService.getGame(this.code.GameId).then((data: Response<Game>) => {
        this.game = data.Model;
      });

      // Set all the values if they exist
      this.editModelForm.controls["Code"].setValue(this.code.CodeString);
      this.editModelForm.controls["Status"].setValue(this.code.UsedStatus);
      this.editModelForm.controls["GameId"].setValue(this.code.GameId);
      this.editModelForm.controls["AccountId"].setValue(this.code.AccountId);

      // Check to see if code contains an account ID
      if(this.code.AccountId == null)
      {
        this.editModelForm.controls["AccountId"].disable();
      }

      // Checks for value changes and if there is a change it set the other form controls to disabled.
      this.subscriptions.push(this.editModelForm.controls["Status"].valueChanges.subscribe((data: boolean) => {
        if(data === true) {
            this.editModelForm.controls["AccountId"].enable();
        }
        else {
          this.editModelForm.controls["AccountId"].disable();
          this.editModelForm.controls["AccountId"].setValue(null);
        }
      }));

      // Check for value changes to GameId field.
      // Sets the sorted accounts list to be empty
      // Look for current selected GameId and assig it to the game1 variable
      // Check for all of the accounts in accountlist that match the same platform as the game.
      this.subscriptions.push(this.editModelForm.controls["GameId"].valueChanges.subscribe((data) => {
        this.sortedAccountList = [];

        this.gameList.forEach(game => {
          if(game.Id == data)
          {
            this.game1 = game;
          }
        });
        this.accountList.forEach(account => {
          if(this.game1.Platform == account.Platform)
          {
            this.sortedAccountList.push(account);
          }
        });
      }));


    // Show current game. Allow to pick every game. Done

    // Load account based on the game picked for the platform. Done


    }
  }



  // Loads in all data needed to edit the account
  async loadResponse() {

    // Loads in the code information
    await this.codeService.getCode(this.id).then((data: Response<CodeEdit>) => {
      this.response = data;
      this.code = data.Model;
      console.log(this.code);

    });

    // Loads in the account information
    await this.accountService.getAccounts().then((data: Response<AccountList[]>) => {
      this.response1 = data;
      this.accountList = data.Model;
      // console.log(this.accountList);
      this.loaded = true;
    });

    // Loads in the game information
    await this.gameService.getGames().then((data: Response<GameList[]>) => {
      this.response2 = data;
      this.gameList = data.Model;
      // console.log(this.gameList);
    });

    // Loads in the platform information
    await this.platformService.getPlatformsWithId().then((data: Response<PlatformList[]>) => {
      this.response3 = data;
      this.platformList = data.Model;
      // console.log(this.platformList);
    });
  }

  get f() { return this.editModelForm.controls; }


  async onEdit() {
    this.submitted = true;

    if(this.editModelForm.invalid) {
      return;
    }

    if(this.editModelForm.getRawValue().Status == true)
    {
      await this.accountService.getAccount(this.editModelForm.getRawValue().AccountId).then((data: Response<Account>) => {
        this.account = data.Model;
      });

      this.newCode = {
        CodeId: this.id,
        CodeString: this.editModelForm.getRawValue().Code,
        UsedStatus: this.editModelForm.getRawValue().Status,
        GameId: this.editModelForm.getRawValue().GameId,
        EmailAccountId: this.account.EmailAccountId,
        PlatformId: this.account.PlatformId,
        AccountId: this.editModelForm.getRawValue().AccountId
      };
    }
    else {
      let plat = 0;
      this.platformList.forEach(platform => {
        if(platform.Platform == this.game.Platform) {
          plat = platform.Id;
        }
      });

      this.newCode = {
        CodeId: this.id,
        CodeString: this.editModelForm.getRawValue().Code,
        UsedStatus: this.editModelForm.getRawValue().Status,
        GameId: this.editModelForm.getRawValue().GameId,
        PlatformId: plat,
        EmailAccountId: null,
        AccountId: null
      };
    }






    console.log(this.newCode);

    await this.codeService.editCode(this.newCode).then((data: Response<Code>) => {
      if(data.DidError) {
        alert(data.Message);
      }
      else {
        this.router.navigate(['/codes/' + this.id]);
      }
    });
  }

  public ngOnDestroy(): void {
    this.subscriptions.forEach((subscription: Subscription) => {
        subscription.unsubscribe();
    });
  }

  GetSortOrder(prop: string) {
    return function(a, b) {
        if (a[prop] > b[prop]) {
            return 1;
        } else if (a[prop] < b[prop]) {
            return -1;
        }
        return 0;
    }
  }
}
