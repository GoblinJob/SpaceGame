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
    public sealed class VertexInfo : RenderEntity
    {
        public const int RowSize = 5;
        /// <summary>
        /// Убирает какую-либо используемую привязку объекта этого типа и схожего. 
        /// </summary>
        public static void StopUseAny()
        {
            GL.BindBuffer(BufferTarget.ArrayBuffer, 0);
        }

        public VertexInfo()
        {
        }

        public int ElementCount { get; private set; }
        public int VertexCount => ElementCount / RowSize;
        public int ElementsSize => ElementCount * sizeof(float);


        public void Load(float[] vertexInfo)
        {
            if (vertexInfo == null) throw new NullReferenceException(nameof(vertexInfo) + " can't ne null");
            SetLoaded();

            ElementCount = vertexInfo.Length;
            Id = InitializeDataOpenGL(vertexInfo);
        }

        public void Use()
        {
            GL.BindBuffer(BufferTarget.ArrayBuffer, Id);
        }

        public void Unload()
        {
            SetUnloaded();

            Use();
            GL.DeleteBuffer(Id);
            StopUseAny();
        }

        private int InitializeDataOpenGL(float[] verticesInfo)
        {
            int id = GL.GenBuffer();
            GL.BindBuffer(BufferTarget.ArrayBuffer, id);
            GL.BufferData(BufferTarget.ArrayBuffer, ElementsSize, verticesInfo, BufferUsageHint.StaticDraw);
            return id;
        }
    }
}
