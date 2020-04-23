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
        private int vertexBufferId;
        // Id объекта массива вершин.
        private int vertexArrayId;

        public Triangle(Shader shader, float[] vertices)
        {
            this.shader = shader;
            this.vertices = vertices;
        }

        public void Load()
        {
            // Создание и запись id нового буффера.
            vertexBufferId = GL.GenBuffer();
            // Создание и запись id нового массива вершин.
            vertexArrayId = GL.GenVertexArray();

            // Привязка массива вершин.
            GL.BindVertexArray(vertexArrayId);

            // Привязка массива вершин в буфер для дальнейшего использование его в OpenGL
            GL.BindBuffer(BufferTarget.ArrayBuffer, vertexArrayId);
            // его отправка.
            GL.BufferData(BufferTarget.ArrayBuffer, vertices.Length * sizeof(float), vertices, BufferUsageHint.StaticDraw);

            // Привязка массива вершин в буфер для дальнейшего использование его в OpenGL
            GL.BindBuffer(BufferTarget.ArrayBuffer, vertexBufferId);
            GL.BufferData(BufferTarget.ArrayBuffer, vertices.Length * sizeof(float), vertices, BufferUsageHint.StaticDraw);

            GL.VertexAttribPointer(0, 3, VertexAttribPointerType.Float, false, 3 * sizeof(float), 0);
            GL.EnableVertexAttribArray(0);
        }

        public void Render()
        {
            shader.Use();
            GL.DrawArrays(PrimitiveType.Triangles, 0, 3);
        }
    }
}
