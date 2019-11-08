import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';
import { DatePipe } from '@angular/common';

import { NgxPaginationModule } from 'ngx-pagination';
import { OrderModule } from 'ngx-order-pipe';

import { CommoncModule } from 'src/app/Pipes/common/commonc.module';
import { AccountRoutingModule } from './account-routing.module';

import { AccountIdComponent } from './account-id/account-id.component';
import { AccountListComponent } from './account-list/account-list.component';
import { AccountEditComponent } from './account-edit/account-edit.component';
import { AccountAddComponent } from './account-add/account-add.component';

import { ModalModule } from '../../modal/modal.module';



@NgModule({
  declarations: [AccountIdComponent, AccountListComponent, AccountEditComponent, AccountAddComponent],
  imports: [
    CommonModule,
    AccountRoutingModule,
    CommoncModule,
    NgxPaginationModule,
    OrderModule,
    FormsModule,
    ReactiveFormsModule,
    ModalModule
  ],
  exports: [
    DatePipe
  ]
})
export class AccountModule { }
