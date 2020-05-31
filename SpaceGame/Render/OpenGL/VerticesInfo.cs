using Chleking.Render;
using Chleking.Render.Exceptions;
using OpenTK.Graphics.OpenGL4;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace SpaceGame.Render
{
    public sealed class VerticesInfo
    {
        public int Id { get; private set; }
        public int VertexLength { get; }
        private RenderEntityState state = new RenderEntityState();
        public VerticesAttributeInfo[] AttributeInfo { get; }
        /// <summary>
        /// Убирает какую-либо используемую привязку объекта этого типа и схожего. 
        /// </summary>
        public static void StopUseAny()
        {
            GL.BindBuffer(BufferTarget.ArrayBuffer, 0);
        }

        public VerticesInfo(VerticesAttributeInfo[] attributeInfo)
        {
            this.RowLength = attributeInfo.Sum(item => item.RowLength);
            this.AttributeInfo = attributeInfo;
        }

        public int RowLength { get; }
        public int Length { get; private set; }
        public int VerticesCount => Length / RowLength;
        public int ByteSize => Length * sizeof(float);


        public void Load(float[] vertexInfo)
        {
            if (vertexInfo == null) throw new NullReferenceException(nameof(vertexInfo) + " can't be null");
            if (vertexInfo.Length % RowLength != 0) throw new ArgumentException(nameof(vertexInfo.Length) + " does not fit in rowSize");

            state.Load();

            Length = vertexInfo.Length;
            Id = InitializeDataOpenGL(vertexInfo);
        }

        public void Use()
        {
            GL.BindBuffer(BufferTarget.ArrayBuffer, Id);
        }

        public void Unload()
        {
            state.Unload();

            Use();
            GL.DeleteBuffer(Id);
            StopUseAny();
        }

        private int InitializeDataOpenGL(float[] verticesInfo)
        {
            int id = GL.GenBuffer();
            GL.BindBuffer(BufferTarget.ArrayBuffer, id);
            GL.BufferData(BufferTarget.ArrayBuffer, ByteSize, verticesInfo, BufferUsageHint.StaticDraw);
            return id;
        }
    }
}
