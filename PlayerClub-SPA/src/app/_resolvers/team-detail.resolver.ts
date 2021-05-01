import { Injectable } from '@angular/core';
import { Resolve, Router, ActivatedRouteSnapshot } from '@angular/router';
import { Observable, of } from 'rxjs';
import { catchError } from 'rxjs/operators';
import { Team } from '../_models/team';
import { TeamService } from '../_services/team.service';

@Injectable()
export class TeamDetailResolver implements Resolve<Team> {

    constructor(private teamService: TeamService, private router: Router) {}

    resolve(route: ActivatedRouteSnapshot): Observable<Team> {
        return this.teamService.getTeam(route.params.id).pipe(
            catchError(error => {
                this.router.navigate(['/home']);
                return of(null);
            })
        );
    }
}
