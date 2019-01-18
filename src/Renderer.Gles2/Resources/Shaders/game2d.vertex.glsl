attribute vec2 aPosition;
attribute vec2 aTexcoord;

uniform vec2 uTextureSize;
uniform mat3 uTransform;
uniform mat3 uProject;

varying vec2 vTexcoord;
	
void main(void) {
    vec3 transformed =  uProject * uTransform * vec3(aPosition, 1.0);
    vTexcoord = aTexcoord / uTextureSize;
    gl_Position = vec4(transformed, 1.0);
}