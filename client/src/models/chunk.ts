const DeepWater = 0;
const ShallowWater = 1;
const Coast = 2;
const Wood = 3;
const Mountain = 4;
const Volcano = 5;

const materialIds = [
    0, // deep water
    1, // shallow water
    4, // coast
    8, // woods
    8, // mountain
    8, // volcano
]

export interface ChunkDto{
    x: number,
    y: number,
    width: number,
    height: number
    data: string;
}

export type Tile = [number, number, number, number];

export class Chunk{

    readonly x: number;
    readonly y: number;
    readonly width: number;
    readonly height: number;
    readonly data: Uint8Array;
    
    private readonly tiles: Tile[] = [];

    constructor(dto: ChunkDto){
        this.x = dto.x;
        this.y = dto.y;
        this.width = dto.width;
        this.height = dto.height;

        this.data = new Uint8Array(base64ToArrayBuffer(dto.data));
        this.createTiles();
    }

    public get hasTiles() {
        return this.tiles.length > 0;
    }

    public getTiles(){       
        return this.tiles;
    }

    public createTiles(){
        for (let y = 1; y < this.width; y++) {
            for (let x = 1; x < this.height; x++) {
                this.visitCorner(x,y);
            }            
        }
    }
    // -----
    // |a|b|
    // --*--
    // |c|d|
    // -----
    private visitCorner(x: number, y: number){
        const a = this.data[(x-1) + (y-1) * this.width];
        const b = this.data[x + (y-1) * this.width];
        const c = this.data[(x-1) + y * this.width];
        const d = this.data[x + y * this.width];

        const max = Math.max(a,b,c,d);
        const min = Math.min(a,b,c,d);

        for (let i = min; i <= max; i++) { 
            const transitionId = this.getTransitionId(
                a >= i, 
                b >= i, 
                c >= i, 
                d >= i);

            this.tiles.push([x,y,materialIds[i],transitionId]);
        }         
    }

    private getTransitionId(a: boolean, b: boolean, c: boolean, d: boolean){
        return (a ? 8 : 0) + (b ? 4 : 0) + (c ? 2 : 0) + (d ? 1: 0)
    }
}

function base64ToArrayBuffer(base64) {
    var binary_string =  window.atob(base64);
    var len = binary_string.length;
    var bytes = new Uint8Array( len );
    for (var i = 0; i < len; i++)        {
        bytes[i] = binary_string.charCodeAt(i);
    }
    return bytes.buffer;
}