import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { Player } from '../_models/player';

@Injectable({
  providedIn: 'root'
})
export class PlayerService {
  baseUrl = 'http://localhost:5000/api/players/';

  constructor(private http: HttpClient) { }

  register(player: Player) {
    return this.http.post(this.baseUrl + 'register', player);
  }

  getPlayer(id): Observable<Player> {
    return this.http.get<Player>(this.baseUrl + id);
  }

  getPlayers(): Observable<Player[]> {
    return this.http.get<Player[]>(this.baseUrl);
  }

}
