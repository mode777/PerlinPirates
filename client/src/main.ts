//import { Scene, FreeCamera, Engine, Vector3, ArcRotateCamera, HemisphericLight, PointLight, MeshBuilder, StandardMaterial, Color3, Mesh } from 'babylonjs';
//import 'babylonjs-materials';

import { WorldClient } from './world-client';
import { WorldRenderer } from './world-renderer';
import { Viewport } from './viewport';
import { Player } from './models/player';

const scrollMargin = 100;
const speed = 2;

let player: Player;
let viewport: Viewport;

let dx = 0;
let dy = 0;

main();

async function main() {
    const client = new WorldClient('http://localhost:5000');
    //const id = prompt('Enter PlayerID');
    player = await client.connectPlayer('Alex');
    
    const tileset = document.createElement('img');
    tileset.src = './assets/tileset.png';
    const renderer = new WorldRenderer(tileset);   
    
    viewport = new Viewport(client, renderer);       
    
    renderer.canvas.onmousemove = (ev) => {
        if(ev.offsetX > (renderer.canvas.width - scrollMargin))
            dx = speed;
        else if(ev.offsetX < scrollMargin)
            dx = -speed;
        else
            dx = 0;

        if(ev.offsetY > (renderer.canvas.height - scrollMargin))
            dy = speed;
        else if(ev.offsetY < scrollMargin)
            dy = -speed;
        else
            dy = 0;   
    }

    requestAnimationFrame(() => render(renderer, viewport));
};

function render(renderer: WorldRenderer, viewport: Viewport){
    player.move(dx,dy);
    viewport.centerPlayer(player);
    viewport.updateAsync();

    const offset = viewport.getOffset();
    const chunks = viewport.getChunks();
    
    renderer.setOffset(offset[0], offset[1]);
    renderer.clear();
    chunks.forEach(x => renderer.renderChunk(x, ));
    renderer.renderPlayer(player);
    
    requestAnimationFrame(() => render(renderer, viewport));
}