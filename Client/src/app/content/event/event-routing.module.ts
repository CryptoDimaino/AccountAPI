import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';

import { ContentComponent } from '../content.component';

import { EventListComponent } from './event-list/event-list.component';
import { EventAddComponent } from './event-add/event-add.component';
import { EventEditComponent } from './event-edit/event-edit.component';
import { EventIdComponent } from './event-id/event-id.component';

const routes: Routes = [
  {
    path: '',
    redirectTo: '/events',
    pathMatch: 'full'
  },
  {
    path: 'events',
    component: ContentComponent,
    children: [
      {
        path: '',
        component: EventListComponent
      },
      {
        path: 'add',
        component: EventAddComponent
      },
      {
        path: 'edit/:id',
        component: EventEditComponent
      },
      {
        path: ':id',
        component: EventIdComponent
      }
    ]
  }
]

@NgModule({
  imports: [RouterModule.forChild(routes)],
  exports: [RouterModule]
})

export class EventRoutingModule { }
