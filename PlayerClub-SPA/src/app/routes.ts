import { Routes } from '@angular/router';
import { HomeComponent } from './home/home.component';
import { PlayerListComponent } from './player-list/player-list.component';
import { PlayerTeamViewComponent } from './player-team-view/player-team-view.component';
import { TeamListComponent } from './team-list/team-list.component';
import { TeamPlayerViewComponent } from './team-player-view/team-player-view.component';
import { PlayerDetailResolver } from './_resolvers/player-detail.resolver';
import { TeamDetailResolver } from './_resolvers/team-detail.resolver';

export const appRoutes: Routes = [
    { path: 'home', component: HomeComponent},
    { path: 'players', component: PlayerListComponent},
    { path: 'teams', component: TeamListComponent},
    { path: 'playerteamview/:id', component: PlayerTeamViewComponent,
        resolve: {player: PlayerDetailResolver}},
    { path: 'teamplayerview/:id', component: TeamPlayerViewComponent,
        resolve: {team: TeamDetailResolver}},
    { path: '**', redirectTo: 'home', pathMatch: 'full'}
];
