import { WorldClient } from './world-client';
import { Chunk } from './models/chunk';
import { WorldRenderer } from './world-renderer';
import { Player } from './models/player';

const X = 0;
const Y = 1;
const W = 2;
const H = 3;

export class Viewport {
    
    
    readonly chunkWidth = 32;
    readonly chunkHeight = 32;
        
    private readonly viewport: Int16Array = new Int16Array(4);
    private readonly offset: [number,number] = [0,0];
    private readonly chunkLookup: { [key: string]: Chunk } = {}
    private readonly size: [number, number];
    private readonly position: [number, number];

    
    private chunks: Chunk[] = [];
    private updating = false;
    private requestUpdate = false;
        
    constructor(
        private readonly client: WorldClient,
        private readonly renderer: WorldRenderer){
            this.viewport[X] = this.offset[X];
            this.viewport[Y] = this.offset[Y];
            this.viewport[W] = this.renderer.canvas.width;
            this.viewport[H] = this.renderer.canvas.height;
    }

    public getChunks(){
        if(this.chunks.length == 0)
            this.updateAsync();

        return this.chunks;
    }

    public getOffset(){
        this.offset[X] = -this.viewport[X];
        this.offset[Y] = -this.viewport[Y];
        return this.offset;
    }

    public move(x: number, y: number){
        this.viewport[X]+=x;
        this.viewport[Y]+=y;

        this.updateAsync();
    }

    public moveTo(x: number, y: number){
        this.viewport[X]=x;
        this.viewport[Y]=y;

        this.updateAsync();
    }

    public async updateAsync(){
        this.requestUpdate = true;

        if(!this.updating){
            this.updating = true;
            this.requestUpdate = false;

            try {
                const chunks = [];
                const keyLookup: {[key: string]: boolean} = {};

                const ystart = Math.floor(this.viewport[Y] / (this.chunkHeight * this.renderer.tileHeight)); 
                const yend = Math.ceil((this.viewport[Y] + this.viewport[H]) / (this.chunkHeight * this.renderer.tileHeight)); 
                const xstart = Math.floor(this.viewport[X] / (this.chunkWidth * this.renderer.tileWidth)); 
                const xend = Math.ceil((this.viewport[X] + this.viewport[W]) / (this.chunkWidth * this.renderer.tileWidth));       
                
                for (let cy = ystart; cy <= yend; cy++) {
                    
                    for (let cx = xstart; cx <= xend; cx++) {
                        const key = this.getKey(cx,cy);
    
                        if(!this.chunkLookup[key]){
                            //console.log("add", key);
                            const chk = await this.client.subscribeChunk(cx,cy);
                            this.chunkLookup[key] = chk;
                        }
                        const chunk = this.chunkLookup[key];
                                                
                        keyLookup[key] = true;
                        chunks.push(chunk);
                    }            
                }

                // cleanup
                const toRemove = Object.keys(this.chunkLookup).filter(key => !keyLookup[key]);

                for (const key of toRemove) {
                    //console.log("remove", key);
                    const chunk = this.chunkLookup[key];
                    await this.client.unsubscribeChunk(chunk.x, chunk.y);                    
                    delete this.chunkLookup[key];
                }

                this.chunks = chunks;
            }
            catch(e){
                console.error(e);
            }
            this.updating = false;
            if(this.requestUpdate){
                this.updateAsync();
            }
        }
    }

    private getKey(x: number, y:number){
        return `${x},${y}`;
    }

    public centerPlayer(player: Player){
        this.viewport[X] = (player.x * this.renderer.tileZoom) - this.renderer.canvas.width / 2;
        this.viewport[Y] = (player.y * this.renderer.tileZoom) - this.renderer.canvas.height / 2;
    }
}