import { Chunk, Tile } from './models/chunk';
import { Player } from './models/player';



export class WorldRenderer {

    readonly tileWidth = 64;
    readonly tileHeight = 64;
    readonly tileZoom = 4;

    private context: CanvasRenderingContext2D;
    private offsetX = 0;
    private offsetY = 0;

    public readonly canvas: HTMLCanvasElement;
        
    constructor(private tileset: HTMLImageElement){
        const canvas = document.createElement('canvas');
        canvas.width = window.innerWidth;
        canvas.height = window.innerHeight;

        document.body.appendChild(canvas);

        this.context = canvas.getContext('2d');
        this.context.imageSmoothingEnabled = false;

        this.canvas = canvas;
    }

    clear(){
        this.context.clearRect(0,0,this.canvas.width, this.canvas.height);
    }

    setOffset(offsetX = 0, offsetY = 0){
        this.offsetX = offsetX;
        this.offsetY = offsetY;
    }

    renderChunk(chunk: Chunk){
        
        const chunkX = chunk.x * chunk.width * this.tileWidth;
        const chunkY = chunk.y * chunk.height * this.tileHeight;

        chunk.getTiles().forEach(x => 
            this.renderTile(x, this.offsetX + chunkX, this.offsetY + chunkY));        
    }

    renderPlayer(player: Player){
        this.context.fillStyle = 'red';
        const x = player.x * this.tileZoom + this.offsetX - 20;
        const y = player.y * this.tileZoom + this.offsetY - 20;
        this.context.fillRect(x , y , 40, 40);
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
            offsetX + tile[0] * this.tileWidth, 
            offsetY + tile[1] * this.tileHeight, 
            this.tileWidth, 
            this.tileHeight);
    }



}