using OpenTK;
using SpaceGame.Core;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TestGame;

namespace Chleking.Render
{
    public class Model
    {
        public RenderInfo Info { get; }
        public float[] VertexInfo { get; }
        public EngineObject Owner { get; set; }
        public Bitmap Texture { get; set; }
        public Vector3 WorldPosition => Owner.Transform.coordination;
        public Model(float[] vertexInfo, EngineObject owner)
        {
            this.VertexInfo = vertexInfo;
            this.Owner = owner;
        }
    }
}
