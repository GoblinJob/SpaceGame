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
    public class RenderableObject : IDisposable
    {
        private static List<RenderableObject> existRenderableObjects = new List<RenderableObject>();

        public int Id { get; private set; }
        private Model vertexInfo;
        private Shader movingShader;
        private Texture texture;

        private RenderableObject()
        {
        }

        public static RenderableObject Create(Model vertexInfo, Texture texture)
        {
            var alreadyExistRenderableObject = existRenderableObjects.Find(item => vertexInfo == item.vertexInfo  && texture == item.texture);
            if (alreadyExistRenderableObject != null) return alreadyExistRenderableObject;

            return new RenderableObject(vertexInfo, texture);
        }

        private RenderableObject(Model vertexInfo, Texture texture)
        {
            this.vertexInfo = vertexInfo;
            this.movingShader = Shader.GetShader("0");
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
            return id;
        }

        public void Draw(Camera viewer, Transform transform)
        {
            GL.BindVertexArray(Id);
            movingShader.Use();
            texture.Use();

            movingShader.SetValue("position", transform.location + viewer.Transform.location);
            movingShader.SetValue("rotation", transform.rotation.Xyz);
            movingShader.SetValue("scale", transform.scale);
            movingShader.SetValue("projection", viewer.ViewMatrix);

            GL.DrawArrays(PrimitiveType.Triangles, 0, vertexInfo.VertexCount);
        }

        public void Dispose()
        {
            throw new NotImplementedException();
        }
    }
}
