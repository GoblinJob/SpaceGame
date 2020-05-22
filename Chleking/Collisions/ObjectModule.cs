using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Chleking.Core
{
    abstract class CollisionModule
    {
        public EngineObject Owner { get; set; }
        public float[] Vertices { get; set; }
        public event EventHandler<OnCollisedEventArgs> OnCollised;
        public CollisionModule(float[] vertices)
        {
            this.Vertices = vertices;
        }
    }

    class OnCollisedEventArgs : EventArgs
    {
        public CollisionModule[] Colliders { get; set; }
        public OnCollisedEventArgs(CollisionModule[] colliders)
        {
            this.Colliders = colliders;
        }
    }
}
