import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';

import { ContentComponent } from '../content.component';

import { PlatformListComponent } from './platform-list/platform-list.component';
import { PlatformAddComponent } from './platform-add/platform-add.component';
import { PlatformIdComponent } from './platform-id/platform-id.component';
import { PlatformEditComponent } from './platform-edit/platform-edit.component';

const routes: Routes = [
  {
    path: '',
    redirectTo: '/platforms',
    pathMatch: 'full'
  },
  {
    path: 'platforms',
    component: ContentComponent,
    children: [
      {
        path: '',
        component: PlatformListComponent
      },
      {
        path: 'add',
        component: PlatformAddComponent
      },
      {
        path: 'edit/:id',
        component: PlatformEditComponent
      },
      {
        path: ':id',
        component: PlatformIdComponent
      }
    ]
  }
]

@NgModule({
  imports: [RouterModule.forChild(routes)],
  exports: [RouterModule]
})

export class PlatformRoutingModule { }
