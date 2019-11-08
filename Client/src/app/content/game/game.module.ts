import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';
import { DatePipe } from '@angular/common';

import { NgxPaginationModule } from 'ngx-pagination';
import { OrderModule } from 'ngx-order-pipe';

import { CommoncModule } from 'src/app/Pipes/common/commonc.module';
import {  GameRoutingModule } from './game-routing.module';

import { GameListComponent } from './game-list/game-list.component';
import { GameIdComponent } from './game-id/game-id.component';
import { GameAddComponent } from './game-add/game-add.component';
import { GameEditComponent } from './game-edit/game-edit.component';

@NgModule({
  declarations: [GameListComponent, GameIdComponent, GameAddComponent, GameEditComponent],
  imports: [
    CommonModule,
    GameRoutingModule,
    CommoncModule,
    NgxPaginationModule,
    OrderModule,
    FormsModule,
    ReactiveFormsModule
  ],
  exports: [
    DatePipe
  ]
})
export class GameModule { }
