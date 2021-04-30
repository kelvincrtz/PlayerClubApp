import { HttpClient } from '@angular/common/http';
import { Component, OnInit } from '@angular/core';

@Component({
  selector: 'app-player',
  templateUrl: './player.component.html',
  styleUrls: ['./player.component.css']
})
export class PlayerComponent implements OnInit {
  players: any;

  constructor(private http: HttpClient) { }

  ngOnInit() {
    this.getPlayers();
  }

  getPlayers() {
    // tslint:disable-next-line: deprecation
    this.http.get('http://localhost:5000/api/players').subscribe(response => {
      this.players = response;
    }, error => {
      console.log(error);
    });
  }

}
