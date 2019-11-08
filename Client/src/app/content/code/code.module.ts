import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';
import { DatePipe } from '@angular/common';

import { NgxPaginationModule } from 'ngx-pagination';
import { OrderModule } from 'ngx-order-pipe';

import { CommoncModule } from 'src/app/Pipes/common/commonc.module';
import { CodeRoutingModule } from './code-routing.module';

import { CodeIdComponent } from './code-id/code-id.component';
import { CodeAddComponent } from './code-add/code-add.component';
import { CodeListComponent } from './code-list/code-list.component';
import { CodeEditComponent } from './code-edit/code-edit.component';

import { ModalModule } from '../../modal/modal.module';


@NgModule({
  declarations: [CodeIdComponent, CodeAddComponent, CodeListComponent, CodeEditComponent],
  imports: [
    CommonModule,
    CodeRoutingModule,
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
export class CodeModule { }
