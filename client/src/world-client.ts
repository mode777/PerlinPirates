import { HubConnection, HubConnectionBuilder } from '@aspnet/signalr';
import { ChunkDto, Chunk } from './models/chunk';
import { Player } from './models/player';


export class WorldClient {

    private connection: HubConnection;

    onTileChanged: (cx: number, cy: number, x: number, y: number, id: number) => void;

    constructor(url: string) {
        this.connection = new HubConnectionBuilder()
            .withUrl(url)
            .build();

        this.registerCallbacks();
    }

    async connect(){
        await this.connection.start();
    }

    async subscribeChunk(cx: number, cy: number){
        const dto = await this.connection.invoke<ChunkDto>("SubscribeChunk", cx, cy);
        return new Chunk(dto);
    }

    async unsubscribeChunk(cx: number, cy: number){
        await this.connection.invoke("UnsubscribeChunk", cx, cy);
    }

    async createPlayer(id: string, player: Player, x: number, y: number){
        return await this.connection.invoke("CreatePlayer", id, player, x, y);
    }

    private registerCallbacks(){
        this.connection.on("onTileChanged", (cx,cy,x,y,id) =>  {
            if(this.onTileChanged)
                this.onTileChanged(cx,cy,x,y,id);
        });
    }

}