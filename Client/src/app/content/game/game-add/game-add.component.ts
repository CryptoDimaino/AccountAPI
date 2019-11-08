import { Component, OnInit, EventEmitter, Input, Output } from '@angular/core';
import { Router } from '@angular/router';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';

import { PlatformService } from '../../../Services/platform.service';
import { GameService } from '../../../Services/game.service';

import { Response } from '../../../Models/response';
import { PlatformList, PlatformAdd, PlatformEdit, Platform, Platforms } from '../../../Models/platform';
import { GameList, GameAdd,  GameEdit, Game } from '../../../Models/game';



@Component({
  selector: 'app-game-add',
  templateUrl: './game-add.component.html',
  styleUrls: ['./game-add.component.scss']
})
export class GameAddComponent implements OnInit {

  // Loaded
  private loaded = false;

  // Models
  private response: Response<Platforms[]>;
  private platforms: Platforms[];
  private newGame: GameAdd;

  // Form
  submitted = false;
  addGameForm: FormGroup;

  constructor(private router: Router, private formBuilder: FormBuilder, private gameService:GameService, private platformService: PlatformService) { }

  async ngOnInit() {
    // Check if API was loaded
    this.loaded = false;

    // Create initial form
    this.addGameForm = this.formBuilder.group({
      Name: ['', [Validators.required, Validators.minLength(3)]],
      PlatformId: ['', Validators.required]
    });

    // Loads response and all platform list
    await this.loadResources();
  }

  // Reads in data from API
  async loadResources() {
    await this.platformService.getPlatformsWithId().then((data: Response<Platforms[]>) => {
      this.response = data;
      this.platforms = data.Model;
      this.loaded = true;
    });
  }

  // getter for easy access to form fields
  get f() { return this.addGameForm.controls; }

  AddGame() {
    // Form was submitted
    this.submitted = true;

    // Check if form is valid
    if(this.addGameForm.invalid) {
      return;
    }

    // Get form information
    this.newGame = {
      Name: this.addGameForm.value.Name,
      PlatformId: this.addGameForm.value.PlatformId
    }

    console.log(this.newGame);

    // Create a new game
    this.gameService.addGame(this.newGame).then(obj  => {
      // console.log(obj);
      if(obj.DidError)
      {
        alert(obj.Message);
      }
      else
      {
        this.router.navigate(['/games/' + obj.Model.GameId]);
      }
    });
 }
}
