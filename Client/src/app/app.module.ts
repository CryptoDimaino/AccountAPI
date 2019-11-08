import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';
import { HttpClientModule } from '@angular/common/http';

import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
import { NavbarComponent } from './navbar/navbar.component';
import { SidebarComponent } from './sidebar/sidebar.component';
import { ContentComponent } from './content/content.component';

import { AccountModule } from './content/account/account.module';
import { CodeModule } from './content/code/code.module';
import { EmailAccountModule } from './content/email-account/email-account.module';
import { EventModule } from './content/event/event.module';
import { GameModule } from './content/game/game.module';
import { PlatformModule } from './content/platform/platform.module';
import { ErrorComponent } from './content/error/error.component';

import { CommoncModule } from './Pipes/common/commonc.module';

import { NgxPaginationModule } from 'ngx-pagination';
import { OrderModule } from 'ngx-order-pipe';
import { DatePipe } from '@angular/common';

import { GameService } from './Services/game.service';
import { WumboComponent } from './wumbo/wumbo.component';
// import { ModalComponent } from './modal/modal.component';

import { ModalService } from '../app/modal/modal.service';

import { ModalModule } from '../app/modal/modal.module';

@NgModule({
  declarations: [
    AppComponent,
    NavbarComponent,
    SidebarComponent,
    ContentComponent,
    ErrorComponent,
    WumboComponent,
    // ModalComponent,
  ],
  imports: [
    BrowserModule,
    AccountModule,
    CodeModule,
    EmailAccountModule,
    EventModule,
    GameModule,
    PlatformModule,
    AppRoutingModule,
    CommoncModule,
    NgxPaginationModule,
    OrderModule,
    FormsModule,
    HttpClientModule,
    ReactiveFormsModule,
    ModalModule
  ],
  providers: [DatePipe, GameService],
  bootstrap: [AppComponent]
})
export class AppModule { }
