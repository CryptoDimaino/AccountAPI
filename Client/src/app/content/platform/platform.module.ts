import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';
import { DatePipe } from '@angular/common';

import { NgxPaginationModule } from 'ngx-pagination';
import { OrderModule } from 'ngx-order-pipe';

import { CommoncModule } from 'src/app/Pipes/common/commonc.module';
import { PlatformRoutingModule } from './platform-routing.module';

import { PlatformAddComponent } from './platform-add/platform-add.component';
import { PlatformEditComponent } from './platform-edit/platform-edit.component';
import { PlatformIdComponent } from './platform-id/platform-id.component';
import { PlatformListComponent } from './platform-list/platform-list.component';


@NgModule({
  declarations: [PlatformAddComponent, PlatformEditComponent, PlatformIdComponent, PlatformListComponent],
  imports: [
    CommonModule,
    PlatformRoutingModule,
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
export class PlatformModule { }
