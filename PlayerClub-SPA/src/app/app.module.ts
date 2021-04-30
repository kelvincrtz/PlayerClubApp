import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';
import { HttpClientModule } from '@angular/common/http';

import { AppComponent } from './app.component';
import { PlayerComponent } from './player/player.component';
import { NavComponent } from './nav/nav.component';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';
import { PlayerService } from './_services/player.service';
import { HomeComponent } from './home/home.component';
import { RegisterPlayerComponent } from './register-player/register-player.component';

@NgModule({
  declarations: [
    AppComponent,
    PlayerComponent,
    NavComponent,
    HomeComponent,
    RegisterPlayerComponent
   ],
  imports: [
    BrowserModule,
    HttpClientModule,
    FormsModule,
    ReactiveFormsModule
  ],
  providers: [
    PlayerService
  ],
  bootstrap: [AppComponent]
})
export class AppModule { }
