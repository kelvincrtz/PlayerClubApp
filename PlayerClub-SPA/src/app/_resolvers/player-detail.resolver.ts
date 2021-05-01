import { Injectable } from '@angular/core';
import { Resolve, Router, ActivatedRouteSnapshot } from '@angular/router';
import { Observable, of } from 'rxjs';
import { catchError } from 'rxjs/operators';
import { Player } from '../_models/player';
import { PlayerService } from '../_services/player.service';

@Injectable()
export class PlayerDetailResolver implements Resolve<Player> {

    constructor(private playerService: PlayerService, private router: Router) {}

    resolve(route: ActivatedRouteSnapshot): Observable<Player> {
        return this.playerService.getPlayer(route.params.id).pipe(
            catchError(error => {
                this.router.navigate(['/home']);
                return of(null);
            })
        );
    }
}
