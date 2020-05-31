using OpenTK;
using SpaceGame.Render;
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

            this.SetMatrix4("u_view", viewer.View);
            this.SetMatrix4("u_model", Matrix4.CreateTranslation(objectTransorm.position) * Matrix4.CreateRotationZ(objectTransorm.rotation.Z) *
                Matrix4.CreateRotationY(objectTransorm.rotation.Y) *
                Matrix4.CreateRotationX(objectTransorm.rotation.X));
            this.SetMatrix4("u_projection", viewer.Projection);
            this.SetVector3("u_scale", objectTransorm.scale);
        }
    }
}
