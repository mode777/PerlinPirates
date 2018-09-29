import { HubConnection, HubConnectionBuilder } from '@aspnet/signalr';
import { ChunkDto, Chunk } from './models/chunk';
import { Player, PlayerDto } from './models/player';


export class WorldClient {

    private connection: HubConnection;

    onTileChanged: (cx: number, cy: number, x: number, y: number, id: number) => void;

    constructor(url: string) {
        this.connection = new HubConnectionBuilder()
            .withUrl(url)
            .build();
    }

    async connectPlayer(playername: string){
        await this.connection.start();

        let player = await this.getPlayer(playername);
        
        if(!player){
            await this.createPlayer(playername);
            player = await this.getPlayer(playername);
        }

        return player;
    }

    async subscribeChunk(cx: number, cy: number){
        const dto = await this.connection.invoke<ChunkDto>("SubscribeChunk", cx, cy);
        return new Chunk(dto);
    }

    async unsubscribeChunk(cx: number, cy: number){
        await this.connection.invoke("UnsubscribeChunk", cx, cy);
    }

    async createPlayer(id: string) {
        await this.connection.invoke("RegisterPlayer", id);
    }
    
    async getPlayer(id: string){
        const dto = await this.connection.invoke<PlayerDto>("GetPlayer", id);        
        
        if(!dto)
            return null;

        return new Player(this, dto);
    }
}