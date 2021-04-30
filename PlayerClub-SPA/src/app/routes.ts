import { Routes } from '@angular/router';
import { HomeComponent } from './home/home.component';
import { PlayerListComponent } from './player-list/player-list.component';
import { TeamListComponent } from './team-list/team-list.component';

export const appRoutes: Routes = [
    { path: 'home', component: HomeComponent},
    { path: 'players', component: PlayerListComponent},
    { path: 'teams', component: TeamListComponent},
    { path: '**', redirectTo: 'home', pathMatch: 'full'}
];
