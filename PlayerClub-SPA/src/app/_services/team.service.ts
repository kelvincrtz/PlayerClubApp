import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { Team } from '../_models/team';

@Injectable({
  providedIn: 'root'
})
export class TeamService {
  baseUrl = 'http://localhost:5000/api/teams/';

  constructor(private http: HttpClient) { }

  register(team: Team) {
    return this.http.post(this.baseUrl + 'register', team);
  }

  getTeam(id): Observable<Team> {
    return this.http.get<Team>(this.baseUrl + id);
  }

  getTeams(): Observable<Team[]> {
    return this.http.get<Team[]>(this.baseUrl);
  }

}
