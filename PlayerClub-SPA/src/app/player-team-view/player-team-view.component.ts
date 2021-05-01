import { Component, OnInit } from '@angular/core';
import { ActivatedRoute } from '@angular/router';
import { Player } from '../_models/player';

@Component({
  selector: 'app-player-team-view',
  templateUrl: './player-team-view.component.html',
  styleUrls: ['./player-team-view.component.css']
})
export class PlayerTeamViewComponent implements OnInit {
  player: Player;

  constructor(private route: ActivatedRoute) { }

  ngOnInit() {
    this.route.data.subscribe(data => {
      this.player = data.player;
    });
  }
}
