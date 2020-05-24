#version 450
out vec4 FragColor;

in vec2 TexCoord;
uniform sampler2D texture0;

uniform vec3 color;

void main()
{
    FragColor = texture(texture0, TexCoord);
}