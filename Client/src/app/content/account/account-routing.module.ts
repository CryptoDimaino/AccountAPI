import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';

import { ContentComponent } from '../content.component';

import { AccountListComponent } from './account-list/account-list.component';
import { AccountAddComponent } from './account-add/account-add.component';
import { AccountEditComponent } from './account-edit/account-edit.component';
import { AccountIdComponent } from './account-id/account-id.component';

const routes: Routes = [
  {
    path: '',
    redirectTo: '/accounts',
    pathMatch: 'full'
  },
  {
    path: 'accounts',
    component: ContentComponent,
    children: [
      {
        path: '',
        component: AccountListComponent
      },
      {
        path: 'add',
        component: AccountAddComponent
      },
      {
        path: 'edit/:id',
        component: AccountEditComponent
      },
      {
        path: ':id',
        component: AccountIdComponent
      }
    ]
  }
]

@NgModule({
  imports: [RouterModule.forChild(routes)],
  exports: [RouterModule]
})

export class AccountRoutingModule { }
