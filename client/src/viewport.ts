import { WorldClient } from './world-client';
import { Chunk } from './models/chunk';

const X = 0;
const Y = 1;
const W = 2;
const H = 3;

export class Viewport {
    
    private readonly offset = [-this.viewport[X], -this.viewport[Y]];
    private readonly chunkLookup: { [key: string]: Chunk } = {}
    
    private chunks: Chunk[] = [];
    private updating = false;
    private requestUpdate = false;
        
    constructor(
        private readonly client: WorldClient,
        private readonly viewport: [number,number,number,number],
        private readonly chunkSize: [number, number]){
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

    private async updateAsync(){
        this.requestUpdate = true;

        if(!this.updating){
            this.updating = true;
            this.requestUpdate = false;

            try {
                const chunks = [];
                const keyLookup: {[key: string]: boolean} = {};

                const ystart = Math.floor(this.viewport[Y] / this.chunkSize[Y]); 
                const yend = Math.floor((this.viewport[Y] + this.viewport[H]) / this.chunkSize[Y]); 
                const xstart = Math.floor(this.viewport[X] / this.chunkSize[X]); 
                const xend = Math.floor((this.viewport[X] + this.viewport[W]) / this.chunkSize[X]); 
                
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
}