﻿precision mediump float;

uniform sampler2D uTexture;

varying vec2 vTexcoord;

void main(void) {
    gl_FragColor = texture2D(uTexture, vTexcoord);
    gl_FragColor = gl_FragColor;
}