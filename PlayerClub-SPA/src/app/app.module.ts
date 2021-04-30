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
import { RegisterTeamComponent } from './register-team/register-team.component';
import { TeamService } from './_services/team.service';

@NgModule({
  declarations: [
    AppComponent,
    PlayerComponent,
    NavComponent,
    HomeComponent,
    RegisterPlayerComponent,
    RegisterTeamComponent
   ],
  imports: [
    BrowserModule,
    HttpClientModule,
    FormsModule,
    ReactiveFormsModule
  ],
  providers: [
    PlayerService,
    TeamService
  ],
  bootstrap: [AppComponent]
})
export class AppModule { }
