#version 450

in vec2 f_textureCoord;

out vec4 FragColor;

uniform sampler2D s_texture;

uniform vec3 u_lightColor;

void main()
{
    FragColor = texture(s_texture, f_textureCoord) * vec4(u_lightColor, 1.0);
}