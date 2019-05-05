precision mediump float;
uniform sampler2D uTexture;

varying vec2 vTexcoord;
varying vec4 vColor;

void main(void) {
    gl_FragColor = vColor * texture2D(uTexture, vTexcoord);
}