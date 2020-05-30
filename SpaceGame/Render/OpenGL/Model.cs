using Chleking.Render;
using OpenTK;
using OpenTK.Graphics;
using OpenTK.Graphics.OpenGL4;
using SpaceGame.Core;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpaceGame.Render
{
    public class Model : IDrawable
    {
        public Model()
        {
        }
        public VerticesInfo VertexInfo { get; private set; }
        public Shader Shader { get; private set; }


        public void Load(VerticesInfo vertexInfo, Shader shader)
        {
            SetLoaded();

            this.VertexInfo = vertexInfo;
            this.Shader = shader;
            Id = InitializeOpenGL();
        }

        public void Unload()
        {
            SetUnloaded();

            GL.DeleteVertexArray(Id);
        }


        public void Draw(Transform objectTransorm, Camera viewer)
        {
            GL.BindVertexArray(Id);
            Shader.Use(objectTransorm, viewer);

            GL.DrawArrays(PrimitiveType.Triangles, 0, VertexInfo.VertexCount);
        }

        private int InitializeOpenGL()
        {
            int id = GL.GenVertexArray();
            GL.BindVertexArray(id);
            VertexInfo.Use();

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
    }
}
