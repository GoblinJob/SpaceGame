using Chleking.Render;
using OpenTK;
using OpenTK.Graphics;
using OpenTK.Graphics.OpenGL4;
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
        public int Id { get; set; }
        public VerticesInfo VertexInfo { get; private set; }
        public Shader Shader { get; private set; }
        private RenderEntityState state = new RenderEntityState();

        public void Load(VerticesInfo vertexInfo, Shader shader)
        {
            state.Load();

            this.VertexInfo = vertexInfo;
            this.Shader = shader;
            Id = InitializeOpenGL();
        }

        public void Unload()
        {
            state.Unload();

            GL.DeleteVertexArray(Id);
        }


        public void Draw(Transform objectTransorm, Camera viewer)
        {
            GL.BindVertexArray(Id);
            Shader.Use(objectTransorm, viewer);

            GL.DrawArrays(PrimitiveType.Triangles, 0, VertexInfo.VerticesCount);
        }

        private int InitializeOpenGL()
        {
            int id = GL.GenVertexArray();
            GL.BindVertexArray(id);
            VertexInfo.Use();

            int stride = 0;

            foreach (var attributeInfo in VertexInfo.AttributeInfo)
            {
                var positionLocation = Shader.GetAttribLocation(attributeInfo.Name);
                GL.VertexAttribPointer(positionLocation, attributeInfo.RowLength, VertexAttribPointerType.Float, false, VertexInfo.RowLength * sizeof(float), stride * sizeof(float));
                GL.EnableVertexAttribArray(positionLocation);

                stride += attributeInfo.RowLength;
            }

            return id;
        }
    }
}
