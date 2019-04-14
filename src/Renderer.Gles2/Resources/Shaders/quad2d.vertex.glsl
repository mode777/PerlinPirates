attribute vec2 aPosition;
attribute vec2 aTexcoord;

varying vec2 vTexcoord;

uniform mat3 uProject;
uniform mat3 uProject_uv;
	
void main(void) {
    vTexcoord = (uProject_uv * vec3(aTexcoord, 1.0)).xy;
    gl_Position = vec4(uProject * vec3(aPosition, 1.0), 1.0);
}