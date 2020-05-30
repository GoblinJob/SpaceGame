using OpenTK;
using SpaceGame.Core;
using SpaceGame.Render;
using SpaceGame.Render.OpenGL;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpaceGame.Render
{
    public class StandartShader : Shader
    {
        private Texture texture;

        public StandartShader(Texture texture)
        {
            this.texture = texture;
        }

        public override void Use(Transform objectTransorm, Camera viewer)
        {
            base.Use(objectTransorm, viewer);

            texture.Use();

            this.SetVector3("lightColor", new Vector3(0.8f, 1.0f, 0.95f));
            this.SetMatrix4("view", viewer.View);
            this.SetMatrix4("model", Matrix4.CreateTranslation(objectTransorm.position) * Matrix4.CreateRotationZ(objectTransorm.rotation.Z) *
                Matrix4.CreateRotationY(objectTransorm.rotation.Y) *
                Matrix4.CreateRotationX(objectTransorm.rotation.X));
            this.SetMatrix4("projection", viewer.Projection);
            this.SetVector3("scale", objectTransorm.scale);
        }
    }
}
