using OpenTK;
using SpaceGame.Render;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpaceGame.Render
{
    public class LightTakerShader : StandartShader
    {
        private LightSourceShader lightSource;
        private Vector3 ambiantColor;
        public LightTakerShader(Texture texture, LightSourceShader lightSource, Vector3 ambiantColor) : base(texture)
        {
            this.lightSource = lightSource;
            this.ambiantColor = ambiantColor;
        }

        public override void Use(Transform objectTransorm, Camera viewer)
        {
            base.Use(objectTransorm, viewer);

            this.SetVector3("u_ambiantLightColor", ambiantColor);
            this.SetVector3("u_lightPosition", lightSource.Position);
            this.SetVector3("u_lightColor", lightSource.LightColor);
        }
    }
}
