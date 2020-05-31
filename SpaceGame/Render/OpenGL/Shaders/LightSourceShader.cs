using OpenTK;
using System.Drawing;
using System.IO;

namespace SpaceGame.Render
{
    public class LightSourceShader : StandartShader
    {
        public Vector3 Position { get; private set; }
        public Vector3 LightColor { get; private set; }
        public LightSourceShader(Texture texture, Vector3 lightColor) : base(texture)
        {
            this.LightColor = lightColor;
        }
        public override void Load(StreamReader vertexShaderFile, StreamReader fragmentShaderFile)
        {
            base.Load(vertexShaderFile, fragmentShaderFile);
        }

        public override void Use(Transform objectTransorm, Camera viewer)
        {
            base.Use(objectTransorm, viewer);

            this.Position = objectTransorm.position;
            this.SetVector3("u_lightColor", LightColor);
        }
    }
}
