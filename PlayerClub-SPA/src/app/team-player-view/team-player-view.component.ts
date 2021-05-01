import { Component, OnInit } from '@angular/core';
import { ActivatedRoute } from '@angular/router';
import { Player } from '../_models/player';
import { Team } from '../_models/team';

@Component({
  selector: 'app-team-player-view',
  templateUrl: './team-player-view.component.html',
  styleUrls: ['./team-player-view.component.css']
})
export class TeamPlayerViewComponent implements OnInit {
  team: Team;
  players: Player[];

  constructor(private route: ActivatedRoute) { }

  ngOnInit() {
    this.route.data.subscribe(data => {
      this.team = data.team;
    });

    this.players = this.team.players;
  }
}
