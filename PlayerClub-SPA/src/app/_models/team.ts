import { Player } from './player';

export interface Team {
    name: string;
    ground: string;
    coach: string;
    foundedYear: Date;
    region: string;
    players?: Player[];
}
