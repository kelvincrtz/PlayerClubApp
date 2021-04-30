import { Component, OnInit } from '@angular/core';
import { Team } from '../_models/team';
import { TeamService } from '../_services/team.service';

@Component({
  selector: 'app-team-list',
  templateUrl: './team-list.component.html',
  styleUrls: ['./team-list.component.css']
})
export class TeamListComponent implements OnInit {
  teams: Team[];

  constructor(private teamService: TeamService) { }

  ngOnInit() {
    this.loadTeams();
  }

  loadTeams() {
    this.teamService.getTeams().subscribe((teams: Team[]) => {
      this.teams = teams;
    }, error => {
      console.log(error);
    });
  }

  viewPlayers() {

  }
}
