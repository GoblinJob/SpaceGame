#version 450

layout (location = 0) in vec3 aPosition;
layout (location = 1) in vec2 aTexCoord;

out vec2 TexCoord;

uniform vec3 scale;

uniform mat4 view;
uniform mat4 model;
uniform mat4 projection;

void main()
{
    gl_Position = vec4(aPosition * scale, 1.0) * model * view * projection;
    TexCoord = vec2(aTexCoord.x, aTexCoord.y);
}