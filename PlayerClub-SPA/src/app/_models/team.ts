import { Player } from './player';

export interface Team {
    id: number;
    name: string;
    ground: string;
    coach: string;
    foundedYear: Date;
    region: string;
    players?: Player[];
}
