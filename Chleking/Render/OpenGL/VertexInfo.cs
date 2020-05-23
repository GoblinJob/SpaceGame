using OpenTK.Graphics.OpenGL4;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace SpaceGame.Render.OpenGL
{
    class VertexInfo : IUsableByRender, IDisposable
    {
        public const int RowSize = 5;
        public int Id { get; private set; }
        public int VertexCount { get; private set; }
        public int ElementCount { get; private set; }
        public int ElementsSize => ElementCount * sizeof(float);

        public float[] Value
        {
            get
            {
                var result = new float[ElementCount];
                GL.BindBuffer(BufferTarget.ArrayBuffer, Id);
                GL.GetBufferSubData(BufferTarget.ArrayBuffer, IntPtr.Zero, ElementsSize, result);
                return result;
            }
            set
            {
                // TODO: Проверить, как это работает !!!
                GL.DeleteBuffer(Id);
                GL.BindBuffer(BufferTarget.ArrayBuffer, Id);
                Initialize(value);
            }
        }
        public VertexInfo(float[] vertices, float[] textCoord)
        {
            var verticesInfo = CreateVerticesInfo(vertices, textCoord);
            Initialize(verticesInfo);
        }


        public void Use()
        {
            GL.BindBuffer(BufferTarget.ArrayBuffer, Id);
        }
        public void Dispose()
        {
            GL.DeleteBuffer(Id);
        }

        private void Initialize(float[] verticesInfo)
        {
            ElementCount = verticesInfo.Length;
            VertexCount = verticesInfo.Length / RowSize;
            Id = InitializeDataOpenGL(verticesInfo);
        }

        private int InitializeDataOpenGL(float[] verticesInfo)
        {
            int id = GL.GenBuffer();
            GL.BindBuffer(BufferTarget.ArrayBuffer, id);
            GL.BufferData(BufferTarget.ArrayBuffer, ElementsSize, verticesInfo, BufferUsageHint.StaticDraw);
            return id;
        }

        private float[] CreateVerticesInfo(float[] vertices, float[] textCoord)
        {
            if (IsVertexInfoFormat(vertices, textCoord))
                // TODO: Создать класс исключения.
                throw new Exception("Arrays in not in required format.");
                    
            float[] result = new float[ElementCount];

            for (int vertexIndex = 0; vertexIndex < VertexCount; vertexIndex++)
            {
                result[vertexIndex] = vertices[vertexIndex * 3];
                result[vertexIndex + 1] = vertices[vertexIndex * 3 + 1];
                result[vertexIndex + 2] = vertices[vertexIndex * 3 + 2];
                result[vertexIndex + 3] = textCoord[vertexIndex * 2];
                result[vertexIndex + 4] = textCoord[vertexIndex * 2 + 1];
            }

            return result;
        }

        private bool IsVertexInfoFormat(float[] vertices, float[] textCoord)
        {
            return vertices.Length / 3 == textCoord.Length / 2;
        }

    }
}
