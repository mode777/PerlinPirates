//import { Scene, FreeCamera, Engine, Vector3, ArcRotateCamera, HemisphericLight, PointLight, MeshBuilder, StandardMaterial, Color3, Mesh } from 'babylonjs';
//import 'babylonjs-materials';

import { WorldClient } from './world-client';
import { WorldRenderer, Tilewidth, Tileheight } from './world-renderer';
import { Chunk } from './models/chunk';
import { Viewport } from './viewport';
import { Player } from './models/player';

let dx = 0;
let dy = 0;

const scrollMargin = 100;
const speed = 10;

main();

async function main() {
    const client = new WorldClient('http://localhost:5000');
    const tileset = document.createElement('img');
    tileset.src = './assets/tileset.png';

    const renderer = new WorldRenderer(tileset);   
    const viewport = new Viewport(client, 
        [0,0,renderer.canvas.width, renderer.canvas.height],
        [Tilewidth * 32, Tileheight * 32]);
        
    await client.connect();
    console.log(await client.createPlayer("player3", new Player("Alex"), 0,0));
    
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
    viewport.move(dx, dy);

    const offset = viewport.getOffset();
    const chunks = viewport.getChunks();
    
    renderer.clear();
    chunks.forEach(x => renderer.renderChunk(x, offset[0], offset[1]));
    
    requestAnimationFrame(() => render(renderer, viewport));
}

// async function babylonMain(){
//     const client = new WorldClient('http://localhost:5000');
//     await client.connect();

//     const chunk = await client.subscribeChunk(0,0);


//     const canvas = document.createElement('canvas');
//     canvas.width = 1024;
//     canvas.height = 1024;
//     document.body.appendChild(canvas);
    
//     const engine = new Engine(canvas, true);

//     /******* Add the create scene function ******/
//     const createScene = () => {

//         // Create the scene space
//         const scene = new Scene(engine);

//         // Add a camera to the scene and attach it to the canvas
//         const camera = new ArcRotateCamera('Camera', Math.PI / 2, Math.PI / 2, 2, new Vector3(0,0,5), scene);
//         camera.attachControl(canvas, true);

//         // Add lights to the scene
//         const light1 = new HemisphericLight('light1', new Vector3(1, 1, 0), scene);
//         //const light2 = new PointLight('light2', new Vector3(0, 1, -1), scene);

//         var skybox = BABYLON.Mesh.CreateBox("skyBox", 5000.0, scene);
//         var skyboxMaterial = new BABYLON.StandardMaterial("skyBox", scene);
//         skyboxMaterial.backFaceCulling = false;
//         skyboxMaterial.reflectionTexture = new BABYLON.CubeTexture("//www.babylonjs.com/assets/skybox/TropicalSunnyDay", scene);
//         skyboxMaterial.reflectionTexture.coordinatesMode = BABYLON.Texture.SKYBOX_MODE;
//         skyboxMaterial.diffuseColor = new BABYLON.Color3(0, 0, 0);
//         skyboxMaterial.specularColor = new BABYLON.Color3(0, 0, 0);
//         skyboxMaterial.disableLighting = true;
//         skybox.material = skyboxMaterial;

//             // Water material
//         // var waterMaterial = new BABYLON.WaterMaterial("waterMaterial", scene, new BABYLON.Vector2(512, 512));
//         // waterMaterial.bumpTexture = new BABYLON.Texture("//www.babylonjs.com/assets/waterbump.png", scene);
//         // // waterMaterial.windForce = -1;
//         // waterMaterial.waveHeight = 0;
//         // // waterMaterial.bumpHeight = 0.1;
//         // // waterMaterial.waveLength = 0.01;
//         // // waterMaterial.waveSpeed = 50.0;
//         // waterMaterial.colorBlendFactor = 0;
//         // waterMaterial.colorBlendFactor = 0;

//         // // Water mesh
//         // const waterMesh = BABYLON.Mesh.CreateGround("waterMesh", 50, 50, 32, scene, false);
//         // waterMesh.material = waterMaterial;

//         // waterMaterial.addToRenderList(merged);
//         // waterMaterial.addToRenderList(skybox);

//         console.log(chunk)

//         var meshes: Mesh[] = [];
        
//         for (let z = 0; z < chunk.height; z++) {
//             for (let x = 0; x < chunk.width; x++) {
//                 const height = Math.floor(chunk.data[x + (z * chunk.width)] / 16) / 4;

//                 const box = MeshBuilder.CreateBox(`box-${x}-${z}`, {
//                     width: 0.5,
//                     depth: 0.5,
//                     height: height
//                 }, scene);                
//                 box.position.set(0.5 * x, height / 2 - 1.8, 0.5 * z);

//                 meshes.push(box);
//             }            
//         }

//         const merged = Mesh.MergeMeshes(meshes);



//         return scene;
//     };

//     const scene = createScene(); //Call the createScene function

//     // Register a render loop to repeatedly render the scene
//     engine.runRenderLoop(function () { 
//         scene.render();
//     });

//     // Watch for browser/canvas resize events
//     window.addEventListener('resize', function () { 
//         engine.resize();
//     })
// }