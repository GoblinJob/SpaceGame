using Chleking.Render;
using Chleking.Render.Exceptions;
using OpenTK.Graphics.OpenGL4;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace SpaceGame.Render.OpenGL
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

        public VerticesInfo(int vertexLength, VerticesAttributeInfo[] attributeInfo)
        {
            this.VertexLength = vertexLength;
            this.AttributeInfo = attributeInfo;
        }

        public int Length { get; private set; }
        public int VertexCount => Length / Length;
        public int VertexByteSize => Length / Length;
        public int ByteSize => Length * sizeof(float);


        public void Load(float[] vertexInfo)
        {
            if (vertexInfo == null) throw new NullReferenceException(nameof(vertexInfo) + " can't ne null");
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
