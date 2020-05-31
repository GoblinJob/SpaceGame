#version 450

layout (location = 0) in vec3 v_position;
layout (location = 1) in vec2 v_textureCoord;
layout (location = 2) in vec3 v_normal;

out vec3 f_position;
out vec2 f_textureCoord;
out vec3 f_normal;

uniform vec3 u_scale;
uniform mat4 u_view;
uniform mat4 u_model;
uniform mat4 u_projection;

void main()
{
    gl_Position = vec4(v_position * u_scale, 1.0) * u_model * u_view * u_projection;
    f_position = v_position;
    f_textureCoord = v_textureCoord;
    f_normal = v_normal;
}