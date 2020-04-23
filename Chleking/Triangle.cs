using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenTK.Graphics.OpenGL;

namespace Chleking
{
    class Triangle : IGraficEntity
    {
        private float[] vertices;
        private Shader shader;

        // Id объекты буфера вершин.
        private int vertexBufferObject;

        public Triangle(Shader shader)
        {
            this.shader = shader;
            this.vertices = new float[] {
                -0.5f, -0.5f, 0.0f,
                0.5f, -0.5f, 0.0f,
                0.0f,  0.5f, 0.0f
            };
        }

        public Triangle(Shader shader, float[] vertices)
        {
            this.shader = shader;
            this.vertices = vertices;
        }

        public void Load()
        {
            // Инициализация объектов OpenGL.
            vertexBufferObject = GL.GenBuffer();

            // Привязка массива вершин в буфер для дальнейшего использование его в OpenGL
            GL.BindBuffer(BufferTarget.ArrayBuffer, vertexBufferObject);
            // его отправка.
            GL.BufferData(BufferTarget.ArrayBuffer, vertices.Length * sizeof(float), vertices, BufferUsageHint.StaticDraw);

            GL.VertexAttribPointer(0, 3, VertexAttribPointerType.Float, false, 3 * sizeof(float), 0);
            GL.EnableVertexAttribArray(0);
        }

        public void Render()
        {
            shader.Use();
            GL.DrawArrays(PrimitiveType.Triangles, 0, 3);
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
