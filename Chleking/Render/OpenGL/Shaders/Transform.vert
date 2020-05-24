#version 450

mat4 getModel(vec3 rotation);
mat4 getView(vec3 position);

layout (location = 0) in vec3 aPosition;
layout (location = 1) in vec2 aTexCoord;

out vec2 TexCoord;

uniform vec3 position;
uniform vec3 rotation;
uniform vec3 scale;

uniform mat4 projection;

void main()
{
    mat4 view = getView(rotation);
    mat4 model = getModel(position);
    gl_Position = vec4(aPosition * scale, 1.0) * model *  view * projection;
    TexCoord = vec2(aTexCoord.x, aTexCoord.y);
}


mat4 getModelX(float angle)
{
    float angleXSin = sin(angle);
    float anglXeCos = cos(angle);
    mat4 modelX = mat4(1, 0, 0, 0,
        0, anglXeCos, -angleXSin, 0,
        0, angleXSin, anglXeCos, 0,
        0, 0, 0, 1); 
    return modelX;
}

mat4 getModelY(float angle)
{
    float angleYSin = sin(angle);
    float angleYCos = cos(angle);
    mat4 modelY = mat4(angleYCos, 0, angleYSin, 0,
        0, 1, 0, 0,
        -angleYSin, 0, angleYCos, 0,
        0, 0, 0, 1); 
    return modelY;
}

mat4 getModelZ(float angle)
{
    float angleZSin = sin(angle);
    float angleZCos = cos(angle);
    mat4 modelX = mat4(angleZCos, -angleZSin, 0, 0,
        angleZSin, angleZCos, 0, 0,
        0, 0, 1, 0,
        0, 0, 0, 1); 
    return modelX;
}
mat4 getModel(vec3 rotation)
{
    return getModelZ(rotation.z) * getModelY(rotation.y) * getModelX(rotation.x);
}

mat4 getView(vec3 position)
{
    return mat4(1, 0, 0, 0,
        0, 1, 0, 0,
        0, 0, 1, 0,
        position.x, position.y, position.z, 1);
}