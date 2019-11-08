import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';
import { DatePipe } from '@angular/common';

import { NgxPaginationModule } from 'ngx-pagination';
import { OrderModule } from 'ngx-order-pipe';

import { CommoncModule } from 'src/app/Pipes/common/commonc.module';
import { EmailAccountRoutingModule } from './email-account-routing.module';

import { EmailAccountEditComponent } from './email-account-edit/email-account-edit.component';
import { EmailAccountAddComponent } from './email-account-add/email-account-add.component';
import { EmailAccountIdComponent } from './email-account-id/email-account-id.component';
import { EmailAccountListComponent } from './email-account-list/email-account-list.component';

@NgModule({
  declarations: [EmailAccountEditComponent, EmailAccountAddComponent, EmailAccountIdComponent, EmailAccountListComponent],
  imports: [
    CommonModule,
    EmailAccountRoutingModule,
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
export class EmailAccountModule { }
