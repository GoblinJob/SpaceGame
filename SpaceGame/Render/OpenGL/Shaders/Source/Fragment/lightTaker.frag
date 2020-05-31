#version 450

in vec3 f_position;
in vec2 f_textureCoord;
in vec3 f_normal;

out vec4 FragColor;
out vec3 Normal;

uniform sampler2D s_texture;

uniform vec3 u_ambiantLightColor;
uniform vec3 u_lightPosition;
uniform vec3 u_lightColor;

void main()
{
    Normal = f_normal;
    vec3 norm = normalize(Normal);
    vec3 lightDir = normalize(u_lightPosition - f_position);
    float diff = max(dot(norm, lightDir), 0.0);
    vec3 diffuse = diff * u_lightColor;
    vec3 tracingLightColor = u_ambiantLightColor + diffuse;
    FragColor = texture(s_texture, f_textureCoord) * vec4(tracingLightColor, 1.0);
}   