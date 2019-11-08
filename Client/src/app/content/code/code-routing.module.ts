import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';

import { ContentComponent } from '../content.component';

import { CodeListComponent } from './code-list/code-list.component';
import { CodeAddComponent } from './code-add/code-add.component';
import { CodeEditComponent } from './code-edit/code-edit.component';
import { CodeIdComponent } from './code-id/code-id.component';


const routes: Routes = [
  {
    path: '',
    redirectTo: '/codes',
    pathMatch: 'full'
  },
  {
    path: 'codes',
    component: ContentComponent,
    children: [
      {
        path: '',
        component: CodeListComponent
      },
      {
        path: 'add',
        component: CodeAddComponent
      },
      {
        path: 'edit/:id',
        component: CodeEditComponent
      },
      {
        path: ':id',
        component: CodeIdComponent
      }
    ]
  }
]

@NgModule({
  imports: [RouterModule.forChild(routes)],
  exports: [RouterModule]
})

export class CodeRoutingModule { }
