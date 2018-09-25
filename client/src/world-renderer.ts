import { Chunk, Tile } from './models/chunk';

export const Tilewidth = 64;
export const Tileheight = 64;

export class WorldRenderer {

    private context: CanvasRenderingContext2D;

    public readonly canvas: HTMLCanvasElement;
        
    constructor(private tileset: HTMLImageElement){
        const canvas = document.createElement('canvas');
        canvas.width = 1920;
        canvas.height = 1080;

        document.body.appendChild(canvas);

        this.context = canvas.getContext('2d');
        this.context.imageSmoothingEnabled = false;

        this.canvas = canvas;
    }

    clear(){
        this.context.clearRect(0,0,this.canvas.width, this.canvas.height);
    }

    renderChunk(chunk: Chunk, offsetX = 0, offsetY = 0){
        
        const chunkX = chunk.x * chunk.width * Tilewidth;
        const chunkY = chunk.y * chunk.height * Tileheight;

        chunk.getTiles().forEach(x => 
            this.renderTile(x, offsetX + chunkX, offsetY + chunkY));        
    }

    private renderTile(tile: Tile, offsetX: number, offsetY: number){
        const my = (tile[2] >>> 2) & 0x3;
        const mx = tile[2] & 0x3;
        const ty = (tile[3] >>> 2) & 0x3;
        const tx = tile[3] & 0x3;

        const px = mx * 64 + tx * 16;
        const py = my * 64 + ty * 16;
        
        this.context.drawImage(
            this.tileset, 
            px, 
            py, 
            16, 
            16, 
            offsetX + tile[0] * Tilewidth, 
            offsetY + tile[1] * Tileheight, 
            Tilewidth, 
            Tileheight);
    }



}