using OpenTK;
using OpenTK.Graphics.OpenGL4;
using SpaceGame.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpaceGame.Render.OpenGL
{
    class RenderObject : IDisposable
    {
        public int Id { get; private set; }
        private VertexInfo vertexInfo;
        private Shader movingShader;
        private Texture texture;

        public RenderObject(VertexInfo vertexInfo, Texture texture)
        {
            this.vertexInfo = vertexInfo;
            this.movingShader = new Shader(@"../../Render/OpenGL/Shader/Transform.vert", @"../../Render/OpenGL/Shader/TextureOverlay.frag");
            this.texture = texture;
            Id = InitializeOpenGL();
        }

        private int InitializeOpenGL()
        {
            int id = GL.GenVertexArray();
            GL.BindVertexArray(id);
            vertexInfo.Use();

            // TODO : сделать методы для получения размеров экрана.
            var projection = Matrix4.CreatePerspectiveFieldOfView(MathHelper.DegreesToRadians(45.0f), 1000 / 800, 0.1f, 100.0f);
            movingShader.SetValue("projection", projection);
            return id;
        }

        public void Draw(Transform transform)
        {
            GL.BindVertexArray(Id);
            movingShader.Use();
            texture.Use();

            Matrix4 view = Matrix4.CreateTranslation(transform.coordination);
            movingShader.SetValue("view", view);

            Matrix4 model = Matrix4.CreateRotationZ(MathHelper.DegreesToRadians(transform.rotation.Z)) *
                Matrix4.CreateRotationY(MathHelper.DegreesToRadians(transform.rotation.Y)) *
                Matrix4.CreateRotationX(MathHelper.DegreesToRadians(transform.rotation.X));
            movingShader.SetValue("model", model);

            GL.DrawArrays(PrimitiveType.Triangles, 0, vertexInfo.VertexCount);
        }

        public void Dispose()
        {
            throw new NotImplementedException();
        }
    }
}
