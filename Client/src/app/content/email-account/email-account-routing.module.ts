import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';

import { ContentComponent } from '../content.component';

import { EmailAccountListComponent } from './email-account-list/email-account-list.component';
import { EmailAccountAddComponent } from './email-account-add/email-account-add.component';
import { EmailAccountEditComponent } from './email-account-edit/email-account-edit.component';
import { EmailAccountIdComponent } from './email-account-id/email-account-id.component';

const routes: Routes = [
  {
    path: '',
    redirectTo: '/emailaccounts',
    pathMatch: 'full'
  },
  {
    path: 'emailaccounts',
    component: ContentComponent,
    children: [
      {
        path: '',
        component: EmailAccountListComponent
      },
      {
        path: 'add',
        component: EmailAccountAddComponent
      },
      {
        path: 'edit/:id',
        component: EmailAccountEditComponent
      },
      {
        path: ':id',
        component: EmailAccountIdComponent
      }
    ]
  }
]

@NgModule({
  imports: [RouterModule.forChild(routes)],
  exports: [RouterModule]
})

export class EmailAccountRoutingModule { }
