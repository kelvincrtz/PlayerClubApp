import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';
import { HttpClientModule } from '@angular/common/http';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';
import { RouterModule } from '@angular/router';

import { AppComponent } from './app.component';
import { NavComponent } from './nav/nav.component';
import { PlayerService } from './_services/player.service';
import { HomeComponent } from './home/home.component';
import { RegisterPlayerComponent } from './register-player/register-player.component';
import { RegisterTeamComponent } from './register-team/register-team.component';
import { TeamService } from './_services/team.service';
import { PlayerListComponent } from './player-list/player-list.component';
import { TeamListComponent } from './team-list/team-list.component';
import { appRoutes } from './routes';
import { PlayerTeamViewComponent } from './player-team-view/player-team-view.component';
import { PlayerDetailResolver } from './_resolvers/player-detail.resolver';
import { TeamPlayerViewComponent } from './team-player-view/team-player-view.component';
import { TeamDetailResolver } from './_resolvers/team-detail.resolver';
import { TeamPlayerListComponent } from './team-player-list/team-player-list.component';

@NgModule({
  declarations: [	
    AppComponent,
    NavComponent,
    HomeComponent,
    RegisterPlayerComponent,
    RegisterTeamComponent,
    PlayerListComponent,
    TeamListComponent,
    PlayerTeamViewComponent,
    TeamPlayerViewComponent,
      TeamPlayerListComponent
   ],
  imports: [
    BrowserModule,
    HttpClientModule,
    FormsModule,
    ReactiveFormsModule,
    RouterModule.forRoot(appRoutes)
  ],
  providers: [
    PlayerService,
    TeamService,
    PlayerDetailResolver,
    TeamDetailResolver
  ],
  bootstrap: [AppComponent]
})
export class AppModule { }
