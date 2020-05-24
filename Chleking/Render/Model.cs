using SpaceGame.Core;
using SpaceGame.Render.OpenGL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpaceGame.Render
{
    public class Model
    {
        private RenderObject renderObject;
        public EngineObject Owner { get; private set; }
        public Transform Transform => Owner.Transform;

        public Model(RenderObject renderObject, EngineObject owner)
        {
            this.Owner = owner;
            this.renderObject = renderObject;
        }

        public void Draw()
        {
            renderObject.Draw(Transform);
        }
    }
}
