import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';

import { ContentComponent } from '../content.component';

import { GameListComponent } from './game-list/game-list.component';
import { GameAddComponent } from './game-add/game-add.component';
import { GameEditComponent } from './game-edit/game-edit.component';
import { GameIdComponent } from './game-id/game-id.component';


const routes: Routes = [
  {
    path: '',
    redirectTo: '/games',
    pathMatch: 'full'
  },
  {
    path: 'games',
    component: ContentComponent,
    children: [
      {
        path: '',
        component: GameListComponent
      },
      {
        path: 'add',
        component: GameAddComponent
      },
      {
        path: 'edit/:id',
        component: GameEditComponent
      },
      {
        path: ':id',
        component: GameIdComponent
      }
    ]
  }
]

@NgModule({
  imports: [RouterModule.forChild(routes)],
  exports: [RouterModule]
})

export class GameRoutingModule { }
