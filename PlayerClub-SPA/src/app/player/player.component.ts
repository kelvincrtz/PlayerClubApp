import { HttpClient } from '@angular/common/http';
import { Component, OnInit } from '@angular/core';
import { PlayerService } from '../_services/player.service';

@Component({
  selector: 'app-player',
  templateUrl: './player.component.html',
  styleUrls: ['./player.component.css']
})
export class PlayerComponent implements OnInit {
  players: any;

  constructor(private playerService: PlayerService) { }

  ngOnInit() {

  }

  getPlayers() {

  }

}
