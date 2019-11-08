import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';
import { DatePipe } from '@angular/common';

import { NgxPaginationModule } from 'ngx-pagination';
import { OrderModule } from 'ngx-order-pipe';

import { CommoncModule } from 'src/app/Pipes/common/commonc.module';
import { EventRoutingModule } from './event-routing.module';

import { EventListComponent } from './event-list/event-list.component';
import { EventIdComponent } from './event-id/event-id.component';
import { EventEditComponent } from './event-edit/event-edit.component';
import { EventAddComponent } from './event-add/event-add.component';

@NgModule({
  declarations: [EventListComponent, EventIdComponent, EventEditComponent, EventAddComponent],
  imports: [
    CommonModule,
    EventRoutingModule,
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
export class EventModule { }
