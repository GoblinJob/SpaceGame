using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenTK.Graphics.OpenGL;

namespace Chleking
{
    class Square : IGraficEntity
    {
        private uint[] indexes = { 0, 1, 3, 1, 2, 3 };
        private float[] vertices;
        private Shader shader;

        // Id объекты буфера вершин.
        private int vertexBufferObject;
        private int elementBufferObject;

        public Square(Shader shader)
        {
            this.shader = shader;
            this.vertices = new float[] {
                0.5f,  0.5f, 0.0f,
                0.5f, -0.5f, 0.0f,
                -0.5f, -0.5f, 0.0f,
                -0.5f,  0.5f, 0.0f
            };
        }

        public Square(Shader shader, float[] vertices)
        {
            this.shader = shader;
            this.vertices = vertices;
        }

        public void Load()
        {
            vertexBufferObject = GL.GenBuffer();
            GL.BindBuffer(BufferTarget.ArrayBuffer, vertexBufferObject);
            GL.BufferData(BufferTarget.ArrayBuffer, vertices.Length * sizeof(float), vertices, BufferUsageHint.StaticDraw);

            elementBufferObject = GL.GenBuffer();
            GL.BindBuffer(BufferTarget.ElementArrayBuffer, elementBufferObject);
            GL.BufferData(BufferTarget.ElementArrayBuffer, indexes.Length * sizeof(uint), indexes, BufferUsageHint.StaticDraw);

            GL.VertexAttribPointer(0, 3, VertexAttribPointerType.Float, false, 3 * sizeof(float), 0);
            GL.EnableVertexAttribArray(0);
        }

        public void Render()
        {
            shader.Use();
            GL.DrawElements(PrimitiveType.Triangles, indexes.Length, DrawElementsType.UnsignedInt, 0);
        }

        public void UnLoad()
        {
            shader.Dispose();
            // Ставит выделенную пользователем память для массива буффера в NULL.
            GL.BindBuffer(BufferTarget.ArrayBuffer, 0);

            GL.DeleteBuffer(vertexBufferObject);
        }
    }
}
