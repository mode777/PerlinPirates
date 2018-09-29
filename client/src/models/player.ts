import { WorldClient } from '../world-client';

export interface PlayerDto {
    id: string;
    name: string;
    x: number;
    y: number;
}

export class Player implements PlayerDto {
    
    id: string;
    name: string;
    x: number;
    y: number;

    constructor(private client: WorldClient, player: PlayerDto){
        Object.assign(this, player);
    }

    move(x: number, y: number){
        this.x += x;
        this.y += y;
    }
}