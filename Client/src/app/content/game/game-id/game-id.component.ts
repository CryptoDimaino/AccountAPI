import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';
import { ActivatedRoute } from '@angular/router';
import { DatePipe } from '@angular/common';
import { PaginationInstance } from 'ngx-pagination';

import { GameService } from '../../../Services/game.service';

import { Game, GameAccount, GameList, GameAdd, GameEdit } from '../../../Models/game';
import { Response } from '../../../Models/response';

@Component({
  selector: 'app-game-id',
  templateUrl: './game-id.component.html',
  styleUrls: ['./game-id.component.scss']
})
export class GameIdComponent implements OnInit {

  // Route Id
  private id: number;

  private Title: string;

  // Models
  private game: Game;
  private response: Response<Game>;
  private numberOfAccounts: number;
  private numberOfCodes: number = 0;
  private codes: GameAccount[] = new Array();
  private accounts: GameAccount[] = new Array();
  private totalNumber: number;

  // HtmlChecks
  private AccountsExist: boolean;
  private AccountIdsExist: boolean;
  private CodesExist: boolean;

  // Loaded
  private loaded: boolean;

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
    itemsPerPage: 10,
    currentPage: 1
  };

  // Select
  private numberToShow: number = 25;
  private selectOptions: any = [];

  // Sort
  private key: string;
  private reverse: boolean;
  private caseInsensitive: boolean;

  constructor(private route: ActivatedRoute, private router: Router, private gameService: GameService, private datePipe: DatePipe) { }

  async ngOnInit() {
    this.loaded = false;
    this.id = this.route.snapshot.params.id;

    this.Title = "Waiting...";

    await this.loadResponse();

    if(this.response.DidError)
    {
      this.Title = "Game Does Not Exist.";
      this.loaded = false;
    }
    else
    {
      this.Title = this.game.Title;

      // Display Date
      this.game.ReleaseDate = this.datePipe.transform(this.game.ReleaseDate, "mediumDate");

      // Sort
      this.key = 'Username';
      this.reverse = false;
      this.caseInsensitive = false;

      this.game.Accounts.forEach(account => {
        if(account.Id)
        {
          this.AccountIdsExist = true;
        }
        if(!account.Id)
        {
          this.numberOfCodes++;
          this.CodesExist = true;
        }
      });

      // Select
      this.page = 1;
      this.totalNumber = this.game.Accounts.length;
      this.numberOfAccounts = this.totalNumber - this.numberOfCodes;
      this.selectOptions = [10, 25, 50, 100, this.numberOfAccounts];
      this.numberToShow = 10;
      this.config.itemsPerPage = this.numberToShow;

      // Pagination
      this.maxSize = 7;
      this.directionLinks = false;
      this.autoHide = true;
      this.responsive = true;

      this.AccountsExist = this.numberOfAccounts > 0;

      let count = 0;

      this.game.Accounts.forEach(account => {
        if(account.Id != null)
        {
          let gameAccount: GameAccount = {
            CodeId: account.CodeId,
            Id: account.Id,
            Code: account.Code,
            Username: account.Username,
            Password: account.Password,
            Email: account.Email,
            EmailPassword: account.EmailPassword
          };
          this.accounts.push(gameAccount);
        }
        else
        {
          let gameAccount: GameAccount = {
            CodeId: account.CodeId,
            Id: account.Id,
            Code: account.Code,
            Username: account.Username,
            Password: account.Password,
            Email: account.Email,
            EmailPassword: account.EmailPassword
          };
          this.codes.push(gameAccount);
        }
        count++;
      });
    }
  }

  // Reads in data from API
  async loadResponse() {
    await this.gameService.getGame(this.id).then((data: Response<Game>) => {
      this.response = data;
      this.game = data.Model;
      this.loaded = true;
    }).catch(error => {
      console.log(error);
    });
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

  private DeleteGame()
  {
    this.gameService.deleteGame(this.id).then(data => {
      if(data.DidError)
      {
        alert(data.Message);

      }
      else
      {
      this.router.navigate(['/games']);

      }
    }).catch(error => {
      // this.router.navigate(['/games']);
    })
  }
}
