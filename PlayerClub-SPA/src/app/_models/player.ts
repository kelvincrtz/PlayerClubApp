import { Team } from './team';

export interface Player {
    id: number;
    name: string;
    birthdate: Date;
    height: number;
    weight: number;
    placeOfBirth: string;
    team?: Team;
}
