import { Component, OnInit } from '@angular/core';
import { Player } from '../_models/player';
import { PlayerService } from '../_services/player.service';

@Component({
  selector: 'app-player-list',
  templateUrl: './player-list.component.html',
  styleUrls: ['./player-list.component.css']
})
export class PlayerListComponent implements OnInit {
  players: Player[];

  constructor(private playerService: PlayerService) { }

  ngOnInit() {
    this.loadPlayers();
  }

  loadPlayers() {
    this.playerService.getPlayers().subscribe((players: Player[]) => {
      this.players = players;
    }, error => {
      console.log(error);
    });
  }

  viewTeam() {

  }

}
