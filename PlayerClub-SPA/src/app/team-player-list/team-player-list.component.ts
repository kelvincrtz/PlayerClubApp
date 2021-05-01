import { Component, Input, OnInit } from '@angular/core';
import { Player } from '../_models/player';

@Component({
  selector: 'app-team-player-list',
  templateUrl: './team-player-list.component.html',
  styleUrls: ['./team-player-list.component.css']
})
export class TeamPlayerListComponent implements OnInit {
  @Input() player: Player;

  constructor() { }

  ngOnInit() {
  }

}
