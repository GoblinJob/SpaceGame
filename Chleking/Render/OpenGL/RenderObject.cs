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
    public class RenderObject : IDisposable
    {
        public int Id { get; private set; }
        private VertexInfo vertexInfo;
        private Shader movingShader;
        private Texture texture;

        Matrix4 _view;
        Matrix4 _projection;

        public RenderObject(VertexInfo vertexInfo, Texture texture)
        {
            this.vertexInfo = vertexInfo;
            this.movingShader = new Shader(@"../../Render/OpenGL/Shaders/Transform.vert", @"../../Render/OpenGL/Shaders/TextureOverlay.frag");
            this.texture = texture;
            Id = InitializeOpenGL();
        }

        private int InitializeOpenGL()
        {
            int id = GL.GenVertexArray();
            GL.BindVertexArray(id);
            vertexInfo.Use();

            // Инициализация значений позиции.
            //var positionLocation = movingShader.GetAttribLocation("Position");
            GL.VertexAttribPointer(0, 3, VertexAttribPointerType.Float, false, 5 * sizeof(float), 0);
            GL.EnableVertexAttribArray(0);

            // Инициализация значений координат текстур.
            //var texCoordLocation = movingShader.GetAttribLocation("TexCoord");
            GL.VertexAttribPointer(1, 2, VertexAttribPointerType.Float, false, 5 * sizeof(float), 3 * sizeof(float));
            GL.EnableVertexAttribArray(1);
            _projection = Matrix4.CreatePerspectiveFieldOfView(MathHelper.DegreesToRadians(45.0f), (float)800 / (float)600, 0.1f, 100.0f);
            return id;
        }

        public void Draw(Transform transform)
        {
            GL.BindVertexArray(Id);
            movingShader.Use();
            texture.Use();

            var model = Matrix4.Identity * Matrix4.CreateRotationX((float)MathHelper.DegreesToRadians(60));
            var uniformLocationModel = GL.GetUniformLocation(movingShader.Id, "model");
            _view = Matrix4.CreateTranslation(transform.coordination);
            GL.UniformMatrix4(uniformLocationModel, true, ref model);

            movingShader.SetValue("model", model);
            movingShader.SetValue("view", _view);
            movingShader.SetValue("projection", _projection);


            GL.DrawArrays(PrimitiveType.Triangles, 0, vertexInfo.VertexCount);
        }

        public void Dispose()
        {
            throw new NotImplementedException();
        }
    }
}
