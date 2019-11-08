import { Component, OnInit } from '@angular/core';
import { ActivatedRoute, Router } from '@angular/router';
import { DatePipe } from '@angular/common';
import { FormBuilder, FormGroup, Validators, FormControl } from '@angular/forms';

import { Response } from '../../../Models/response';

import { GameService } from '../../../Services/game.service';
import { PlatformService } from '../../../Services/platform.service';

import { PlatformList, PlatformAdd, PlatformEdit, Platform, Platforms } from '../../../Models/platform';
import { Game, GameAccount, GameList, GameAdd, GameEdit } from '../../../Models/game';




@Component({
  selector: 'app-game-edit',
  templateUrl: './game-edit.component.html',
  styleUrls: ['./game-edit.component.scss']
})
export class GameEditComponent implements OnInit {

  // Route Id
  private id: number;
  private loaded: boolean;

  private Title: string;

  // Models
  private response: Response<Game>;
  private game: Game;
  private gameEdit: GameEdit;
  private platformId: number;

  private submitted = false;
  private gameEditForm: FormGroup;
  // private default: id

  private platforms: Platforms[];


  constructor(private route: ActivatedRoute, private router: Router, private gameService: GameService, private datePipe: DatePipe, private formBuilder: FormBuilder, private platformService: PlatformService) { }

  async ngOnInit() {
    this.loaded = false;
    this.id = this.route.snapshot.params.id;
    this.Title = "Editing...";

    this.gameEditForm = this.formBuilder.group({
      Name: ['', [Validators.required, Validators.minLength(3)]],
      PlatformId: ['', Validators.required],
      URLToDocumentation: [''],
      ReleaseDate: ['']
    });


    await this.loadResponse();

    // Checks to see if there was an error trying to load the API
    if(this.response.DidError) {
      // Title
      this.Title = "Error";
    }
    else {

      var count = 0;
      this.platforms.forEach(platform => {
        if(platform.Platform == this.game.Platform)
        {
          this.platformId = platform.Id;
        }
        count++;
      });

      this.gameEditForm = this.formBuilder.group({
        Name: [this.game.Title, [Validators.required, Validators.minLength(3)]],
        PlatformId: [this.platformId, Validators.required],
        URLToDocumentation: [this.game.URLToDocumentation],
        ReleaseDate: [this.game.ReleaseDate]
      });


      this.game.ReleaseDate = this.datePipe.transform(this.game.ReleaseDate, "yyyy-MM-dd");
      this.Title = this.game.Title;

      this.gameEditForm.controls['Name'].setValue(this.game.Title, {onlySelf: true})
      this.gameEditForm.controls['PlatformId'].setValue(this.platformId, {onlySelf: true})
      this.gameEditForm.controls['URLToDocumentation'].setValue(this.game.URLToDocumentation, {onlySelf: true})
      this.gameEditForm.controls['ReleaseDate'].setValue(this.game.ReleaseDate, {onlySelf: true})
    }
  }

  async loadResponse() {
    await this.gameService.getGame(this.id).then((data: Response<Game>) => {
      this.response = data;
      this.game = data.Model;
      this.loaded = true;
    });

    await this.platformService.getPlatformsWithId().then((data: Response<Platforms[]>) => {
      this.platforms = data.Model;
    });
  }

  get f() { return this.gameEditForm.controls; }

  onEditGame() {
    this.submitted = true;

    if(this.gameEditForm.invalid) {
      console.log("fail");
      console.log(this.gameEdit);
      return;
    }

    this.gameEdit = {
      GameId: this.id,
      Name: this.gameEditForm.value.Name,
      PlatformId: this.gameEditForm.value.PlatformId,
      ReleaseDate: this.gameEditForm.value.ReleaseDate,
      URLToDocumentation: this.gameEditForm.value.URLToDocumentation
    };
    console.log(this.gameEdit);

    this.gameService.getGameEdit(this.gameEdit).then(obj => {
      if(obj.DidError)
      {
        alert(obj.Message);
      }
      else
      {
        this.router.navigate(['/games/' + this.id]);
      }
    })
  }
}
