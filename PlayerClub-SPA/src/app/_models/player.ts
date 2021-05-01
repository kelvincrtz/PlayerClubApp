import { Team } from './team';

export interface Player {
    id: number;
    name: string;
    birthdate: Date;
    age: number;
    height: number;
    weight: number;
    placeOfBirth: string;
    team?: Team;
}
